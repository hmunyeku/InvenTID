using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraBars;
using Symbol.RFID3;


using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Microsoft.Win32;
using Owin;

namespace InvenTID
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        const int MAX_OUTPUT_LINES = 1000;
        int outputLinePos = 0;
        const string safetyKey = "Password64!";
        private IDisposable SignalR { get; set; }
        Readers readers;
        public static RFIDReader selectedReader;
        List<RFIDReader> availableReaders;
        Dictionary<string, TagInfo> tagList = new Dictionary<string, TagInfo>();
        StringBuilder sbOutStatus = new StringBuilder();
        bool bPostConnectInitialized;
        AutoResetEvent eBatchModeEvent;
        public ReaderCapabilities capSettings;
        MySettings reglages = new MySettings();
        Encryption password = new Encryption(safetyKey);
        Encryption username = new Encryption(safetyKey);
        Encryption loginTimestamp = new Encryption(safetyKey);
        public string ServerURI;
        public FrmMain()
        {
            InitializeComponent();
            bPostConnectInitialized = false;
            eBatchModeEvent = new AutoResetEvent(false);

            // Get "My Documents" folder
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path.Combine(path, "InvenTID");
            string fullpath = Path.Combine(path, "Settings.xml");
            // Create folder if it doesn't already exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            // Initialize settings
            reglages = new MySettings();

            if (!File.Exists(fullpath))
            {
                StreamWriter sw = File.CreateText(fullpath);
                sw.WriteLine("<?xml version=\"1.0\"?><Settings></Settings>");
                sw.Close();
            }


            reglages.SettingsPath = Path.Combine(path, "Settings.xml");
            reglages.EncryptionKey = safetyKey;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

            DisableUIControls();

            btnPairNew.Enabled = false;

            DataGridViewColumn colTagID = new DataGridViewTextBoxColumn();
            colTagID.HeaderText = "TagID";
            colTagID.Name = "TagID";
            colTagID.Width = 330;
            grdTags.Columns.Add(colTagID);


            DataGridViewColumn colPeakRSSI = new DataGridViewTextBoxColumn();
            colPeakRSSI.HeaderText = "Peak RSSI";
            colPeakRSSI.Name = "PeakRSSI";
            colPeakRSSI.Width = 330;
            grdTags.Columns.Add(colPeakRSSI);


            DataGridViewColumn colTagCount = new DataGridViewTextBoxColumn();
            colTagCount.HeaderText = "Tag Seen Count";
            colTagCount.Name = "TagSeenCount";
            colTagCount.Width = 140;
            grdTags.Columns.Add(colTagCount);
            DiscoverScanners();

            cboBeeperVolume.Items.Add("HIGH_BEEP");
            cboBeeperVolume.Items.Add("MEDIUM_BEEP");
            cboBeeperVolume.Items.Add("LOW_BEEP");
            cboBeeperVolume.Items.Add("QUIET_BEEP");
            cboBeeperVolume.SelectedIndex = 0;

            cmb_BatchMode.Items.Add("AUTO");
            cmb_BatchMode.Items.Add("ENABLE");
            cmb_BatchMode.Items.Add("DISABLE");
            cmb_BatchMode.SelectedIndex = 0;

            cboStatus.SelectedIndex = 0;

            reglages.Load();
            checkOpenMinimized.Checked = reglages.openMinimized;
            checkLaunchWeb.Checked = reglages.launchWeb;
            weblink.Text = reglages.weblink;
            checkLaunchServer.Checked = reglages.launchServer;
            txtPortSignalR.Text = reglages.signalrPort.ToString();
            if (reglages.autologin)
            {
                txtUsername.Text = reglages.username;
                txtPassword.Text = reglages.password;
                checkAutoLogin.Checked = reglages.autologin;
            }

            ServerURI = "http://localhost:" + txtPortSignalR.Text + "/";

            if (reglages.openMinimized)
            {
                WindowState = FormWindowState.Minimized;
            }

            if (reglages.launchServer)
            {
                btnStart.PerformClick();
            }

            if (reglages.launchWeb)
            {
                btnWeb.PerformClick();
            }
        }

        private void LoadSettings()
        {
            txtModelName.Text = capSettings.ModelName;
            txtSerialNumber.Text = capSettings.SerialNumber;
            txtManufactureName.Text = capSettings.ManufactureName;
            txtManufactureDate.Text = capSettings.ManufacturingDate;
        }

        private static bool PortInUse(int port)
        {
            bool inUse = false;
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();

            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    break;
                }
            }
            return inUse;
        }

        private void DiscoverScanners()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                try
                {
                    readers = new Readers();
                    readers.RFIDReaderAppeared += Readers_RFIDReaderAppeared;
                    readers.RFIDReaderDisappeared += Readers_RFIDReaderDisappeared;
                }
                catch (Exception e1)
                {
                    OutputText("ERREUR : Verifier si le Bluetooth est supporté. Exception:" + e1.ToString());
                }

                availableReaders = readers.GetAvailableRFIDReaderList();
                comboBoxReaders.Items.Clear();
                foreach (RFIDReader reader in availableReaders)
                {
                    ComboboxItem item = new ComboboxItem(reader);
                    comboBoxReaders.Items.Add(item);
                }
                if (comboBoxReaders.Items.Count > 0)
                {
                    comboBoxReaders.SelectedIndex = 0;
                    btnConnect.Enabled = true;
                }
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
            finally
            {
                btnPairNew.Enabled = true;

            }
            Cursor.Current = Cursors.Default;
        }

        private void btnRefresh_ItemClick(object sender, EventArgs e)
        {
            try
            {
                availableReaders = readers.GetAvailableRFIDReaderList();
                comboBoxReaders.Items.Clear();
                foreach (RFIDReader reader in availableReaders)
                {
                    ComboboxItem item = new ComboboxItem(reader);
                    comboBoxReaders.Items.Add(item);
                }
                if (selectedReader == null)
                {
                    if (comboBoxReaders.Items.Count > 0)
                    {
                        comboBoxReaders.SelectedIndex = 0;
                        btnConnect.Enabled = true;
                    }
                }
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }

        private void DisableUIControls()
        {
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = false;
            btnVersionInfo.Enabled = false;
            btnInventory.Enabled = false;
            btnAbort.Enabled = false;
            btnSetPower.Enabled = false;
            btnGetPower.Enabled = false;
            btnSaveConfig.Enabled = false;
            btnGetRegion.Enabled = false;
            btnRestoreDefaults.Enabled = false;
            btnDisconnect.Enabled = false;
            btnGetStatus.Enabled = false;
            btnGetBatchMode.Enabled = false;
            btnSetBatchMode.Enabled = false;
            btnGetBeeperVolume.Enabled = false;
            btnSetBeeperVolume.Enabled = false;
            triggers.Enabled = false;
        }

        private void EnableUIControls()
        {
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = true;
            btnVersionInfo.Enabled = true;
            btnInventory.Enabled = true;
            btnAbort.Enabled = false;
            btnSetPower.Enabled = true;
            btnGetPower.Enabled = true;
            btnSaveConfig.Enabled = true;
            btnGetRegion.Enabled = true;
            btnRestoreDefaults.Enabled = true;
            btnDisconnect.Enabled = true;
            btnGetStatus.Enabled = true;
            btnGetBatchMode.Enabled = false;
            btnSetBatchMode.Enabled = false;
            btnGetBeeperVolume.Enabled = true;
            btnSetBeeperVolume.Enabled = true;
            triggers.Enabled = true;
        }

        private void ProcessingInventory(bool bInventory)
        {
            if (bInventory)
            {
                btnInventory.Enabled = false;
                btnAbort.Enabled = true;
                btnSetPower.Enabled = false;
                btnGetPower.Enabled = false;
                btnGetRegion.Enabled = false;
                btnSaveConfig.Enabled = false;
                btnRestoreDefaults.Enabled = false;
                btnVersionInfo.Enabled = false;
            }
            else
            {
                btnInventory.Enabled = true;
                btnAbort.Enabled = false;
                btnSetPower.Enabled = true;
                btnGetPower.Enabled = true;
                btnGetRegion.Enabled = true;
                btnSaveConfig.Enabled = true;
                btnRestoreDefaults.Enabled = true;
                btnVersionInfo.Enabled = true;
            }
        }

        private void btnConnect_ItemClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ComboboxItem selectedItem = (ComboboxItem)comboBoxReaders.SelectedItem;
                selectedReader = (RFIDReader)selectedItem.Value;
                OutputText("Connecter()");
                selectedReader.Connect();
                selectedReader.Events.ReadNotify += Events_ReadNotify;
                selectedReader.Events.StatusNotify += Events_StatusNotify;
                OutputText("Adresse Bluetooth:" + selectedReader.BluetoothAddress);
                OutputText("Nom :" + selectedReader.FriendlyName);
                EnableUIControls();
                btnConnect.Enabled = false;
                comboBoxReaders.Enabled = false;
                if (!bPostConnectInitialized)
                {
                    ledRfid.Image = Properties.Resources.led_green;
                    capSettings = selectedReader.ReaderCapabilities;
                    LoadSettings();
                    Task taskPostConnect = Task.Run(() => WaitForBatchModeEvent());

                }

            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
            Cursor.Current = Cursors.Default;
        }

        private void StartServer()
        {
            try
            {
                SignalR = WebApp.Start(ServerURI);
                btnStart.Enabled = false;
            }
            catch (TargetInvocationException)
            {
                OutputText("Echec de lancement, un serveur est dejà lancé @ " + ServerURI);
                ledSignalR.Image = Properties.Resources.led_red;
                //Re-enable button to let user try to start server again
                this.Invoke((Action)(() => btnStart.Enabled = true));
                return;
            }

            this.Invoke((Action)(() => btnStop.Enabled = true));
            ledSignalR.Image = Properties.Resources.led_green;
            OutputText("Server demarré sur " + ServerURI);
        }

        private void WaitForBatchModeEvent()
        {
            if (eBatchModeEvent.WaitOne(1000))
            {
            }
            else
            {
                PostConnectInitialize(0);
            }
        }

        private void PostConnectInitialize(int delay)
        {
            Thread.Sleep(delay);
            if (!bPostConnectInitialized)
            {
                MethodInvoker inv = delegate
                {
                    GetRegionInfo();
                    GetPower();
                    GetCapabilities();
                    GetStatus();
                    GetBeeperVolume();
                    GetBatchMode();
                };

                this.Invoke(inv);

                bPostConnectInitialized = true;
            }

        }

        private void ConfigureDefaultRegion()
        {
            try
            {
                OutputText("Region: Pas configuré. Par defaut USA");
                RegulatoryConfig config = new RegulatoryConfig();
                config.Region = "USA";
                selectedReader.Config.RegulatoryConfig = config;
            }
            catch (Exception e2)
            {

                if (e2 is InvalidUsageException)
                {
                    if (((InvalidUsageException)e2).Info.Contains("Inventaire en cours"))
                    {
                        btnAbort.Enabled = true;
                    }
                }
                OutputText(e2.ToString());
            }
        }

        private void GetStatus()
        {
            try
            {
                if (selectedReader != null)
                {
                    selectedReader.Config.GetDeviceStatus(true, true, true);
                }
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }

        private void GetCapabilities()
        {
            try
            {
                if (selectedReader != null)
                {
                    OutputText("Capacités : Modèle = " + selectedReader.ReaderCapabilities.ModelName);
                    OutputText("Capacités : Fabricant = " + selectedReader.ReaderCapabilities.ManufactureName);
                    OutputText("Capacités : Date de fab. = " + selectedReader.ReaderCapabilities.ManufacturingDate);
                    OutputText("Capacités : SN = " + selectedReader.ReaderCapabilities.SerialNumber);
                }
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }

        private void btnPairNew_ItemClick(object sender, EventArgs e)
        {
            readers.PairNewReader(this);
        }

        private void btnInventory_ItemClick(object sender, EventArgs e)
        {
            try
            {
                OutputText("Actions.Inventaire.Lancer()");
                selectedReader.Actions.Inventory.Perform();
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }

        private void btnAbort_ItemClick(object sender, EventArgs e)
        {
            try
            {
                OutputText("Actions.Inventaire.Stop()");
                selectedReader.Actions.Inventory.Stop();
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }

        private void btnVersionInfo_ItemClick(object sender, EventArgs e)
        {
            try
            {
                OutputText(selectedReader.VersionInfo.Version);
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }

        private void btnGetPower_ItemClick(object sender, EventArgs e)
        {
            GetPower();
        }

        private void GetPower()
        {
            try
            {
                if (selectedReader != null)
                {
                    ushort[] antID = selectedReader.Config.Antennas.AvailableAntennas;
                    Antennas.Config antConfig = selectedReader.Config.Antennas[antID[0]].GetConfig();
                    txtPower.Text = antConfig.TransmitPowerIndex.ToString();
                    OutputText("GetPower : TransmitPowerIndex = " + txtPower.Text);

                }
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }

        private void btnSetPower_ItemClick(object sender, EventArgs e)
        {
            try
            {
                if (selectedReader != null)
                {
                    ushort[] antID = selectedReader.Config.Antennas.AvailableAntennas;
                    Antennas.Config antConfig = selectedReader.Config.Antennas[antID[0]].GetConfig();
                    antConfig.TransmitPowerIndex = ushort.Parse(txtPower.Text); //Handle errors
                    selectedReader.Config.Antennas[antID[0]].SetConfig(antConfig);
                    OutputText("SetPower : TransmitPowerIndex = " + antConfig.TransmitPowerIndex.ToString());
                }
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }

        private void btnSaveConfig_ItemClick(object sender, EventArgs e)
        {
            try
            {if (selectedReader != null)
                {
                    selectedReader.Config.SaveConfig();
                    OutputText("Enregistrer : Succès");

                }
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }

        private void btnRestoreDefaults_ItemClick(object sender, EventArgs e)
        {
            try
            {
                if (selectedReader != null)
                {
                    selectedReader.Config.ResetFactoryDefaults();
                }
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }

        private void Events_ReadNotify(object sender, Events.ReadEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {

                OutputText("Events_ReadNotify\n");
                if (e.ReadEventData != null)
                {
                    TagData data = e.ReadEventData.TagData;
                    if (data != null) ShowTagData(data);
                }
                else
                {
                    try
                    {
                        if (selectedReader != null)
                        {
                            TagData[] tagDataArr = selectedReader.Actions.GetReadTags(100);
                            if (tagDataArr != null)
                            {
                                foreach (TagData tagData in tagDataArr)
                                {
                                    ShowTagData(tagData);
                                }
                            }
                        }
                    }
                    catch (Exception e1)
                    {
                        OutputText(e1.ToString());
                    }
                }

            });
        }

        private void ShowTagData(TagData data)
        {
            if (!tagList.ContainsKey(data.TagID))
            {
                int tagRowID = grdTags.Rows.Add();
                TagInfo tag = new TagInfo(data, tagRowID, data.TagSeenCount);
                tagList.Add(data.TagID, tag);
                grdTags["TagID", tagRowID].Value = tag.Tag.TagID;
                grdTags["PeakRSSI", tagRowID].Value = tag.Tag.PeakRSSI;
                grdTags["TagSeenCount", tagRowID].Value = tag.Tag.TagSeenCount;
                txtTotalTags.Text = tagList.Count.ToString();
            }
            else
            {
                tagList[data.TagID].Tag = data;
                tagList[data.TagID].TagSeenTotalCount += tagList[data.TagID].Tag.TagSeenCount;
                grdTags["PeakRSSI", tagList[data.TagID].RowIndex].Value = tagList[data.TagID].Tag.PeakRSSI;
                grdTags["TagSeenCount", tagList[data.TagID].RowIndex].Value = tagList[data.TagID].TagSeenTotalCount;
            }

        }

        private void Events_StatusNotify(object sender, Events.StatusEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (e != null)
                {
                    switch (e.StatusEventData.StatusEventType)
                    {
                        case Symbol.RFID3.Events.STATUS_EVENT_TYPE.DISCONNECTION_EVENT:
                        {
                            OutputText("Events_StatusNotify: Events.STATUS_EVENT_TYPE.DISCONNECTION_EVENT\n");
                            DisableUIControls();
                            btnConnect.Enabled = true;
                            comboBoxReaders.Enabled = true;
                            selectedReader.Events.ReadNotify -= Events_ReadNotify;
                            selectedReader.Events.StatusNotify -= Events_StatusNotify;
                            selectedReader = null;
                            bPostConnectInitialized = false;
                            break;
                        }
                        case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT:
                        {
                            OutputText("Events_StatusNotify: Events.STATUS_EVENT_TYPE.INVENTORY_START_EVENT\n");
                            ProcessingInventory(true);
                            break;
                        }
                        case Symbol.RFID3.Events.STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT:
                        {
                            OutputText("Events_StatusNotify: Events.STATUS_EVENT_TYPE.INVENTORY_STOP_EVENT\n");
                            ProcessingInventory(false);
                            if (!bPostConnectInitialized)
                            {
                                Task taskPostConnect = Task.Run(() => PostConnectInitialize(2000));
                            }
                            break;
                        }
                        case Symbol.RFID3.Events.STATUS_EVENT_TYPE.BATTERY_EVENT:
                        {
                            OutputText("Events_StatusNotify: Events.STATUS_EVENT_TYPE.BATTERY_EVENT\n");
                            OutputText("\tLevel = " + e.StatusEventData.BatteryEventData.BatteryLevel + "%\n");
                            OutputText("\tStatus = " + e.StatusEventData.BatteryEventData.BatteryStatus + "\n");
                            OutputText("\tCause = " + e.StatusEventData.BatteryEventData.Cause + "\n");
                            break;
                        }
                        case Symbol.RFID3.Events.STATUS_EVENT_TYPE.POWER_EVENT:
                        {
                            OutputText("Events_StatusNotify: Events.STATUS_EVENT_TYPE.POWER_EVENT\n");
                            OutputText("\tCurrent = " + e.StatusEventData.PowerEventData.Current + "\n");
                            OutputText("\tPower = " + e.StatusEventData.PowerEventData.Power + "\n");
                            OutputText("\tVoltage = " + e.StatusEventData.PowerEventData.Voltage + "\n");
                            OutputText("\tCause = " + e.StatusEventData.PowerEventData.Cause + "\n");
                            break;
                        }
                        case Symbol.RFID3.Events.STATUS_EVENT_TYPE.TEMPERATURE_ALARM_EVENT:
                        {
                            OutputText("Events_StatusNotify: Events.STATUS_EVENT_TYPE.TEMPERATURE_ALARM_EVENT\n");
                            OutputText("\tSTM32 Temperature = " + e.StatusEventData.TemperatureAlarmData.STM32Temp + "\n");
                            OutputText("\tRadio PA Temperature = " + e.StatusEventData.TemperatureAlarmData.PATemp + "\n");
                            OutputText("\tCause = " + e.StatusEventData.TemperatureAlarmData.Cause + "\n");
                            break;
                        }
                        case Symbol.RFID3.Events.STATUS_EVENT_TYPE.OPERATION_END_SUMMARY:
                        {
                            OutputText("Events_StatusNotify: Events.STATUS_EVENT_TYPE.OPERATION_END_SUMMARY\n");
                            OutputText("\tTotal Rounds = " + e.StatusEventData.OperationEndSummaryData.TotalRounds + "\n");
                            OutputText("\tTotal Tags = " + e.StatusEventData.OperationEndSummaryData.TotalTags + "\n");
                            OutputText("\tTotal Time (μs) = " + e.StatusEventData.OperationEndSummaryData.TotalTimeuS + "\n");
                            break;
                        }
                    }
                }

            });
        }

        private void Readers_RFIDReaderDisappeared(RFIDReader reader)
        {
            this.Invoke((MethodInvoker)delegate
            {
                OutputText("Reader Disappeared " + reader.FriendlyName + "\n");
                RemoveFromReaderList(reader);
            });
        }

        private void Readers_RFIDReaderAppeared(RFIDReader reader)
        {
            this.Invoke((MethodInvoker)delegate
            {
                OutputText("Reader Appeared " + reader.FriendlyName + "\n");
                AddToReaderList(reader);
            });
        }

        private void RemoveFromReaderList(RFIDReader reader)
        {
            bool found = false;
            ComboboxItem curItem = null;
            for (int n = 0; n < comboBoxReaders.Items.Count; n++)
            {
                curItem = (ComboboxItem)comboBoxReaders.Items[n];
                if (curItem.Id == reader.BluetoothAddress)
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                comboBoxReaders.Items.Remove(curItem);
                if (comboBoxReaders.Items.Count == 0)
                {
                    DisableUIControls();
                    btnConnect.Enabled = false;
                }
            }
        }

        private void AddToReaderList(RFIDReader reader)
        {
            bool found = false;
            ComboboxItem curItem = null;
            for (int n = 0; n < comboBoxReaders.Items.Count; n++)
            {
                curItem = (ComboboxItem)comboBoxReaders.Items[n];
                if (curItem.Id == reader.BluetoothAddress)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                ComboboxItem item = new ComboboxItem(reader);
                comboBoxReaders.Items.Add(item);
            }
            if (comboBoxReaders.Items.Count > 0)
            {
                comboBoxReaders.SelectedIndex = 0;
                btnConnect.Enabled = true;
            }
        }

        private void btnGetRegion_ItemClick(object sender, EventArgs e)
        {
            GetRegionInfo();
        }

        private void GetRegionInfo()
        {
            try
            {
                if (selectedReader != null)
                {
                    RegulatoryConfig regConfig = selectedReader.Config.RegulatoryConfig;
                    txtRegion.Text = regConfig.Region;
                    OutputText("Config.RegulatoryConfig.Region : " + regConfig.Region);
                }
            }
            catch (Exception e1)
            {
                if (e1.Message.StartsWith("RegulatoryConfig"))
                {
                    ConfigureDefaultRegion();
                }
                else
                {
                    OutputText(e1.ToString());
                }
            }
        }

        private void btnGetActiveScanners_ItemClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                List<RFIDReader> activeReaders = readers.GetActiveRFIDReaderList();
                OutputText("-----------------------------------------------");
                int i = 0;
                foreach (RFIDReader reader in activeReaders)
                {
                    OutputText("Active connected scanner [" + i + "]");
                    OutputText("Bluetooth Address:" + reader.BluetoothAddress);
                    OutputText("Friendly Name:" + reader.FriendlyName);
                    OutputText("Is connected:" + reader.IsConnected);
                    OutputText("-----------------------------------------------");
                    i++;
                }
                if ((activeReaders == null) || (activeReaders.Count == 0))
                {
                    OutputText("No Active (connected) scanners.");
                    OutputText("-----------------------------------------------");
                }
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
            Cursor.Current = Cursors.Default;
        }

        private void ShowSingulationDlg()
        {
            if (selectedReader != null)
            {
                frmSingulation frm = new frmSingulation(this);
                frm.curReader = selectedReader;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    OutputText(frm.Result);
                }
            }
            else
            {
                MessageBox.Show("RFID Reader Not Connected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDisconnect_ItemClick(object sender, EventArgs e)
        {
            try
            {
                selectedReader.Events.ReadNotify -= Events_ReadNotify;
                selectedReader.Events.StatusNotify -= Events_StatusNotify;
                OutputText("Disconnect()");
                selectedReader.Disconnect();
                DisableUIControls();
                btnConnect.Enabled = true;
                comboBoxReaders.Enabled = true;
                selectedReader = null;
                bPostConnectInitialized = false;
                ledRfid.Image = Properties.Resources.led_red;
                DeloadSettings();

            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }

        private void DeloadSettings()
        {
            txtModelName.Text = "";
            txtSerialNumber.Text = "";
            txtManufactureName.Text = "";
            txtManufactureDate.Text = "";
        }

        private void FrmMain_Closing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (selectedReader != null)
                {
                    selectedReader.Actions.Inventory.Stop();
                    selectedReader.Disconnect();
                }

            }
            catch (Exception e1)
            {
                Debug.Print(e1.ToString());
            }
            finally
            {
                if ((selectedReader != null) && (selectedReader.IsConnected))
                    selectedReader.Disconnect();
            }

            btnStop.PerformClick();
            notifyIcon1.Visible = false;
        }

        public void OutputText(string txt)
        {
            outputLinePos++;
            if (outputLinePos > MAX_OUTPUT_LINES)
            {
                sbOutStatus.Clear();
                outputLinePos = 0;
            }

            if (!String.IsNullOrEmpty(txt))
            {
                txt = outputLinePos +"| " + DateTime.Now.ToString("dd/MM/yy HH:mm") + " | " + txt + Environment.NewLine;
                sbOutStatus.AppendLine(txt);
                txtOutput.Text = sbOutStatus.ToString();
                txtOutput.SelectionStart = txtOutput.Text.Length;
                txtOutput.ScrollToCaret();
            }
        }

        private void btnClear_ItemClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Toutes les données d'inventaire vont être supprimées,\r\n Êtes-vous sûr (y/n)?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                try
                {
                    if (selectedReader != null)
                    {
                        if (!selectedReader.Actions.PurgeTags())
                        {
                            OutputText("Erreur durant le nettoyage.");
                        }
                    }
                }
                catch (Exception e1)
                {
                    OutputText(e1.ToString());
                }
                txtOutput.Clear();
                sbOutStatus.Clear();
                tagList.Clear();
                grdTags.Rows.Clear();
                txtTotalTags.Text = "";
            }
        }

        private void btnAbout_ItemClick(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.Show();
        }

        private void ShowReaderCapabilities()
        {
            if (selectedReader != null)
            {
                frmCapabilities frmCap = new frmCapabilities();
                try
                {
                    frmCap.capSettings = selectedReader.ReaderCapabilities;
                    frmCap.Show();
                }
                catch (Exception e1)
                {
                    OutputText("Erreur lors de la recuperation des paramètres, exception :" + e1.ToString());
                }
            }
            else
            {
                MessageBox.Show("Lecteur RFID non-connecté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Triggers_ItemClick(object sender, EventArgs e)
        {
            if (selectedReader != null)
            {
                try
                {
                    TriggersForm frmTrigger = new TriggersForm(this);
                    TriggersForm.m_TriggerInfo = selectedReader.Config.TriggerInfo;
                    if (frmTrigger.ShowDialog(this) == DialogResult.OK)
                    {
                        selectedReader.Config.TriggerInfo = TriggersForm.m_TriggerInfo;
                        OutputText("TriggerInfo: Configuration Successful.");
                    }
                }
                catch (Exception e1)
                {
                    OutputText("Erreur lors de la recuperation d'informations trigger, exception :" + e1.ToString());
                }
            }
        }

        private void btnGetBeeperVolume_ItemClick(object sender, EventArgs e)
        {
            GetBeeperVolume();
        }

        void GetBeeperVolume()
        {
            try
            {
                if (selectedReader != null)
                {

                    BEEPER_VOLUME beeperVolume = selectedReader.Config.BeeperVolume;
                    string strBeeperVolume = "";
                    switch (beeperVolume)
                    {
                        case BEEPER_VOLUME.HIGH_BEEP:
                        {
                            strBeeperVolume = "HIGH_BEEP";
                            break;
                        }
                        case BEEPER_VOLUME.MEDIUM_BEEP:
                        {
                            strBeeperVolume = "MEDIUM_BEEP";
                            break;
                        }
                        case BEEPER_VOLUME.LOW_BEEP:
                        {
                            strBeeperVolume = "LOW_BEEP";
                            break;
                        }
                        case BEEPER_VOLUME.QUIET_BEEP:
                        {
                            strBeeperVolume = "QUIET_BEEP";
                            break;
                        }
                    }
                    cboBeeperVolume.Text = strBeeperVolume;
                    OutputText("GetBeeperVolume = " + strBeeperVolume);
                }
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }
        void GetBatchMode()
        {
            try
            {
                if (selectedReader != null)
                {

                    BATCH_MODE batchMode = selectedReader.Config.BatchModeConfig;
                    string strBatchMode = "";
                    switch (batchMode)
                    {
                        case BATCH_MODE.AUTO:
                            strBatchMode = "AUTO";
                            break;
                        case BATCH_MODE.DISABLE:
                            strBatchMode = "DISABLE";
                            break;
                        case BATCH_MODE.ENABLE:
                            strBatchMode = "ENABLE";
                            break;

                    }
                    cmb_BatchMode.Text = strBatchMode;
                    OutputText("GetBatchMode = " + strBatchMode);
                }
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }

        private void btnSetBeeperVolume_ItemClick(object sender, EventArgs e)
        {
            try
            {
                if (selectedReader != null)
                {
                    switch (cboBeeperVolume.Text)
                    {
                        case "HIGH_BEEP":
                        {
                            selectedReader.Config.BeeperVolume = BEEPER_VOLUME.HIGH_BEEP;
                            break;
                        }
                        case "MEDIUM_BEEP":
                        {
                            selectedReader.Config.BeeperVolume = BEEPER_VOLUME.MEDIUM_BEEP;
                            break;
                        }
                        case "LOW_BEEP":
                        {
                            selectedReader.Config.BeeperVolume = BEEPER_VOLUME.LOW_BEEP;
                            break;
                        }
                        case "QUIET_BEEP":
                        {
                            selectedReader.Config.BeeperVolume = BEEPER_VOLUME.QUIET_BEEP;
                            break;
                        }
                    }
                    OutputText("SetBeeperVolume = " + cboBeeperVolume.Text);
                }
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }

        private void btnGetStatus_ItemClick(object sender, EventArgs e)
        {
            bool batteryStatus = false;
            bool powerStatus = false;
            bool temperatureStatus = false;

            if (cboStatus.SelectedIndex == 0)
            {
                batteryStatus = true;
            }
            else if (cboStatus.SelectedIndex == 1)
            {
                powerStatus = true;
            }
            else if (cboStatus.SelectedIndex == 2)
            {
                temperatureStatus = true;
            }

            try
            {
                if (selectedReader != null)
                {
                    selectedReader.Config.GetDeviceStatus(batteryStatus, powerStatus, temperatureStatus);
                }
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }

        private void btnCapacites_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowReaderCapabilities();
        }

        private void btnConf_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowSingulationDlg();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnWeb_ItemClick(object sender, EventArgs e)
        {
            Process.Start(reglages.weblink);
        }

        private void btnSetBatchMode_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedReader != null)
                {
                    switch (cmb_BatchMode.Text)
                    {
                        case "ENABLE":
                        {
                            selectedReader.Config.BatchModeConfig = BATCH_MODE.ENABLE;
                            break;
                        }
                        case "DISABLE":
                        {
                            selectedReader.Config.BatchModeConfig = BATCH_MODE.DISABLE;
                            break;
                        }
                        case "AUTO":
                        {
                            selectedReader.Config.BatchModeConfig = BATCH_MODE.AUTO;
                            break;
                        }

                    }
                    OutputText("SetBatchMode = " + cmb_BatchMode.Text);
                }
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }

        }

        private void btnPurgeTags_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedReader != null)
                {
                    selectedReader.Actions.PurgeTags();
                    OutputText("PurgeTags : Successful");
                }
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }

        private void btnGetBatchedTags_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedReader != null)
                {
                    selectedReader.Actions.GetBatchedTags();
                    OutputText("Get Batched Tags : Successful");
                }
            }
            catch (Exception e1)
            {
                OutputText(e1.ToString());
            }
        }
        private void btnGetBatchMode_Click(object sender, EventArgs e)
        {
            GetBatchMode();
        }

        private void btnGetBatchedTags_Click(object sender, ItemClickEventArgs e)
        {

        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            //if the form is minimized
            //hide it from the task bar
            //and show the system tray icon (represented by the NotifyIcon control)
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void SaveConfig_Click(object sender, EventArgs e)
        {
            int port = 8989;
            reglages.openMinimized = checkOpenMinimized.Checked;
            reglages.launchWeb = checkLaunchWeb.Checked;
            reglages.weblink = weblink.Text;
            reglages.launchServer = checkLaunchServer.Checked;
            int.TryParse(txtPortSignalR.Text, out port);
            reglages.signalrPort = port;
            reglages.Save();}

        class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseCors(CorsOptions.AllowAll);
                app.MapSignalR();
            }
        }
        /// <summary>
        /// Echoes messages sent using the Send message by calling the
        /// addMessage method on the client. Also reports to the console
        /// when clients connect and disconnect.
        /// </summary>
        public class MyHub : Hub
        {
            public void Send(string name, string message)
            {
                Clients.All.addMessage(name, message);
            }
            public override Task OnConnected()
            {
                FrmMain frm1 = new FrmMain();
                frm1.OutputText("Client connected: " + Context.ConnectionId);
                return base.OnConnected();
            }
            public override Task OnDisconnected(bool stopCalled)
            {
                FrmMain frm1 = new FrmMain();
                frm1.OutputText("Client disconnected: " + Context.ConnectionId);
                return base.OnDisconnected(stopCalled);
            }
        }

        private void btnStart_ItemClick(object sender, ItemClickEventArgs e)
        {

            Task.Run(() => StartServer());
        }

        private void btnStop_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SignalR != null)
            {
                SignalR.Dispose();
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                OutputText("Server Stopped @ " + ServerURI);
                ledSignalR.Image = Properties.Resources.led_red;
            }

        }

        private void btnVerifPort_Click(object sender, EventArgs e)
        {
            int port;
            Int32.TryParse(txtPortSignalR.Text, out port);

            if (txtPortSignalR.Text.Length != 0)
            {

                if (PortInUse(port))
                {
                    DialogResult result;
                    result = MessageBox.Show(
                        "Desolé, ce port est dejà utilisé. Souhaitez-vous generer un port automatiquement?",
                        "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (result == DialogResult.Yes)
                    {
                        TcpListener l = new TcpListener(IPAddress.Loopback, 0);
                        l.Start();
                        txtPortSignalR.Text = ((IPEndPoint) l.LocalEndpoint).Port.ToString();
                        l.Stop();

                    }
                    else
                    {
                        txtPortSignalR.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Le port : "+ port + " est disponible", "Succès", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Le port de connexion ne peut être nul", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logOn_Click(object sender, EventArgs e)
        {
            int port;
            Int32.TryParse(txtPortSignalR.Text, out port);

            if (checkAutoLogin.Checked &&
                (String.IsNullOrEmpty(txtUsername.Text) 
                || String.IsNullOrEmpty(txtPassword.Text)))
            {
                MessageBox.Show(
                    "Vous devez saisir vos paramètres d'identification ou decochez l'option de memorisation","Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string username;
            string password;
            string browserPath = GetBrowserPath();
            if (browserPath == string.Empty)
                browserPath = "iexplore";
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(browserPath);

            if (checkAutoLogin.Checked)
            {
                username = this.username.Encrypt(reglages.username);
                password = this.password.Encrypt(reglages.password);
            }
            else
            {
                username = this.username.Encrypt(txtUsername.Text);
                password = this.password.Encrypt(txtPassword.Text);
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (onPostInfoClick(port, username, password))
                {
                    MessageBox.Show("Vous avez été authentifié avec succès...", "Succès", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Echec authentification...", "Oops", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                process.StartInfo.Arguments = "\"" + weblink.Text + "\"";
                process.Start();
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    "Erreur lors du lancement de l'application, prière de reesayer ou de lancer le navigateur directement... ERREUR : " + exception.Message,
                    "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private bool onPostInfoClick(int port, string username, string password)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ASCIIEncoding encoding = new ASCIIEncoding();
                string postData = "u=" + username;
                postData += "&k=" + password;
                postData += "&p=" + port;
                byte[] data = encoding.GetBytes(postData);

                //Prepare web request...
                HttpWebRequest myRequest =
                    (HttpWebRequest) WebRequest.Create(weblink.Text + "Settings/CookiesSet");
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencode";
                myRequest.ContentLength = data.Length;
                Stream newStream = myRequest.GetRequestStream();
                // Send the data
                newStream.Write(data, 0, data.Length);
                newStream.Close();

                var response = (HttpWebResponse) myRequest.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return Convert.ToBoolean(responseString);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;}

        }

        private static string GetBrowserPath()
        {
            string browserPath = string.Empty;
            RegistryKey browserKey = null;

            try
            {
                //Read default browser path from Win XP registry key
                browserKey = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);

                //If browser path wasn't found, try Win Vista (and newer) registry key
                if (browserKey == null)
                {
                    browserKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http", false); ;
                }

                //If browser path was found, clean it
                if (browserKey != null)
                {
                    //Remove quotation marks
                    browserPath = (browserKey.GetValue(null) as string).ToLower().Replace("\"", "");

                    //Cut off optional parameters
                    if (!browserPath.EndsWith("exe"))
                    {
                        browserPath = browserPath.Substring(0, browserPath.LastIndexOf(".exe") + 4);
                    }

                    //Close registry key
                    browserKey.Close();
                }
            }
            catch
            {
                //Return empty string, if no path was found
                return string.Empty;
            }
            //Return default browsers path
            return browserPath;
        }

        public void btnWeb_ItemClick(object sender, ItemClickEventArgs e)
        {

            int port;
            string username = "noLoginCase";
            string password = "noLoginCase";

            Int32.TryParse(txtPortSignalR.Text, out port);
            string browserPath = GetBrowserPath();
            if (browserPath == string.Empty)
                browserPath = "iexplore";
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(browserPath);

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (onPostInfoClick(port, username, password))
                {
                    MessageBox.Show("Port configurer avec succès", "Succès", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Echec configuration du port de communication...", "Oops", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                process.StartInfo.Arguments = "\"" + weblink.Text + "\"";
                process.Start();
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    "Erreur lors du lancement de l'application, prière de reessayer ou de lancer le navigateur directement... ERREUR : " + exception.Message,
                    "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }


        }
        public void checkAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAutoLogin.Checked)
            {
                reglages.username = txtUsername.Text;
                reglages.password = txtPassword.Text;
                reglages.autologin = checkAutoLogin.Checked;
                reglages.Save();
            }
            else
            {
                reglages.username = "";
                reglages.password = "";
                reglages.autologin = checkAutoLogin.Checked;
                reglages.Save();
            }
        }
    }

}

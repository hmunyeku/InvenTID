using Symbol.RFID3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvenTID
{
    public partial class frmCapabilities : DevExpress.XtraEditors.XtraForm
    {
        public ReaderCapabilities capSettings; 

        public frmCapabilities()
        {
            InitializeComponent();
        }

        private void frmCapabilities_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadSettings()
        {
            txtModelName.Text = capSettings.ModelName;
            txtSerialNumber.Text = capSettings.SerialNumber;
            txtManufactureName.Text = capSettings.ManufactureName;
            txtManufactureDate.Text =  capSettings.ManufacturingDate;

            lstPowerLevels.Items.Clear();
            foreach (int n in capSettings.TransmitPowerLevelValues)
            {
                lstPowerLevels.Items.Add(n.ToString());
            }
            txtNumAntennasSupported.Text = String.Format("{0}",capSettings.NumAntennaSupported);

            chkHoppingEnabled.Checked = capSettings.IsHoppingEnabled;
            chkTagLocSupported.Checked = capSettings.IsTagLocationingSupported;
            chkTagEventRptSupported.Checked = capSettings.IsTagEventReportingSupported;
        }
    }
}

using Symbol.RFID3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvenTID
{
    public partial class frmSingulation : DevExpress.XtraEditors.XtraForm
    {
        public RFIDReader curReader= null;
        private FrmMain m_AppForm = null;

        public string Result { get; internal set; }

        public frmSingulation()
        {
            InitializeComponent();

        }

        public frmSingulation(FrmMain appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
        }


        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSingulation_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            try
            {
                ushort[] antID = curReader.Config.Antennas.AvailableAntennas;

                foreach (ushort n in antID)
                {
                    cboAntennaIDs.Items.Add(n.ToString());
                }
                ushort curAntennaID = antID[0];
                cboAntennaIDs.Text = curAntennaID.ToString();
                cboSession.Items.AddRange(Enum.GetNames(typeof(SESSION)));

                Antennas.SingulationControl singulationControl = curReader.Config.Antennas[curAntennaID].GetSingulationControl();
                LoadSingulationSettings(singulationControl);
            }
            catch(Exception e1)
            {
                m_AppForm.OutputText("Error loading singulationControl settings. "+ e1.ToString());

            }
        }

        private void LoadSingulationSettings(Antennas.SingulationControl singulationControl)
        {
            if (singulationControl != null)
            {
                cboSession.Text = singulationControl.Session.ToString();
                txtPopulation.Text = singulationControl.TagPopulation.ToString();
                txtTagTransitTime.Text = singulationControl.TagTransitTime.ToString();

                Debug.Print("GetSingulation :  Session  = [" + cboSession.Text + "]   TagPopulation : " + txtPopulation.Text);
            }
            else
            {
                m_AppForm.OutputText("Error loading settings, singulationControl  object not found.");
            }
        }


        private void SaveSettings()
        {
            try
            {
                ushort curAntennaID = ushort.Parse(cboAntennaIDs.Text);
                Antennas.SingulationControl singulationControl = curReader.Config.Antennas[curAntennaID].GetSingulationControl();
                if (singulationControl != null)
                {
                    singulationControl.Session = GetSession(cboSession.Text);
                    ushort population = 30;
                    if (ushort.TryParse(txtPopulation.Text, out population))
                    {
                        singulationControl.TagPopulation = population;
                        Debug.Print("SetSingulation :  Session  = [" + singulationControl.Session + "]   TagPopulation : " + singulationControl.TagPopulation.ToString());
                        curReader.Config.Antennas[curAntennaID].SetSingulationControl(singulationControl);
                        Result = "SetSingulation :  Session  = [" + singulationControl.Session + "]   TagPopulation : " + singulationControl.TagPopulation.ToString();
                    }
                    else
                    {
                        m_AppForm.OutputText("Error saving settings, singulationControl  incorrect tag population : " + txtPopulation.Text);
                    }

                }
                else
                {
                    m_AppForm.OutputText("Error saving settings, singulationControl  object not found.");
                }
            }
            catch (Exception e1)
            {
                m_AppForm.OutputText("Error saving singulationControl settings. " + e1.ToString());
            }
        }

        private SESSION GetSession(string text)
        {
            if (text.Equals("SESSION_S0"))
            {
                return SESSION.SESSION_S0;
            }
            if (text.Equals("SESSION_S1"))
            {
                return SESSION.SESSION_S1;
            }
            if (text.Equals("SESSION_S2"))
            {
                return SESSION.SESSION_S2;
            }
            if (text.Equals("SESSION_S3"))
            {
                return SESSION.SESSION_S3;
            }
            return SESSION.SESSION_S1;
        }

   
    }
}

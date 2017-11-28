using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.RFID3;

namespace InvenTID
{
    public partial class TriggersForm : Form
    {
        private FrmMain m_AppForm = null;
        public  static Symbol.RFID3.TriggerInfo m_TriggerInfo = null;

        public TriggersForm(FrmMain appForm)
        {
            InitializeComponent();
            m_AppForm = appForm;
        }

        private void ClearStartGroupBox()
        {
            this.startGroupBox.Controls.Remove(this.gpiParamsGroupBox);
            this.startGroupBox.Controls.Remove(this.periodicGroupBox);
            this.startGroupBox.Controls.Remove(this.startHandHeldTriggerGroupBox);
        }

        private void startTriggerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearStartGroupBox();
            if (startTriggerType_CB.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE)
            {

            }
            else if (startTriggerType_CB.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_PERIODIC)
            {
                this.startGroupBox.Controls.Add(this.periodicGroupBox);
            }
            else if (startTriggerType_CB.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_HANDHELD)
            {
                this.startGroupBox.Controls.Add(this.startHandHeldTriggerGroupBox);
            }
        }

        private void ClearStopGroupBox()
        {
            this.stopGroupBox.Controls.Remove(this.durationGB);
            this.stopGroupBox.Controls.Remove(this.GPITimeoutGB);
            this.stopGroupBox.Controls.Remove(this.tagObservationGB);
            this.stopGroupBox.Controls.Remove(this.nAttemptsGB);
            this.stopGroupBox.Controls.Remove(this.stopHandHeldTriggerGroupBox);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearStopGroupBox();
            if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE)
            {

            }
            else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION)
            {
                this.stopGroupBox.Controls.Add(this.durationGB);
            }
            else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_TAG_OBSERVATION_WITH_TIMEOUT)
            {
                this.stopGroupBox.Controls.Add(this.tagObservationGB);
            }
            else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_N_ATTEMPTS_WITH_TIMEOUT)
            {
                this.stopGroupBox.Controls.Add(this.nAttemptsGB);
            }
            else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_HANDHELD_WITH_TIMEOUT)
            {
                this.stopGroupBox.Controls.Add(this.stopHandHeldTriggerGroupBox);
            }


        }
        private void SaveTriggerParams()
        {
            try
            {
                if (startTriggerType_CB.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE)
                {
                    m_TriggerInfo.StartTrigger.Type = START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE;
                }
                else if (startTriggerType_CB.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_PERIODIC)
                {
                    m_TriggerInfo.StartTrigger.Type = START_TRIGGER_TYPE.START_TRIGGER_TYPE_PERIODIC;

                    if (!String.IsNullOrEmpty((startPeriod_TB.Text)))
                        m_TriggerInfo.StartTrigger.Periodic.Period = uint.Parse(startPeriod_TB.Text);
                }
                else if (startTriggerType_CB.SelectedIndex == (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_HANDHELD)
                {
                    m_TriggerInfo.StartTrigger.Type = START_TRIGGER_TYPE.START_TRIGGER_TYPE_HANDHELD;

                    if (startTriggerPressed_CB.Checked)
                        m_TriggerInfo.StartTrigger.Handheld.HandheldEvent = HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_PRESSED;
                    else if (startTriggerReleased_CB.Checked)
                        m_TriggerInfo.StartTrigger.Handheld.HandheldEvent = HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_RELEASED;
                }

                if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE)
                {
                    m_TriggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE;
                }
                else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION)
                {
                    m_TriggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION;
                    if (!String.IsNullOrEmpty(this.stopDuration_TB.Text))
                        m_TriggerInfo.StopTrigger.Duration = uint.Parse(this.stopDuration_TB.Text);
                }
                else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_TAG_OBSERVATION_WITH_TIMEOUT)
                {
                    m_TriggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_TAG_OBSERVATION_WITH_TIMEOUT;
                    if (!String.IsNullOrEmpty(stopTagObservation_TB.Text))
                        m_TriggerInfo.StopTrigger.TagObservation.N = ushort.Parse(stopTagObservation_TB.Text);
                    if (!String.IsNullOrEmpty(stopTriggerTagOb_TB.Text))
                        m_TriggerInfo.StopTrigger.TagObservation.Timeout = uint.Parse(stopTriggerTagOb_TB.Text);
                }
                else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_N_ATTEMPTS_WITH_TIMEOUT)
                {
                    m_TriggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_N_ATTEMPTS_WITH_TIMEOUT;
                    if (!String.IsNullOrEmpty(stopNumAttempt_TB.Text))
                        m_TriggerInfo.StopTrigger.NumAttempts.N = ushort.Parse(stopNumAttempt_TB.Text);
                    if (!String.IsNullOrEmpty(stopTriggerNAttTimeOut_TB.Text))
                        m_TriggerInfo.StopTrigger.NumAttempts.Timeout = uint.Parse(stopTriggerNAttTimeOut_TB.Text);
                }
                else if (stopTriggerType_CB.SelectedIndex == (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_HANDHELD_WITH_TIMEOUT)
                {
                    m_TriggerInfo.StopTrigger.Type = STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_HANDHELD_WITH_TIMEOUT;
                    if (!String.IsNullOrEmpty(handHeldTriggerTimeout_TB.Text))
                        m_TriggerInfo.StopTrigger.Handheld.Timeout = uint.Parse(handHeldTriggerTimeout_TB.Text);

                    if (stopTriggerPressed_CB.Checked)
                        m_TriggerInfo.StopTrigger.Handheld.HandheldEvent = HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_PRESSED;
                    else if (stopTriggerReleased_CB.Checked)
                        m_TriggerInfo.StopTrigger.Handheld.HandheldEvent = HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_RELEASED;
                }
            }
            catch(Exception e1)
            {
                m_AppForm.OutputText("Error saving TriggerParams. " + e1.ToString());
            }
       }

        private void LoadTriggerParams()
        {
            try
            {

                if (m_TriggerInfo.StartTrigger.Type == START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE)
                {
                    startTriggerType_CB.SelectedIndex = (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_IMMEDIATE;
                }
                else if (m_TriggerInfo.StartTrigger.Type == START_TRIGGER_TYPE.START_TRIGGER_TYPE_PERIODIC)
                {
                    startTriggerType_CB.SelectedIndex = (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_PERIODIC;

                    startPeriod_TB.Text = m_TriggerInfo.StartTrigger.Periodic.Period.ToString();
                }
                else if (m_TriggerInfo.StartTrigger.Type == START_TRIGGER_TYPE.START_TRIGGER_TYPE_HANDHELD)
                {
                    startTriggerType_CB.SelectedIndex = (int)START_TRIGGER_TYPE.START_TRIGGER_TYPE_HANDHELD;

                    if (m_TriggerInfo.StartTrigger.Handheld.HandheldEvent == HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_PRESSED)
                    {
                        startTriggerPressed_CB.Checked = true;
                        startTriggerReleased_CB.Checked = false;
                    }
                    else if (m_TriggerInfo.StartTrigger.Handheld.HandheldEvent == HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_RELEASED)
                    {
                        startTriggerPressed_CB.Checked = false;
                        startTriggerReleased_CB.Checked = true;
                    }

                }

                if (m_TriggerInfo.StopTrigger.Type == STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE)
                {
                    stopTriggerType_CB.SelectedIndex = (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_IMMEDIATE;
                }
                else if (m_TriggerInfo.StopTrigger.Type == STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION)
                {
                    stopTriggerType_CB.SelectedIndex = (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_DURATION;
                    this.stopDuration_TB.Text = m_TriggerInfo.StopTrigger.Duration.ToString();
                }
                else if (m_TriggerInfo.StopTrigger.Type == STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_TAG_OBSERVATION_WITH_TIMEOUT)
                {
                    stopTriggerType_CB.SelectedIndex = (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_TAG_OBSERVATION_WITH_TIMEOUT;
                    stopTagObservation_TB.Text = m_TriggerInfo.StopTrigger.TagObservation.N.ToString();
                    stopTriggerTagOb_TB.Text = m_TriggerInfo.StopTrigger.TagObservation.Timeout.ToString();
                }
                else if (m_TriggerInfo.StopTrigger.Type == STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_N_ATTEMPTS_WITH_TIMEOUT)
                {
                    stopTriggerType_CB.SelectedIndex = (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_N_ATTEMPTS_WITH_TIMEOUT;
                    stopNumAttempt_TB.Text = m_TriggerInfo.StopTrigger.NumAttempts.N.ToString();
                    stopTriggerNAttTimeOut_TB.Text = m_TriggerInfo.StopTrigger.NumAttempts.Timeout.ToString();
                }
                else if (m_TriggerInfo.StopTrigger.Type == STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_HANDHELD_WITH_TIMEOUT)
                {

                    stopTriggerType_CB.SelectedIndex = (int)STOP_TRIGGER_TYPE.STOP_TRIGGER_TYPE_HANDHELD_WITH_TIMEOUT;
                    handHeldTriggerTimeout_TB.Text = m_TriggerInfo.StopTrigger.Handheld.Timeout.ToString();

                    if (m_TriggerInfo.StopTrigger.Handheld.HandheldEvent == HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_PRESSED)
                    {
                        stopTriggerPressed_CB.Checked = true;
                        stopTriggerReleased_CB.Checked = false;
                    }
                    else if (m_TriggerInfo.StopTrigger.Handheld.HandheldEvent == HANDHELD_TRIGGER_EVENT_TYPE.HANDHELD_TRIGGER_RELEASED)
                    {
                        stopTriggerPressed_CB.Checked = false;
                        stopTriggerReleased_CB.Checked = true;

                    }
                }
            }
            catch (Exception e1)
            {
                m_AppForm.OutputText("Error loading TriggerParams. " + e1.ToString());
            }
        }

        private void antInfoApplyButton_Click(object sender, EventArgs e)
        {
            SaveTriggerParams();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Triggers_Load(object sender, EventArgs e)
        {
            startPeriod_TB.Text = "1";
            handHeldTriggerTimeout_TB.Text = "0";
            LoadTriggerParams();
        }
     
        void stopTriggerReleased_CB_Click(object sender, System.EventArgs e)
        {
            this.stopTriggerPressed_CB.Checked = false;
        }

        void stopTriggerPressed_CB_Click(object sender, System.EventArgs e)
        {
            this.stopTriggerReleased_CB.Checked = false;
        }

        void startTriggerPressed_CB_Click(object sender, System.EventArgs e)
        {
            this.startTriggerReleased_CB.Checked = false;
        }

        void startTriggerReleased_CB_Click(object sender, System.EventArgs e)
        {
            this.startTriggerPressed_CB.Checked = false;
        }
    }
}
namespace InvenTID
{
    partial class frmSingulation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSLFlag = new System.Windows.Forms.ComboBox();
            this.cboInventoryState = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkStateAware = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTagTransitTime = new System.Windows.Forms.TextBox();
            this.cboAntennaIDs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSession = new System.Windows.Forms.ComboBox();
            this.lblPopulation = new System.Windows.Forms.Label();
            this.lblSession = new System.Windows.Forms.Label();
            this.txtPopulation = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtTagTransitTime);
            this.groupBox2.Controls.Add(this.cboAntennaIDs);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboSession);
            this.groupBox2.Controls.Add(this.lblPopulation);
            this.groupBox2.Controls.Add(this.lblSession);
            this.groupBox2.Controls.Add(this.txtPopulation);
            this.groupBox2.Location = new System.Drawing.Point(8, 9);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(279, 262);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Singulation";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboSLFlag);
            this.groupBox1.Controls.Add(this.cboInventoryState);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkStateAware);
            this.groupBox1.Location = new System.Drawing.Point(11, 128);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(252, 112);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            // 
            // cboSLFlag
            // 
            this.cboSLFlag.Enabled = false;
            this.cboSLFlag.FormattingEnabled = true;
            this.cboSLFlag.Location = new System.Drawing.Point(105, 77);
            this.cboSLFlag.Margin = new System.Windows.Forms.Padding(2);
            this.cboSLFlag.Name = "cboSLFlag";
            this.cboSLFlag.Size = new System.Drawing.Size(133, 21);
            this.cboSLFlag.TabIndex = 41;
            // 
            // cboInventoryState
            // 
            this.cboInventoryState.Enabled = false;
            this.cboInventoryState.FormattingEnabled = true;
            this.cboInventoryState.Location = new System.Drawing.Point(105, 49);
            this.cboInventoryState.Margin = new System.Windows.Forms.Padding(2);
            this.cboInventoryState.Name = "cboInventoryState";
            this.cboInventoryState.Size = new System.Drawing.Size(133, 21);
            this.cboInventoryState.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "SL Flag";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Inventory State";
            // 
            // chkStateAware
            // 
            this.chkStateAware.AutoSize = true;
            this.chkStateAware.Enabled = false;
            this.chkStateAware.Location = new System.Drawing.Point(13, 17);
            this.chkStateAware.Margin = new System.Windows.Forms.Padding(2);
            this.chkStateAware.Name = "chkStateAware";
            this.chkStateAware.Size = new System.Drawing.Size(199, 17);
            this.chkStateAware.TabIndex = 37;
            this.chkStateAware.Text = "State Aware Singulation Parameters";
            this.chkStateAware.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Tag Transit Time";
            // 
            // txtTagTransitTime
            // 
            this.txtTagTransitTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTagTransitTime.Enabled = false;
            this.txtTagTransitTime.Location = new System.Drawing.Point(100, 98);
            this.txtTagTransitTime.Name = "txtTagTransitTime";
            this.txtTagTransitTime.Size = new System.Drawing.Size(164, 21);
            this.txtTagTransitTime.TabIndex = 35;
            // 
            // cboAntennaIDs
            // 
            this.cboAntennaIDs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAntennaIDs.Enabled = false;
            this.cboAntennaIDs.FormattingEnabled = true;
            this.cboAntennaIDs.Location = new System.Drawing.Point(100, 25);
            this.cboAntennaIDs.Margin = new System.Windows.Forms.Padding(2);
            this.cboAntennaIDs.Name = "cboAntennaIDs";
            this.cboAntennaIDs.Size = new System.Drawing.Size(164, 21);
            this.cboAntennaIDs.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Antenna ID";
            // 
            // cboSession
            // 
            this.cboSession.FormattingEnabled = true;
            this.cboSession.Location = new System.Drawing.Point(100, 48);
            this.cboSession.Margin = new System.Windows.Forms.Padding(2);
            this.cboSession.Name = "cboSession";
            this.cboSession.Size = new System.Drawing.Size(164, 21);
            this.cboSession.TabIndex = 32;
            // 
            // lblPopulation
            // 
            this.lblPopulation.AutoSize = true;
            this.lblPopulation.Location = new System.Drawing.Point(7, 74);
            this.lblPopulation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPopulation.Name = "lblPopulation";
            this.lblPopulation.Size = new System.Drawing.Size(78, 13);
            this.lblPopulation.TabIndex = 31;
            this.lblPopulation.Text = "Tag Population";
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = true;
            this.lblSession.Location = new System.Drawing.Point(7, 50);
            this.lblSession.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(43, 13);
            this.lblSession.TabIndex = 30;
            this.lblSession.Text = "Session";
            // 
            // txtPopulation
            // 
            this.txtPopulation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPopulation.Location = new System.Drawing.Point(100, 74);
            this.txtPopulation.Name = "txtPopulation";
            this.txtPopulation.Size = new System.Drawing.Size(164, 21);
            this.txtPopulation.TabIndex = 29;
            this.txtPopulation.Text = "100";
            // 
            // btnApply
            // 
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.Location = new System.Drawing.Point(193, 280);
            this.btnApply.Margin = new System.Windows.Forms.Padding(2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(89, 30);
            this.btnApply.TabIndex = 36;
            this.btnApply.Text = "OK";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(95, 280);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 30);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            // 
            // frmSingulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 319);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox2);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSingulation";
            this.Text = "Singulation";
            this.Load += new System.EventHandler(this.frmSingulation_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboSLFlag;
        private System.Windows.Forms.ComboBox cboInventoryState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkStateAware;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTagTransitTime;
        private System.Windows.Forms.ComboBox cboAntennaIDs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSession;
        private System.Windows.Forms.Label lblPopulation;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.TextBox txtPopulation;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}
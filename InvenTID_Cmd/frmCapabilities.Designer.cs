namespace InvenTID
{
    partial class frmCapabilities
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
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.txtNumAntennasSupported = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstPowerLevels = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtManufactureName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtManufactureDate = new System.Windows.Forms.TextBox();
            this.chkTagLocSupported = new System.Windows.Forms.CheckBox();
            this.chkHoppingEnabled = new System.Windows.Forms.CheckBox();
            this.chkTagEventRptSupported = new System.Windows.Forms.CheckBox();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(236, 194);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 30);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "&Fermer";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fabricant";
            // 
            // txtModelName
            // 
            this.txtModelName.Enabled = false;
            this.txtModelName.Location = new System.Drawing.Point(64, 8);
            this.txtModelName.Margin = new System.Windows.Forms.Padding(2);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.ReadOnly = true;
            this.txtModelName.Size = new System.Drawing.Size(325, 21);
            this.txtModelName.TabIndex = 1;
            // 
            // txtNumAntennasSupported
            // 
            this.txtNumAntennasSupported.Enabled = false;
            this.txtNumAntennasSupported.Location = new System.Drawing.Point(305, 80);
            this.txtNumAntennasSupported.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumAntennasSupported.Name = "txtNumAntennasSupported";
            this.txtNumAntennasSupported.ReadOnly = true;
            this.txtNumAntennasSupported.Size = new System.Drawing.Size(85, 21);
            this.txtNumAntennasSupported.TabIndex = 3;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(256, 133);
            this.lbl1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(99, 13);
            this.lbl1.TabIndex = 4;
            this.lbl1.Text = "Location supportée";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Puissance de transmission";
            // 
            // lstPowerLevels
            // 
            this.lstPowerLevels.FormattingEnabled = true;
            this.lstPowerLevels.Location = new System.Drawing.Point(10, 129);
            this.lstPowerLevels.Margin = new System.Windows.Forms.Padding(2);
            this.lstPowerLevels.Name = "lstPowerLevels";
            this.lstPowerLevels.Size = new System.Drawing.Size(222, 95);
            this.lstPowerLevels.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 171);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Hopping Activé";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 152);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Journal Evenement Supporté";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre d\'antenne supporté";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 35);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Produit";
            // 
            // txtManufactureName
            // 
            this.txtManufactureName.Enabled = false;
            this.txtManufactureName.Location = new System.Drawing.Point(64, 32);
            this.txtManufactureName.Margin = new System.Windows.Forms.Padding(2);
            this.txtManufactureName.Name = "txtManufactureName";
            this.txtManufactureName.ReadOnly = true;
            this.txtManufactureName.Size = new System.Drawing.Size(325, 21);
            this.txtManufactureName.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 59);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "SN";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Enabled = false;
            this.txtSerialNumber.Location = new System.Drawing.Point(64, 56);
            this.txtSerialNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.ReadOnly = true;
            this.txtSerialNumber.Size = new System.Drawing.Size(325, 21);
            this.txtSerialNumber.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 83);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Date fab.";
            // 
            // txtManufactureDate
            // 
            this.txtManufactureDate.Enabled = false;
            this.txtManufactureDate.Location = new System.Drawing.Point(64, 80);
            this.txtManufactureDate.Margin = new System.Windows.Forms.Padding(2);
            this.txtManufactureDate.Name = "txtManufactureDate";
            this.txtManufactureDate.ReadOnly = true;
            this.txtManufactureDate.Size = new System.Drawing.Size(83, 21);
            this.txtManufactureDate.TabIndex = 17;
            // 
            // chkTagLocSupported
            // 
            this.chkTagLocSupported.AutoSize = true;
            this.chkTagLocSupported.Enabled = false;
            this.chkTagLocSupported.Location = new System.Drawing.Point(239, 133);
            this.chkTagLocSupported.Margin = new System.Windows.Forms.Padding(2);
            this.chkTagLocSupported.Name = "chkTagLocSupported";
            this.chkTagLocSupported.Size = new System.Drawing.Size(15, 14);
            this.chkTagLocSupported.TabIndex = 41;
            this.chkTagLocSupported.UseVisualStyleBackColor = true;
            // 
            // chkHoppingEnabled
            // 
            this.chkHoppingEnabled.AutoSize = true;
            this.chkHoppingEnabled.Enabled = false;
            this.chkHoppingEnabled.Location = new System.Drawing.Point(239, 170);
            this.chkHoppingEnabled.Margin = new System.Windows.Forms.Padding(2);
            this.chkHoppingEnabled.Name = "chkHoppingEnabled";
            this.chkHoppingEnabled.Size = new System.Drawing.Size(15, 14);
            this.chkHoppingEnabled.TabIndex = 40;
            this.chkHoppingEnabled.UseVisualStyleBackColor = true;
            // 
            // chkTagEventRptSupported
            // 
            this.chkTagEventRptSupported.AutoSize = true;
            this.chkTagEventRptSupported.Enabled = false;
            this.chkTagEventRptSupported.Location = new System.Drawing.Point(239, 151);
            this.chkTagEventRptSupported.Margin = new System.Windows.Forms.Padding(2);
            this.chkTagEventRptSupported.Name = "chkTagEventRptSupported";
            this.chkTagEventRptSupported.Size = new System.Drawing.Size(15, 14);
            this.chkTagEventRptSupported.TabIndex = 39;
            this.chkTagEventRptSupported.UseVisualStyleBackColor = true;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            // 
            // frmCapabilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 234);
            this.Controls.Add(this.chkTagLocSupported);
            this.Controls.Add(this.chkHoppingEnabled);
            this.Controls.Add(this.chkTagEventRptSupported);
            this.Controls.Add(this.lstPowerLevels);
            this.Controls.Add(this.txtManufactureDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.txtModelName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtManufactureName);
            this.Controls.Add(this.txtNumAntennasSupported);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCapabilities";
            this.Text = "Fonctionnalités";
            this.Load += new System.EventHandler(this.frmCapabilities_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.TextBox txtNumAntennasSupported;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstPowerLevels;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtManufactureName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtManufactureDate;
        private System.Windows.Forms.CheckBox chkTagLocSupported;
        private System.Windows.Forms.CheckBox chkHoppingEnabled;
        private System.Windows.Forms.CheckBox chkTagEventRptSupported;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}
namespace BandDecoderProgrammer
{
    partial class MainForm
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
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.selectComPortBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.cfgTabControl = new System.Windows.Forms.TabControl();
            this.antTabPage = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.antBandTabPage = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bandCfgTabPage = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.optionsTabPage = new System.Windows.Forms.TabPage();
            this.bandChangeDelayBox = new System.Windows.Forms.NumericUpDown();
            this.bandOutDelayBox = new System.Windows.Forms.NumericUpDown();
            this.profileNameBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pttBandBlockBox = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.programButton = new System.Windows.Forms.Button();
            this.cfgTabControl.SuspendLayout();
            this.antTabPage.SuspendLayout();
            this.antBandTabPage.SuspendLayout();
            this.bandCfgTabPage.SuspendLayout();
            this.optionsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bandChangeDelayBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandOutDelayBox)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.StopBits = System.IO.Ports.StopBits.Two;
            this.serialPort.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.serialPort_ErrorReceived);
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // selectComPortBox
            // 
            this.selectComPortBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectComPortBox.FormattingEnabled = true;
            this.selectComPortBox.Location = new System.Drawing.Point(76, 9);
            this.selectComPortBox.Name = "selectComPortBox";
            this.selectComPortBox.Size = new System.Drawing.Size(102, 21);
            this.selectComPortBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serial Port:";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(184, 8);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status:";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.statusLabel.Location = new System.Drawing.Point(395, 12);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 13);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "offline";
            // 
            // cfgTabControl
            // 
            this.cfgTabControl.Controls.Add(this.antTabPage);
            this.cfgTabControl.Controls.Add(this.antBandTabPage);
            this.cfgTabControl.Controls.Add(this.bandCfgTabPage);
            this.cfgTabControl.Controls.Add(this.optionsTabPage);
            this.cfgTabControl.Location = new System.Drawing.Point(13, 53);
            this.cfgTabControl.Name = "cfgTabControl";
            this.cfgTabControl.SelectedIndex = 0;
            this.cfgTabControl.Size = new System.Drawing.Size(530, 394);
            this.cfgTabControl.TabIndex = 5;
            this.cfgTabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.cfgTabControl_Selecting);
            // 
            // antTabPage
            // 
            this.antTabPage.Controls.Add(this.label6);
            this.antTabPage.Controls.Add(this.label5);
            this.antTabPage.Controls.Add(this.label4);
            this.antTabPage.Location = new System.Drawing.Point(4, 22);
            this.antTabPage.Name = "antTabPage";
            this.antTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.antTabPage.Size = new System.Drawing.Size(522, 368);
            this.antTabPage.TabIndex = 0;
            this.antTabPage.Text = "Antennas config";
            this.antTabPage.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(332, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Output bits config";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Long name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Short name";
            // 
            // antBandTabPage
            // 
            this.antBandTabPage.Controls.Add(this.label9);
            this.antBandTabPage.Controls.Add(this.label8);
            this.antBandTabPage.Controls.Add(this.label7);
            this.antBandTabPage.Controls.Add(this.label3);
            this.antBandTabPage.Location = new System.Drawing.Point(4, 22);
            this.antBandTabPage.Name = "antBandTabPage";
            this.antBandTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.antBandTabPage.Size = new System.Drawing.Size(522, 368);
            this.antBandTabPage.TabIndex = 1;
            this.antBandTabPage.Text = "Antenna per Band";
            this.antBandTabPage.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(330, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Antenna 3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(210, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Antenna 2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(90, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Antenna 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Band";
            // 
            // bandCfgTabPage
            // 
            this.bandCfgTabPage.Controls.Add(this.label11);
            this.bandCfgTabPage.Controls.Add(this.label10);
            this.bandCfgTabPage.Location = new System.Drawing.Point(4, 22);
            this.bandCfgTabPage.Name = "bandCfgTabPage";
            this.bandCfgTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.bandCfgTabPage.Size = new System.Drawing.Size(522, 368);
            this.bandCfgTabPage.TabIndex = 2;
            this.bandCfgTabPage.Text = "Configurable Band Out";
            this.bandCfgTabPage.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(120, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Output bits config";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Band";
            // 
            // optionsTabPage
            // 
            this.optionsTabPage.Controls.Add(this.bandChangeDelayBox);
            this.optionsTabPage.Controls.Add(this.bandOutDelayBox);
            this.optionsTabPage.Controls.Add(this.profileNameBox);
            this.optionsTabPage.Controls.Add(this.label14);
            this.optionsTabPage.Controls.Add(this.label13);
            this.optionsTabPage.Controls.Add(this.pttBandBlockBox);
            this.optionsTabPage.Controls.Add(this.label12);
            this.optionsTabPage.Location = new System.Drawing.Point(4, 22);
            this.optionsTabPage.Name = "optionsTabPage";
            this.optionsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.optionsTabPage.Size = new System.Drawing.Size(522, 368);
            this.optionsTabPage.TabIndex = 3;
            this.optionsTabPage.Text = "Options";
            this.optionsTabPage.UseVisualStyleBackColor = true;
            // 
            // bandChangeDelayBox
            // 
            this.bandChangeDelayBox.Enabled = false;
            this.bandChangeDelayBox.Location = new System.Drawing.Point(335, 82);
            this.bandChangeDelayBox.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.bandChangeDelayBox.Name = "bandChangeDelayBox";
            this.bandChangeDelayBox.Size = new System.Drawing.Size(50, 20);
            this.bandChangeDelayBox.TabIndex = 6;
            // 
            // bandOutDelayBox
            // 
            this.bandOutDelayBox.Enabled = false;
            this.bandOutDelayBox.Location = new System.Drawing.Point(335, 52);
            this.bandOutDelayBox.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.bandOutDelayBox.Name = "bandOutDelayBox";
            this.bandOutDelayBox.Size = new System.Drawing.Size(50, 20);
            this.bandOutDelayBox.TabIndex = 5;
            // 
            // profileNameBox
            // 
            this.profileNameBox.Enabled = false;
            this.profileNameBox.Location = new System.Drawing.Point(335, 22);
            this.profileNameBox.MaxLength = 6;
            this.profileNameBox.Name = "profileNameBox";
            this.profileNameBox.Size = new System.Drawing.Size(100, 20);
            this.profileNameBox.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(139, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(189, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "PTT lock time after band change (sec)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(37, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(291, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Configurable Band Out switch delay after band change (sec)";
            // 
            // pttBandBlockBox
            // 
            this.pttBandBlockBox.AutoSize = true;
            this.pttBandBlockBox.Enabled = false;
            this.pttBandBlockBox.Location = new System.Drawing.Point(40, 117);
            this.pttBandBlockBox.Name = "pttBandBlockBox";
            this.pttBandBlockBox.Size = new System.Drawing.Size(294, 17);
            this.pttBandBlockBox.TabIndex = 7;
            this.pttBandBlockBox.Text = "Block PTT when peer BandMaster is on the same band?";
            this.pttBandBlockBox.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(261, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Profile Name";
            // 
            // closeButton
            // 
            this.closeButton.Enabled = false;
            this.closeButton.Location = new System.Drawing.Point(265, 8);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 6;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // programButton
            // 
            this.programButton.Enabled = false;
            this.programButton.Location = new System.Drawing.Point(436, 7);
            this.programButton.Name = "programButton";
            this.programButton.Size = new System.Drawing.Size(75, 23);
            this.programButton.TabIndex = 7;
            this.programButton.Text = "Program";
            this.programButton.UseVisualStyleBackColor = true;
            this.programButton.Click += new System.EventHandler(this.programButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 498);
            this.Controls.Add(this.programButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.cfgTabControl);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectComPortBox);
            this.Name = "MainForm";
            this.Text = "BandMaster programmer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.cfgTabControl.ResumeLayout(false);
            this.antTabPage.ResumeLayout(false);
            this.antTabPage.PerformLayout();
            this.antBandTabPage.ResumeLayout(false);
            this.antBandTabPage.PerformLayout();
            this.bandCfgTabPage.ResumeLayout(false);
            this.bandCfgTabPage.PerformLayout();
            this.optionsTabPage.ResumeLayout(false);
            this.optionsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bandChangeDelayBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandOutDelayBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox selectComPortBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TabControl cfgTabControl;
        private System.Windows.Forms.TabPage antTabPage;
        private System.Windows.Forms.TabPage antBandTabPage;
        private System.Windows.Forms.TabPage bandCfgTabPage;
        private System.Windows.Forms.TabPage optionsTabPage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox pttBandBlockBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown bandChangeDelayBox;
        private System.Windows.Forms.NumericUpDown bandOutDelayBox;
        private System.Windows.Forms.TextBox profileNameBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button programButton;
    }
}


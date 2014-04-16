using BandMasterCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BandDecoderProgrammer
{
    public partial class MainForm : Form
    {
        private List<TextBox> antShortNamesList = new List<TextBox>();
        private List<TextBox> antLongNamesList = new List<TextBox>();
        private List<List<CheckBox>> antBitCfgList = new List<List<CheckBox>>();
        private List<List<ComboBox>> antPerBandList = new List<List<ComboBox>>();
        private List<List<CheckBox>> bandBitCfgList = new List<List<CheckBox>>();

        private BMCommunication BMComm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 1. Detect com ports
            selectComPortBox.Items.AddRange(SerialPort.GetPortNames());

            // 2. Add antennas page controls
            antTabPage.SuspendLayout();
            for (int j = Constants.ANT_CONFIG_BITS; j > 0; j--)
            {
                Label bitIdLabel = new Label();
                bitIdLabel.AutoSize = true;
                bitIdLabel.Location = new System.Drawing.Point(258 + (Constants.X_CKBOX_DIFF * (j - 1)), 30);
                bitIdLabel.Text = j + "";
                antTabPage.Controls.Add(bitIdLabel);
            }
            for (int i = 0; i < Constants.MAX_ANT_TOTAL; i++)
            {
                Label idLabel = new Label();
                idLabel.AutoSize = true;
                idLabel.Location = new System.Drawing.Point(10, 50 + (Constants.Y_DIFF * i));
                idLabel.Text = (i + 1) + ".";
                antTabPage.Controls.Add(idLabel);

                TextBox shortNameBox = new TextBox();
                shortNameBox.Enabled = false;
                shortNameBox.Location = new System.Drawing.Point(40, 47 + (Constants.Y_DIFF * i));
                shortNameBox.Size = new System.Drawing.Size(60, 20);
                shortNameBox.MaxLength = Constants.ANT_SHORT_NAME_LEN;
                shortNameBox.Text = "";
                antShortNamesList.Add(shortNameBox);
                antTabPage.Controls.Add(shortNameBox);

                TextBox longNameBox = new TextBox();
                longNameBox.Enabled = false;
                longNameBox.Location = new System.Drawing.Point(120, 47 + (Constants.Y_DIFF * i));
                longNameBox.Size = new System.Drawing.Size(100, 20);
                longNameBox.MaxLength = Constants.ANT_LONG_NAME_LEN;
                longNameBox.Text = "";
                antLongNamesList.Add(longNameBox);
                antTabPage.Controls.Add(longNameBox);

                antBitCfgList.Add(new List<CheckBox>());
                for (int j = 0; j < Constants.ANT_CONFIG_BITS; j++)
                {
                    CheckBox bitCfgBox = new CheckBox();
                    bitCfgBox.Enabled = false;
                    bitCfgBox.AutoSize = true;
                    bitCfgBox.Location = new System.Drawing.Point(260 + (Constants.X_CKBOX_DIFF * j), 50 + (Constants.Y_DIFF * i));
                    bitCfgBox.Text = "";
                    antBitCfgList[i].Add(bitCfgBox);
                    antTabPage.Controls.Add(bitCfgBox);
                }
            }
            antTabPage.ResumeLayout();

            // 3. Add antennas per band page controls
            antBandTabPage.SuspendLayout();
            for (int i = 0; i < Constants.BANDS_NUM; i++)
            {
                Label idLabel = new Label();
                idLabel.AutoSize = true;
                idLabel.Location = new System.Drawing.Point(10, 52 + (Constants.Y_DIFF * i));
                idLabel.Text = Constants.Bands[i];
                antBandTabPage.Controls.Add(idLabel);

                antPerBandList.Add(new List<ComboBox>());
                for (int j = 0; j < Constants.MAX_ANT_PER_BAND; j++)
                {
                    ComboBox antComboBox = new ComboBox();
                    antComboBox.SelectedIndexChanged += new System.EventHandler(this.antPerBand_SelectedIndexChanged);
                    antComboBox.Enabled = false;
                    antComboBox.Location = new System.Drawing.Point(70 + (Constants.X_COMBOBOX_DIFF * j), 50 + (Constants.Y_DIFF * i));
                    antComboBox.Size = new System.Drawing.Size(100, 21);
                    var idx = 1;
                    foreach (var longNameBox in antLongNamesList)
                    {
                        antComboBox.Items.Add(i + ". " + longNameBox.Text);
                        idx++;
                    }
                    antComboBox.Items.Add("- No Antenna");
                    antComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    // Select last one (no antenna)
                    antComboBox.SelectedIndex = antComboBox.Items.Count - 1;
                    antPerBandList[i].Add(antComboBox);
                    antBandTabPage.Controls.Add(antComboBox);
                }
            }
            antBandTabPage.ResumeLayout();

            // 4. Configurable per band bits
            bandCfgTabPage.SuspendLayout();
            for (int j = Constants.BAND_CONFIG_BITS; j > 0; j--)
            {
                Label bitIdLabel = new Label();
                bitIdLabel.AutoSize = true;
                bitIdLabel.Location = new System.Drawing.Point(68 + (Constants.X_CKBOX_DIFF * (j - 1)), 30);
                bitIdLabel.Text = j + "";
                bandCfgTabPage.Controls.Add(bitIdLabel);
            }
            for (int i = 0; i < Constants.BANDS_NUM; i++)
            {
                Label idLabel = new Label();
                idLabel.AutoSize = true;
                idLabel.Location = new System.Drawing.Point(10, 52 + (Constants.Y_DIFF * i));
                idLabel.Text = Constants.Bands[i];
                bandCfgTabPage.Controls.Add(idLabel);

                bandBitCfgList.Add(new List<CheckBox>());
                for (int j = 0; j < Constants.BAND_CONFIG_BITS; j++)
                {
                    CheckBox bitCfgBox = new CheckBox();
                    bitCfgBox.Enabled = false;
                    bitCfgBox.AutoSize = true;
                    bitCfgBox.Location = new System.Drawing.Point(70 + (Constants.X_CKBOX_DIFF * j), 50 + (Constants.Y_DIFF * i));
                    bitCfgBox.Text = "";
                    bandBitCfgList[i].Add(bitCfgBox);
                    bandCfgTabPage.Controls.Add(bitCfgBox);
                }

            }

            //
            //
            //DEBUG code - create fake Profileconfig and fill GUI with values
            //
            var cfg = new ProfileConfig
            {
                Name = "Fake",
                BandChangeDelay = 10,
                BandOutDelay = 2,
                SameBandPttLock = true,
                AntShortNames = new List<string> { "GP160", "4SQ", "DIPOL", "YAGI", "WARC", "STACK", "STACK", "STACK" },
                AntLongNames = new List<string> { "VERTICAL", "4 SQUARE", "DIPOL 40M", "YAGI 40M", "YAGI WARC", "STACK 20M", "STACK 15M", "STACK 10M" },
                AntOutCfg = new List<ushort> { Convert.ToUInt16("000000001", 2),
                                               Convert.ToUInt16("011110000001", 2),
                                               Convert.ToUInt16("000010000", 2),
                                               Convert.ToUInt16("000001101", 2), 
                                               Convert.ToUInt16("01111111", 2),
                                               Convert.ToUInt16("001000001", 2),
                                               Convert.ToUInt16("000001001", 2),
                                               Convert.ToUInt16("001000001", 2) },
                AntPerBand = new List<List<byte>> { new List<byte> { 0, 1, Constants.NO_ANTENNA }, 
                                                    new List<byte> { 2, Constants.NO_ANTENNA, Constants.NO_ANTENNA }, 
                                                    new List<byte> { 1, 2, 3 },
                                                    new List<byte> { 2, Constants.NO_ANTENNA, Constants.NO_ANTENNA },
                                                    new List<byte> { 0, 4, 8 },
                                                    new List<byte> { Constants.NO_ANTENNA, Constants.NO_ANTENNA, Constants.NO_ANTENNA },
                                                    new List<byte> { 0, 4, 8 },
                                                    new List<byte> { 0, 5, 7 } },
                BandOutCfg = new List<ushort> { Convert.ToUInt16("10101010", 2),
                                               Convert.ToUInt16("10000001", 2),
                                               Convert.ToUInt16("00010000", 2),
                                               Convert.ToUInt16("00001101", 2), 
                                               Convert.ToUInt16("01111111", 2),
                                               Convert.ToUInt16("1100001101", 2), 
                                               Convert.ToUInt16("01111111", 2),
                                               Convert.ToUInt16("1101000001", 2),
                                               Convert.ToUInt16("00001001", 2),
                                               Convert.ToUInt16("01000001", 2) },
            };

            fillUIFromConfig(cfg);
            var cfg2 = getconfigFromUI();

            var cfgStr = cfg.toHexStr();

            var cfg2Str = cfg2.toHexStr();

            var cfg3 = new ProfileConfig();
            cfg3.readFromHexStr(cfg2Str);
            fillUIFromConfig(cfg3);
            var cfg3Str = cfg3.toHexStr();
            
            if (cfg.toHexStr() != cfg3.toHexStr())
            {
               throw new Exception();
            }

            toggleConfigControls(true);

            //
            // DEBUG END
            //

            bandCfgTabPage.ResumeLayout();

        }

        private void cfgTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // Refresh antenna names in selectbox
            antBandTabPage.SuspendLayout();
            foreach (var comboList in antPerBandList)
            {
                foreach (var antComboBox in comboList)
                {
                    var selectedIdx = antComboBox.SelectedIndex;
                    var i = 1;
                    antComboBox.Items.Clear();
                    foreach (var longNameBox in antLongNamesList)
                    {
                        antComboBox.Items.Add(i + ". " + longNameBox.Text);
                        i++;
                    }
                    antComboBox.Items.Add("- No Antenna");
                    antComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    // Select previous one
                    antComboBox.SelectedIndex = selectedIdx;
                }
            }
            antBandTabPage.ResumeLayout();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                return;
            }
            if (selectComPortBox.Text == "")
            {
                MessageBox.Show("Please select COM port");
                return;
            }
            serialPort.PortName = selectComPortBox.Text;
            try
            {
                BMComm = new BMCommunication();
                serialPort.Open();
                serialPort.NewLine = "\n";
                selectComPortBox.Enabled = false;
                connectButton.Enabled = false;
                closeButton.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Error opening port " + serialPort.PortName);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                return;
            }
            try
            {
                selectComPortBox.Enabled = true;
                connectButton.Enabled = true;
                closeButton.Enabled = false;
                statusLabel.Text = "offline";
                statusLabel.ForeColor = Color.DarkRed;
                toggleConfigControls(false);
                serialPort.Close();
            }
            catch
            {
                MessageBox.Show("Error closing port " + serialPort.PortName);
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            BMComm.ParseReceivedData(indata);
            if (BMComm.BMConnected)
            {
                statusLabel.Invoke((MethodInvoker)(() =>
                        {
                            statusLabel.Text = "online";
                            statusLabel.ForeColor = Color.Green;
                            // Ask for BM configuration
                            serialPort.Write(BMComm.PrepareRequest(RequestType.GETCFG));                            
                        }
                    )
                );
            }
            if (BMComm.ConfigRead)
            {
                // Enable all controls
                toggleConfigControls(true);
            }
        }

        private void toggleConfigControls(bool enable)
        {
            foreach (var ctrl in antShortNamesList)
            {
                ctrl.Enabled = enable;
            }
            foreach (var ctrl in antLongNamesList)
            {
                ctrl.Enabled = enable;
            }
            foreach (var ctrlList in antBitCfgList)
            {
                foreach (var ctrl in ctrlList)
                {
                    ctrl.Enabled = enable;
                }
            }
            foreach (var ctrlList in antPerBandList)
            {
                foreach (var ctrl in ctrlList)
                {
                    ctrl.Enabled = enable;
                }
            }
            if (enable)
            {
                enableAntPerBandControls();
            }
            foreach (var ctrlList in bandBitCfgList)
            {
                foreach (var ctrl in ctrlList)
                {
                    ctrl.Enabled = enable;
                }
            }
            profileNameBox.Enabled = enable;
            bandOutDelayBox.Enabled = enable;
            bandChangeDelayBox.Enabled = enable;
            pttBandBlockBox.Enabled = enable;
        }

        private void enableAntPerBandControls()
        {
            foreach (var ctrlList in antPerBandList)
            {
                var enable = true;
                foreach (var ctrl in ctrlList)
                {
                    ctrl.Enabled = enable;
                    if (ctrl.SelectedIndex == ctrl.Items.Count - 1)
                    {
                        enable = false;
                    }
                }
            }
        }

        private void antPerBand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BMComm == null || !BMComm.ConfigRead)
            {
                return;
            }
            enableAntPerBandControls();
        }


        private void fillUIFromConfig(ProfileConfig cfg)
        {
            profileNameBox.Text = cfg.Name;
            bandChangeDelayBox.Value = cfg.BandChangeDelay;
            bandOutDelayBox.Value = cfg.BandOutDelay;
            pttBandBlockBox.Checked = cfg.SameBandPttLock;

            // short names
            var shortNamesUI = antShortNamesList.Zip(cfg.AntShortNames, (tb, n) => new { TextBox = tb, Name = n });
            foreach (var ui in shortNamesUI)
            {
                ui.TextBox.Text = ui.Name;
            }

            // long names
            var longNamesUI = antLongNamesList.Zip(cfg.AntLongNames, (tb, n) => new { TextBox = tb, Name = n });
            foreach (var ui in longNamesUI)
            {
                ui.TextBox.Text = ui.Name;
            }

            // Ant out bits
            var antBitsUI = antBitCfgList.Zip(cfg.AntOutCfg, (cbl, b) => new { CheckBoxList = cbl, Bits = b });
            foreach (var ui in antBitsUI)
            {
                int idx = 0;
                foreach(var cb in ui.CheckBoxList)
                {
                    cb.Checked = ((ui.Bits >> idx) & 0x01) == 0x01 ? true : false;
                    idx++;
                }
            }

            // Antennas per band
            var antPerBandUIRows = antPerBandList.Zip(cfg.AntPerBand, (cbl, bl) => new { BandComboBoxList = cbl, BandAntIdList = bl });
            foreach (var uiRow in antPerBandUIRows)
            {
                var antPerBandUI = uiRow.BandComboBoxList.Zip(uiRow.BandAntIdList, (cb, id) => new { ComboBox = cb, AntId = id });
                foreach (var ui in antPerBandUI)
                {
                    if (ui.AntId != Constants.NO_ANTENNA)
                    {
                        ui.ComboBox.SelectedIndex = ui.AntId;
                    }
                    else
                    {
                        ui.ComboBox.SelectedIndex = ui.ComboBox.Items.Count - 1;
                    }
                }
            }

            // Band out bits
            var bandOutBitsUI = bandBitCfgList.Zip(cfg.BandOutCfg, (cbl, b) => new { CheckBoxList = cbl, Bits = b });
            foreach (var ui in bandOutBitsUI)
            {
                int idx = 0;
                foreach (var cb in ui.CheckBoxList)
                {
                    cb.Checked = ((ui.Bits >> idx) & 0x01) == 0x01 ? true : false;
                    idx++;
                }
            }
        }

        
        private ProfileConfig getconfigFromUI()
        {
            var cfg = new ProfileConfig();
            cfg.Name = profileNameBox.Text;
            cfg.BandChangeDelay = Convert.ToByte(bandChangeDelayBox.Value);
            cfg.BandOutDelay = Convert.ToByte(bandOutDelayBox.Value);
            cfg.SameBandPttLock = pttBandBlockBox.Checked;

            // short names
            cfg.AntShortNames.Clear();
            foreach (var shortNameTextBox in antShortNamesList)
            {
                cfg.AntShortNames.Add(shortNameTextBox.Text);
            }

            // long names
            cfg.AntLongNames.Clear();
            foreach (var longNameTextBox in antLongNamesList)
            {
                cfg.AntLongNames.Add(longNameTextBox.Text);
            }

            // Ant out bits
            cfg.AntOutCfg.Clear();
            foreach (var antBitRow in antBitCfgList)
            {
                ushort antBits = 0;
                var idx = 0;
                ushort one = 1;
                foreach (var antCB in antBitRow)
                {
                    if (antCB.Checked)
                    {
                        antBits += (ushort)(one << idx);
                    }
                    idx++;
                }
                cfg.AntOutCfg.Add(antBits);
            }

            // Antennas per band
            cfg.AntPerBand.Clear();
            foreach(var perBandUIRow in antPerBandList)
            {
                var bandCfg = new List<byte>();
                foreach(var selectBox in perBandUIRow)
                {
                    if (selectBox.SelectedIndex == selectBox.Items.Count - 1)
                    {
                        bandCfg.Add(Constants.NO_ANTENNA);
                    }
                    else
                    {
                        bandCfg.Add((byte)selectBox.SelectedIndex);
                    }
                }
                cfg.AntPerBand.Add(bandCfg);
            }

            // Band out bits
            cfg.BandOutCfg.Clear();
            foreach (var bandBitRow in bandBitCfgList)
            {
                ushort bandBits = 0;
                var idx = 0;
                ushort one = 1;
                foreach (var bandCB in bandBitRow)
                {
                    if (bandCB.Checked)
                    {
                        bandBits += (ushort)(one << idx);
                    }
                    idx++;
                }
                cfg.BandOutCfg.Add(bandBits);
            }

            return cfg;
        }

    }
}

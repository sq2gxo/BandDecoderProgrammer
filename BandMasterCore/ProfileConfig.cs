using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandMasterCore
{
    public class ProfileConfig
    {
        private static readonly int HEX_CONF_LEN = 520;

        public string Name;
        public byte BandChangeDelay;
        public byte BandOutDelay;
        public bool SameBandPttLock;
        public List<string> AntShortNames = new List<string>();
        public List<string> AntLongNames = new List<string>();
        public List<ushort> AntOutCfg = new List<ushort>();
        public List<List<byte>> AntPerBand = new List<List<byte>>();
        public List<byte> AntSelBand = new List<byte>(); // fill it to defaults before sending to BM device
        public List<ushort> BandOutCfg = new List<ushort>();

        public string toHexStr()
        {
            AntSelBand.Clear();
            foreach(var bandAntSel in AntPerBand)
            {
                AntSelBand.Add(bandAntSel.FirstOrDefault());
            }
            var retVal = new StringBuilder();

            byte[] nameBytes = Enumerable.Repeat((byte)0x00, Constants.PROFILE_NAME_LEN + 1).ToArray();
            var nameValue = Encoding.ASCII.GetBytes(Name);
            System.Buffer.BlockCopy(nameValue, 0, nameBytes, 0, nameValue.Length);
            retVal.Append(BitConverter.ToString(nameBytes).Replace("-", ""));

            //AntShortNames
            for (int i = 0; i < Constants.MAX_ANT_TOTAL; i++)
            {
                byte[] antNameBytes = Enumerable.Repeat((byte)0x00, Constants.ANT_SHORT_NAME_LEN + 1).ToArray();
                if (i < AntShortNames.Count)
                {
                    var antNameValue = Encoding.ASCII.GetBytes(AntShortNames[i]);
                    System.Buffer.BlockCopy(antNameValue, 0, antNameBytes, 0, antNameValue.Length);
                }
                retVal.Append(BitConverter.ToString(antNameBytes).Replace("-", ""));
            }

            //AntLongNames
            for (int i = 0; i < Constants.MAX_ANT_TOTAL; i++)
            {
                byte[] antNameBytes = Enumerable.Repeat((byte)0x00, Constants.ANT_LONG_NAME_LEN + 1).ToArray();
                if (i < AntLongNames.Count)
                {
                    var antNameValue = Encoding.ASCII.GetBytes(AntLongNames[i]);
                    System.Buffer.BlockCopy(antNameValue, 0, antNameBytes, 0, antNameValue.Length);
                }
                retVal.Append(BitConverter.ToString(antNameBytes).Replace("-", ""));
            }

            //AntOutCfg
            for (int i = 0; i < Constants.MAX_ANT_TOTAL; i++)
            {
                if (i < AntOutCfg.Count)
                {
                    retVal.Append(AntOutCfg[i].ToString("X4"));
                }
                else
                {
                    retVal.Append("0000");
                }
            }

            //BandOutCfg
            for (int i = 0; i <= Constants.BAND_MAX; i++)
            {
                if (i < BandOutCfg.Count)
                {
                    retVal.Append(BandOutCfg[i].ToString("X4"));
                }
                else
                {
                    retVal.Append("0000");
                }
            }

            //AntAvailBandCfg
            for (int i = 0; i <= Constants.BAND_MAX; i++)
            {
                if (i < AntPerBand.Count)
                {
                    for (int j = 0; j < Constants.MAX_ANT_PER_BAND; j++)
                    {
                        if (j < AntPerBand[i].Count)
                        {
                            retVal.Append(AntPerBand[i][j].ToString("X2"));
                        }
                        else
                        {
                            retVal.Append("63"); //99
                        }
                    }
                }
                else
                {
                    retVal.Append("636363"); //99
                }
            }

            // BandOutDelay
            retVal.Append(BandOutDelay.ToString("X2"));

            //BandChangeDelay
            retVal.Append(BandChangeDelay.ToString("X2"));

            //SameBandPttLock
            retVal.Append(SameBandPttLock ? "01" : "00");

            // AntSelBand
            for (int i = 0; i <= Constants.BAND_MAX; i++)
            {
                if (i < AntSelBand.Count)
                {
                    retVal.Append(AntSelBand[i].ToString("X2"));
                }
                else
                {
                    retVal.Append("63"); //99
                }
            }

            var retStr = retVal.ToString();
            return retStr;
        }




        public void readFromHexStr(string configHex)
        {
            if (configHex.Length != HEX_CONF_LEN)
            {
                return;
            }

            byte[] bytes = new byte[HEX_CONF_LEN / 2];
            for (int i = 0; i < HEX_CONF_LEN; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(configHex.Substring(i, 2), 16);
            }

            var skipIdx = 0;

            var takeSize = Constants.PROFILE_NAME_LEN + 1;
            Name = System.Text.Encoding.ASCII.GetString(bytes.Skip(skipIdx).Take(takeSize).ToArray()); 
            Name = Name.Replace("\0", String.Empty);
            skipIdx += takeSize;
            
            //AntShortNames
            AntShortNames.Clear();
            for (int i = 0; i < Constants.MAX_ANT_TOTAL; i++)
            {
                takeSize = Constants.ANT_SHORT_NAME_LEN + 1;
                var str = System.Text.Encoding.ASCII.GetString(bytes.Skip(skipIdx).Take(takeSize).ToArray());
                str = str.Replace("\0", String.Empty);
                AntShortNames.Add(str);
                skipIdx += takeSize;
            }

            //AntLongNames
            AntLongNames.Clear();
            for (int i = 0; i < Constants.MAX_ANT_TOTAL; i++)
            {
                takeSize = Constants.ANT_LONG_NAME_LEN + 1;
                var str = System.Text.Encoding.ASCII.GetString(bytes.Skip(skipIdx).Take(takeSize).ToArray());
                str = str.Replace("\0", String.Empty);
                AntLongNames.Add(str);
                skipIdx += takeSize;
            }

            //AntOutCfg
            AntOutCfg.Clear();
            for (int i = 0; i < Constants.MAX_ANT_TOTAL; i++)
            {
                takeSize = 2;
                ushort val = (ushort) ((ushort)bytes[skipIdx] * 256 + (ushort)bytes[skipIdx + 1]);
                AntOutCfg.Add(val);
                skipIdx += takeSize;
            }
            
            //BandOutCfg
            BandOutCfg.Clear();
            for (int i = 0; i <= Constants.BAND_MAX; i++)
            {
                takeSize = 2;
                ushort val = (ushort)((ushort)bytes[skipIdx] * 256 + (ushort)bytes[skipIdx + 1]);
                BandOutCfg.Add(val);
                skipIdx += takeSize;
            }
            
            //AntAvailBandCfg
            AntPerBand.Clear();
            for (int i = 0; i <= Constants.BAND_MAX; i++)
            {
                var bandCfg = new List<byte>();
                for (int j = 0; j < Constants.MAX_ANT_PER_BAND; j++)
                {
                    takeSize = 1;
                    byte val = bytes[skipIdx];
                    bandCfg.Add(val);
                    skipIdx += takeSize;
                }
                AntPerBand.Add(bandCfg);
            }
             
            // BandOutDelay
            BandOutDelay = bytes[skipIdx];
            skipIdx++;


            //BandChangeDelay
            BandChangeDelay = bytes[skipIdx];
            skipIdx++;

            //SameBandPttLock
            SameBandPttLock = bytes[skipIdx] != 0;
            skipIdx++;

            // AntSelBand
            AntSelBand.Clear();
            for (int i = 0; i <= Constants.BAND_MAX; i++)
            {
                takeSize = 1;
                byte val = bytes[skipIdx];
                AntSelBand.Add(val);
                skipIdx += takeSize;
            }
        }
    }
}

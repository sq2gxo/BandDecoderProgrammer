using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandMasterCore
{
    public class ProfileConfig
    {
        public byte BandChangeDelay;
        public byte BandOutDelay;
        public bool SameBandPttLock;
        public List<string> AntShortNames = new List<string>();
        public List<string> AntLongNames = new List<string>();
        public List<ushort> AntOutCfg = new List<ushort>();
        public List<List<byte>> AntPerBand = new List<List<byte>>();
        public List<byte> AntSelBand = new List<byte>();
        public List<ushort> BandOutCfg = new List<ushort>();

        public string toHexStr()
        {
            return null;
        }

        public void readFromHexStr(string configHex)
        {

        }
    }
}

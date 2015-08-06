using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandMasterCore
{
    public enum RequestType {GETCFG, WRITECFG};

    public class BMCommunication
    {
        public bool BMConnected = false;
        public bool ConfigRead = false;

        public ProfileConfig DeviceConfig = new ProfileConfig();
        public ProfileConfig WriteConfig = new ProfileConfig();

        private string ReadBuffer = "";

        public ProfileConfig ParseReceivedData(string indata)
        {
            ReadBuffer += indata;
            var idx = ReadBuffer.IndexOf('\n');
            if (idx >= 0)
            {
                var message = ReadBuffer.Substring(0, idx);
                ReadBuffer = ReadBuffer.Remove(0, idx + 1);
                if (message.StartsWith("DS"))
                {
                    // ignore device status
                    return null;
                }
 
                var deviceConfig = new ProfileConfig();
                bool result = deviceConfig.readFromHexStr(message);

                if (result)
                {
                    BMConnected = true;
                    ConfigRead = true;

                    return deviceConfig;
                }
                
            }
            return null;
        }

        public string PrepareRequest(RequestType type, ProfileConfig cfg)
        {
            string request;
            switch (type)
            {
                case RequestType.GETCFG:
                    request = "PR";
                    break;
                case RequestType.WRITECFG:
                    request = "PW";
                    request += cfg.toHexStr();
                    break;
                default:
                    return "";
            }
            request += "\n";
            return request;
        }
    }
}

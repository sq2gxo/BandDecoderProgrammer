using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandMasterCore
{
    public class Constants
    {
        public const int  MAX_ANT_PER_BAND = 3;
        public const int  MAX_ANT_TOTAL = 10;
        public const int  MAX_PROFILES = 1;
        public const int  ANT_SHORT_NAME_LEN = 5;
        public const int  ANT_LONG_NAME_LEN = 10;
        public const int  PROFILE_NAME_LEN = 6;
        public const int  NO_ANTENNA = 99;

        public const int ANT_CONFIG_BITS = 12;
        public const int BAND_CONFIG_BITS = 10;

        // visual
        public const int Y_DIFF = 30;
        public const int X_CKBOX_DIFF = 20;
        public const int X_COMBOBOX_DIFF = 120;
        
        public const int BANDS_NUM = 10;

        public static readonly string[] Bands = {
            "1.8MHz",
	        "3.5MHz",
	        "  7MHz",
	        " 10MHz",
	        " 14MHz",
	        " 18MHz",
	        " 21MHz",
	        " 24MHz",
	        " 28MHz",
	        " 50MHz"
        };
    }
}

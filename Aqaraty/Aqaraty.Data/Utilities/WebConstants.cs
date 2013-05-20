using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aqaraty.Data.Utilities
{
    public static class WebConstants
    {
        public static class Session
        {
            public static string USER_ID = "USER_ID";
            public static string RETURN_URL = "RETURN_URL";
            public static string PASSWORD = "PASSWORD";
            public static string ACTIVATION_CODE = "ACTIVATION_CODE";
        }
        public static class Config
        {
            public static string ADMIN_EMAIL_ADDRESSES = "AdminEmailAddress";
            public static string FROM_EMAIL_ADDRESS = "FromEmailAddress";
            public static string REDIRECT_URL = "RedirectURL";
            public static string PUBLIC_KEY = "PublicKey";
            public static string PRIVATE_KEY = "PrivateKey";
            public static string SERIAL_NUMBER = "SerialNumber";
        }
    }
}

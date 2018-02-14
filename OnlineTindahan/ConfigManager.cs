using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;

namespace OnlineTindahan
{
    public static class ConfigManager
    {
        public static class General
        {
            public static readonly string WebAppTitle;
            static General()
            {
                 WebAppTitle = ConfigurationManager.AppSettings["WebAppTitle"];
            }
        }

        public static class Database
        {
            public static readonly string DatabaseConnection;
            static Database()
            {
                DatabaseConnection = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            }
        }
    }
}
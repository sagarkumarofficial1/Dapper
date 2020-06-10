using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DotNetMVC.Data.DAL
{
    public class Helper
    {
        //DefaultConnection
        public static string ConString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}

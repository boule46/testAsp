using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EnquetesAFPA
{
    public static class Outils
    {
        public static String ExtraireChaineConnexion(string Cle)
        {
            Configuration rootWebConfig =
              System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            System.Configuration.ConnectionStringSettings connString = null;
            if (0 < rootWebConfig.ConnectionStrings.ConnectionStrings.Count)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings[Cle];

            }
            return connString.ConnectionString;
        }
    }
}
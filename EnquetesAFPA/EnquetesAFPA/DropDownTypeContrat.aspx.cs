using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnquetesAFPA
{
    public partial class DropDownTypeContrat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AfficherDropDownTypeContrat();
        }

        public void AfficherDropDownTypeContrat()
        {
            List<TypeContrat> list = new List<TypeContrat>();

            using (SqlConnection connection = new SqlConnection(Outils.ExtraireChaineConnexion("EnquetesConnectionString")))
            {
                using (SqlCommand command = new SqlCommand("select IDTypeContrat, LibelleTypeContrat from TypeContrat;", connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            list.Add(new TypeContrat() { TypeContratID = reader.GetInt32(0), TypeContratLibelle = reader.GetString(1) });
                        }
                    }
                }

            }
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);

            Response.Clear();
            Response.ContentType = "application/json";
            Response.Write(json);
            Response.End();
        }



    }
}
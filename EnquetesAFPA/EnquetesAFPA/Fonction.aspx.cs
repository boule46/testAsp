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
    public partial class Fonction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Lettres = this.Request.Params["MainContent_lettresRechercher"] + "%";

            string commandText = "select LibelleAppellationRome from AppellationRome where LibelleAppellationRome like @lettres;";

            List<Libelle> list = new List<Libelle>();

            using (SqlConnection connection = new SqlConnection(Outils.ExtraireChaineConnexion("EnquetesConnectionString")))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add(new SqlParameter("@lettres", Lettres));

                connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            list.Add(new Libelle() {LibelleFonction = reader.GetString(0) });
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
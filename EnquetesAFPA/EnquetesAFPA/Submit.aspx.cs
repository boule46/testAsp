using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnquetesAFPA
{
    public partial class Submit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //recuperation des donnees formulaire sauf le guid
            int TypeContrat = Int32.Parse(this.Request.Params["TypeContrat"]);
            string DureeContrat = this.Request.Params["DureeContrat"];
            DateTime DateEntree = DateTime.Parse(this.Request.Params["DateEntree"]);
            DateTime DateSortie = DateTime.Parse(this.Request.Params["DateSortie"]);
            string AppellationRome = this.Request.Params["Appellation"];

            //Recuperer Code Rome
            string commandText = "select CodeRome from AppellationRome where LibelleAppellationRome = @Appel;";

            StringBuilder SB = new StringBuilder();

            using (SqlConnection connection = new SqlConnection(Outils.ExtraireChaineConnexion("EnquetesConnectionString")))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add(new SqlParameter("@Appel", AppellationRome));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SB.Append(reader.GetString(0));
                        
                    }
                }

                
            }

            string CodeRome = SB.ToString();
            

            //inserer dans base de donnees

            using (SqlConnection connection = new SqlConnection(Outils.ExtraireChaineConnexion("EnquetesConnectionString")))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO ExercerFonction (IDTypeContrat, CodeRome, LibelleAppellationRome, IdentifiantMailing, DureeContrat, DateEntreeFonction, DateSortieFonction, DateReponse) VALUES (@IDTypeContrat, @CodeRome, @LibelleAppellationRome, @IdentifiantMailing, @DureeContrat, @DateEntreeFonction, @DateSortieFonction, @DateReponse)");
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@IDTypeContrat", TypeContrat);
                cmd.Parameters.AddWithValue("@CodeRome", CodeRome);
                cmd.Parameters.AddWithValue("@LibelleAppellationRome", AppellationRome);
                cmd.Parameters.AddWithValue("@DureeContrat", DureeContrat);
                cmd.Parameters.AddWithValue("@DateEntreeFonction", DateEntree);
                cmd.Parameters.AddWithValue("@DateSortieFonction", DateSortie);
                cmd.Parameters.AddWithValue("@DateReponse", DateTime.Now);
                cmd.Parameters.Add(new SqlParameter("@IdentifiantMailing", System.Data.SqlDbType.UniqueIdentifier, 16));
                cmd.Parameters["@IdentifiantMailing"].Value = Guid.Parse(this.Request.Params["GUID"]);
                connection.Open();
                cmd.ExecuteNonQuery();
            }

           





        }

       
    }
}
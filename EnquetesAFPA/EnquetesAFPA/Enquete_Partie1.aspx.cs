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
    public partial class Enquete_Partie1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            idSoumissionaire.Value = this.Request.QueryString["IdentifiantMailing"];
            GetIntroduction();
        }
        private void GetIntroduction()
        {
            StringBuilder sb = new StringBuilder();
           
            using (SqlConnection connection = new SqlConnection(Outils.ExtraireChaineConnexion("EnquetesConnectionString")))
            {
                try
                {
                    connection.Open();
                    SqlCommand sqlDetail = new SqlCommand();
                    sqlDetail.CommandText = "SELECT [TitreCiviliteComplet], [NomBeneficiaire], [PrenomBeneficiaire],"
                        + "[DateSortieBeneficiaire], [LibelleQuestionnaire] "
                    + "FROM [Vue_Soumissionnaire] WHERE ([IdentifiantMailing] = @IdentifiantMailing)";
                    sqlDetail.Parameters.Add(new SqlParameter("@IdentifiantMailing", this.Request.QueryString["IdentifiantMailing"]));
                    sqlDetail.Connection = connection;
                    SqlDataReader drSoumissionnaire = sqlDetail.ExecuteReader();
                    if (drSoumissionnaire.Read())
                    {

                        sb.Append(string.Format(@"<span>Bonjour {0} {1} {2} </span><br/>", drSoumissionnaire.GetString(0), drSoumissionnaire.GetString(2), drSoumissionnaire.GetString(1)));
                        sb.Append(string.Format(@"<span>Merci de consacrer quelques instants à la réponse à notre enquête.</span><br/>"));
                        sb.Append(string.Format(@"<span>Avez-vous exercé un emploi depuis le {0}</span><br/>", drSoumissionnaire.GetDateTime(3).ToLongDateString()));
                        this.titreEnquete.InnerHtml = string.Format(@"<span>{0}</span><br/>", drSoumissionnaire.GetString(4));
                        this.introduction.InnerHtml = sb.ToString();
                    }

                    // Fermeture de la connexion
                    connection.Close();

                }
                catch (Exception e)
                {
                    throw new ApplicationException("Une erreur est survenue lors du traitement de la requête", e);
                }

            }


        }
    }
}
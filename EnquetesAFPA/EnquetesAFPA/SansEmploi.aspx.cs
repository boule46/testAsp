using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnquetesAFPA
{
    public partial class SansEmploi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EnregistrerReponse();
            Server.Transfer("Remerciements.html");
        }
        private void EnregistrerReponse()
        {

            System.Configuration.Configuration rootWebConfig =
               System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/");
            System.Configuration.ConnectionStringSettings connString = null;
            if (0 < rootWebConfig.ConnectionStrings.ConnectionStrings.Count)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["EnquetesConnectionString"];

            }


            using (SqlConnection connection = new SqlConnection(Outils.ExtraireChaineConnexion("EnquetesConnectionString")))
            {

                try
                {
                    connection.Open();
                    SqlCommand sqlReponse = new SqlCommand();
                    sqlReponse.CommandText = "Update Soumissionnaires Set ReponseEmploi='0',DateEnregistrementReponse=@DateJour "
                    + " WHERE ([IdentifiantMailing] = @IdentifiantMailing)";
                    sqlReponse.Connection = connection;
                    sqlReponse.Parameters.Add(new SqlParameter("@IdentifiantMailing", System.Data.SqlDbType.UniqueIdentifier, 16));
                    sqlReponse.Parameters.Add(new SqlParameter("@DateJour", System.Data.SqlDbType.DateTime, 0));
                    sqlReponse.Parameters["@IdentifiantMailing"].Value = Guid.Parse(this.Request.Form["idSoumissionaire"]);
                    sqlReponse.Parameters["@DateJour"].Value = DateTime.Now;

                    sqlReponse.ExecuteNonQuery();
                    connection.Close();

                }
                catch (Exception e)
                {

                    throw new ApplicationException("Une erreur est survenue lors de l'enregistrement", e);
                }

            }


        }
    }
}
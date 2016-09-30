<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Emploi.aspx.cs" Inherits="EnquetesAFPA.Emploi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Informations sur activité professionnelle</title>
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">

        <form id="frmEnregistrerReponse" runat="server" >
            <asp:ScriptManager runat="server">
            </asp:ScriptManager>

            <h1 class="text-center">Merci de nous communiquer les détails de votre contrat</h1>

            <div class="form-horizontal col-md-12" style="padding-top:10px;margin-top:10px" id="informationsFonction" runat="server">
                
                <div class="form-group">
               <label for="TypeContrat" class="col-md-3 control-label">Le type de votre contrat: </label>
                <div class="col-md-offset-1 col-md-8">
                <select class="form-control " id="TypeContrat">

                </select>
                </div>
                </div>

                <div class="form-group">
                <label for="radioDureeContrat" class="col-md-3 control-label">La durée de votre contrat: </label>
                <div class="col-md-offset-1 col-md-8">
                    <p><label><input type="radio" name="OptionRadioBouton" id="radioDureeContrat1" value="A" required /> < 3 mois</label></p>
                    <p><label><input type="radio" name="OptionRadioBouton" id="radioDureeContrat2" value="B" /> => 3 mois et < 6 mois</label></p>
                    <p><label><input type="radio" name="OptionRadioBouton" id="radioDureeContrat3" value="C" /> > à 6 mois</label></p>
                   <p><label><input type="radio" name="OptionRadioBouton" id="radioDureeContrat4" value="D" /> Non significatif</label></p>
                </div>
                </div>

                <div class="form-group">
                <label for="dateEntree" class="col-md-3 control-label">La date d'entrée en fonction: </label>
                <div class="col-md-offset-1 col-md-8">
                <input type="date" id="dateEntree" class="form-control" placeholder="jj/mm/aaaa" min="01/01/2010" max="01/01/2030" required /> <%--un premier control grossière, mais il faut savoir un peu plus sur les annees--%>
                </div>
                </div>
                  
                     <br />
                     <br />

                <div class="form-group">
                <label for="dateFin" class="col-md-3 control-label">La date de fin de contrat: </label>
                <div class="col-md-offset-1 col-md-8">
                <input type="date" id="dateFin" class="form-control" placeholder="jj/mm/aaaa" min="01/09/2016" max="01/01/2030" required /> <%--un premier control grossière, mais il faut savoir un peu plus sur les annees--%>
                </div>
                </div>
                    
                    <br />
                    <br />

                <div class="form-group">
                <label for="appellationFonction" class="col-md-3 control-label">Choissisez votre métier: </label>
                <div class="col-md-offset-1 col-md-8">
                <input type="text" id="lettresRechercher" maxlength="5" /><input type="button" value="Rechercher" onclick="autoCompletion()" />
                </div>
               <br />
                <div class="col-md-offset-4 col-md-8">
                <select class="form-control" id="LibelleFonction1" required>

                </select>
                </div>
                </div>

                <div class="col-md-offset-5 col-md-2">
                <input type="submit" onclick="valider()" style="margin-top:20%;padding:6%" />
                </div>





            </div>
            </div>
            <%-- Valeur cachée pour transaction  --%>
             <input type="hidden" runat="server" id="CodeSoumissionnaire"/>
        </form>
    </div>
    
    <script src="RequetesAjax.js"></script>
</body>

</html>


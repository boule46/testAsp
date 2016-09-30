 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Enquete_Partie1.aspx.cs" Inherits="EnquetesAFPA.Enquete_Partie1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Enquête insertion Première partie</title>
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="h3 col-md-12 " runat="server" id="titreEnquete" style="padding: 20px">
        </div>
        <div class="jumbotron col-md-12" runat="server" id="introduction">
        </div>
        <form id="frmEnquete_Part1" class="form" runat="server" role="form">

            <div class="col-md-12">
                <div class=="btn-group btn-group-justified" data-toggle="buttons">
                    <a id="Emploi" class="btn btn-primary" href="#"  onclick="soumettre('A')">Oui, j'ai repris un emploi.</a>
                    <a id="SsEmploi" class="btn btn-primary" href="#" onclick="soumettre('B')">Non, je n'ai pas retravaillé.</a>
                </div>
            </div>
            <input type="hidden" runat="server" id="idSoumissionaire"/>
        </form>
    </div>
    <script type="text/javascript">
        function soumettre(option) {
            var formulaire = document.getElementById('frmEnquete_Part1');
            if (option === 'A') {
                formulaire.action = "Emploi.aspx"          
            }
            if (option === 'B') {
                formulaire.action = "SansEmploi.aspx"
            }
            formulaire.submit();
        }
    </script>
</body>
</html>


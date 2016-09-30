window.onload = function DropDown() {
    xhttp = new XMLHttpRequest;
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            lireDonnees(xhttp.responseText);
        }
    };

    xhttp.open("GET", "DropDownTypeContrat.aspx", true);
    xhttp.setRequestHeader("Content-Type", "x-www-form-urlencoded");
    xhttp.send(null);
}

function lireDonnees(donnees)
{
    var listContrat = new Array();
    listContrat = JSON.parse(donnees);
    var zoneText = document.getElementById("TypeContrat");
    var option;


    for (var i = 0; i < listContrat.length ; i++) {


        option = document.createElement("option");
        option.value = listContrat[i].TypeContratID;
        option.text = listContrat[i].TypeContratLibelle;
        zoneText.appendChild(option);
    }

}

function autoCompletion()
{
    var lettresDemander = document.getElementById("lettresRechercher").value;


    nhttp = new XMLHttpRequest;
    nhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            Afficherfunction(nhttp.responseText);
        }
    };

    nhttp.open("GET", "Fonction.aspx?MainContent_lettresRechercher=" + encodeURIComponent(document.getElementById("lettresRechercher").value), true);
    nhttp.setRequestHeader("Content-Type", "x-www-form-urlencoded");
    nhttp.send(null);
}

function Afficherfunction(donnees)
{
    var listLibelle = new Array();
    listLibelle = JSON.parse(donnees);
    var zoneText = document.getElementById("LibelleFonction1");
    var option;

    for (var i = 0; i < listLibelle.length ; i++) {

        option = document.createElement("option");
        option.value = listLibelle[i].LibelleFonction
        option.text = listLibelle[i].LibelleFonction;
        zoneText.appendChild(option);
    }
}

function valider()
{
    //valeur typeContrat
    var typeContrat = document.getElementById("TypeContrat").options[document.getElementById("TypeContrat").selectedIndex].value;

    //valeur radioboutons
    var dureeContrat = document.getElementsByName("OptionRadioBouton")
    var txt = "";
    var i;

    for (i = 0; i < dureeContrat.length; i++) {
        if (dureeContrat[i].checked) {
            txt = txt + dureeContrat[i].value + " ";
        }
    }

    dureeContrat = txt;

    //valeur entree fonction
    var dateEntree = document.getElementById("dateEntree").value;

    if(dateEntree )

    //valeur sortie contrat
    var dateSortie = document.getElementById("dateFin").value;

    //valeur Libelle Rome
    var rome = document.getElementById("LibelleFonction1").options[document.getElementById("LibelleFonction1").selectedIndex].value;

    //valeur GUIDE
    var guid1 = document.getElementById("CodeSoumissionnaire").value;

    //envoie des valeurs pour controle serveur et enregistrement dans la base de donnees
    submithttp = new XMLHttpRequest;
    submithttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            Redirect();
        }
    };
    submithttp.open("GET", "Submit.aspx?TypeContrat=" + encodeURIComponent(typeContrat) + "&DureeContrat=" + encodeURIComponent(dureeContrat) + "&DateEntree=" + encodeURIComponent(dateEntree) + "&DateSortie=" + encodeURIComponent(dateSortie) + "&Appellation=" + encodeURIComponent(rome) + "&GUID=" + encodeURIComponent(guid1), true);
    submithttp.setRequestHeader("Content-Type", "x-www-form-urlencoded");
    submithttp.send(null);



}

function Redirect()
{
    document.location.href = "Remerciements.html";
}
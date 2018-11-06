listApartments = new Array();
listHomes = new Array();
var idHome = 0
var idApartments = 0;

    //Definição dos JS
    //$(this).hide() - elemento corrente
    //$("p").hide() - todos os <p>
    //$(".test").hide() - classe igual a teste
    //$("#test").hide() - id igual a teste

$(document).ready(function () {
    $('#formHome').hide();
    $('#formApartment').hide();

    $('#selRealty').change(function () {

        switch ($(this).val()) {
            case "empty":
                $('#formHome').hide();
                $('#formApartment').hide();
                break;
            case "home":
                $('#formHome').show();
                $('#formApartment').hide();

                break;
            case "apartment":
                $('#formApartment').show();
                $('#formHome').hide();

                break;
        }
    });

    $("#btnSaveHome").click(function (e) { 
        var  adress, adjunct, number, phone;
        adress =  $("#txtEnderecoCasa").val();
        adjunct =  $("#txtComplementoCasa").val();
        number =  $("#txtNumeroCasa").val();    
        phone = $("#txtTelefoneCasa").val();

        SaveHome(adress, adjunct, number, phone);
    });

});

function SaveHome(adress, adjunct, number, phone) {
    if (adress != "" && adjunct != "" && number != "" && phone != "") {
        var object = new Object();
        idHome++;

        object.idHome = idHome;
        object.adress = adress;
        object.adjunct = adjunct;
        object.number = phone;
        object.phone = phone;

        listHomes.push(object);

        LoadTableHome(listHomes);
    } else {
        return alert("Preencha todos os campos para salvar!");
    }

}

function LoadTableHome(homes) {
    var table = $("#tabHome");
    table.html("");

    table.append(
        "<tr>"
        + "<th>Endereço</th>"
        + "<th>Número</th>"
        + "<th>Complemento</th>"
        + "<th>Telefone</th>"
        + "<th>Ações</th>"
        + "</tr>"
    );

    homes.forEach(el => {
        table.append(
            "<tr id='" + el.idHome + "' >"
            + "<td id ='" + el.idHome + "E'>" + el.adress + "</td>"
            + "<td id ='" + el.idHome + "N'>" + el.number + "</td>"
            + "<td id ='" + el.idHome + "C'>" + el.adjunct + "</td>"
            + "<td id ='" + el.idHome + "F'>" + el.number + "</td>"
        );
    });
}
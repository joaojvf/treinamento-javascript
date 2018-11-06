listApts = new Array();
listHomes = new Array();
var idHome = 0
var idApts = 0;

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

    $("#txtTelefoneCasa").mask("(99) 99999-9999");
    $("#txtTelefoneApt").mask("(99) 99999-9999");
    $("#txtValorApt").mask("#.##0,00", { reverse: true });

    $("#btnSaveHome").click(function (e) {
        var adress, adjunct, number, phone;
        adress = $("#txtEnderecoCasa").val();
        adjunct = $("#txtComplementoCasa").val();
        number = $("#txtNumeroCasa").val();
        phone = $("#txtTelefoneCasa").val();

        if (adress != "" && adjunct != "" && number != "" && phone != "") {
            SaveHome(adress, adjunct, number, phone);
            ClearFieldsHome();
        } else {
            return alert("Preencha todos os campos para salvar!");
        }

    });

    $("#btnSaveApt").click(function (e) {
        var adress, adjunct, number, phone, date, value, court, garage, pool;
        adress = $("#txtEnderecoApt").val();
        adjunct = $("#txtComplementoApt").val();
        number = $("#txtNumeroApt").val();
        phone = $("#txtTelefoneApt").val();
        date = $("#txtDataCompraApt").val();
        value = $("#txtValorApt").val();

        if ($("#checkGaragemApt").is(":checked") == true) {
            garage = "Sim";
        } else {
            garage = "Não";
        }
        if ($("#checkQuadraApt").is(":checked") == true) {
            court = "Sim";
        } else {
            court = "Não";
        }
        if ($("#checkPiscinaApt").is(":checked") == true) {
            pool = "Sim";
        } else {
            pool = "Não";
        }
        if (adress != "" && adjunct != "" && number != "" && phone != "" && date != "" && value != "") {
            SaveApt(adress, adjunct, number, phone, date, value, court, garage, pool);
            ClearFieldsApt();
        } else {
            return alert("Preencha todos os campos para salvar!");
        }
    });



});
//------------------------------------------------------------------------HOME----------------------------------------------------//
function ClearFieldsHome() {
    $("#txtEnderecoCasa").val("");
    $("#txtComplementoCasa").val("");
    $("#txtNumeroCasa").val("");
    $("#txtTelefoneCasa").val("");

}

function SaveHome(adress, adjunct, number, phone) {
    var object = new Object();

    idHome++;

    object.idHome = idHome;
    object.adress = adress;
    object.adjunct = adjunct;
    object.number = number;
    object.phone = phone;

    listHomes.push(object);

    LoadTableHome(listHomes);

}



function LoadTableHome(homes) {
    var table = $("#tabHome");
    table.html("");

    table.append(
        "<tr>" +
        "<th>Endereço</th>" +
        "<th>Número</th>" +
        "<th>Complemento</th>" +
        "<th>Telefone</th>" +
        "<th>Ações</th>" +
        "</tr>"
    );

    homes.forEach(el => {
        table.append(
            "<tr id='" + el.idHome + "' >" +
            "<td id ='" + el.idHome + "E'>" + el.adress + "</td>" +
            "<td id ='" + el.idHome + "N'>" + el.number + "</td>" +
            "<td id ='" + el.idHome + "C'>" + el.adjunct + "</td>" +
            "<td id ='" + el.idHome + "F'>" + el.phone + "</td>" +
            "<td> <input type ='button' id='btnEditHome' onclick='EditHome(" + el.idHome + ")' value='Editar' class = 'btn btn-warning' >" +
            "<input type ='button' id='btnRemoveHome' onclick ='RemoveHome(" + el.idHome + ")' value ='Excluir' class = 'btn btn-danger'></input> </td>"
        );
    });
}


function EditHome(id) {
    var obj = new Object();


    listHomes.forEach(el => {
        if (el.idHome == id) {
            obj.id = el.idHome;
            obj.adress = el.adress;
            obj.number = el.number;
            obj.adjunct = el.adjunct;
            obj.phone = el.phone;
        }
    });

    if (obj != null) {

        $("#txtEnderecoCasa").val(obj.adress);
        $("#txtComplementoCasa").val(obj.adjunct);
        $("#txtNumeroCasa").val(obj.number);
        $("#txtTelefoneCasa").val(obj.phone);

        RemoveHome(obj.id);

    } else {
        console.log(obj);
    }
}

function RemoveHome(id) {
    var newListHomes = new Array();
    listHomes.forEach(el => {
        if (el.idHome != id) {
            newListHomes.push(el);
        }
    });
    listHomes = newListHomes;
    LoadTableHome(listHomes);
}

//-----------------------------------------------------APARTMENTS--------------------------------------------------------------------//

function LoadTableApts(apts) {
    var table = $("#tabApt");
    table.html("");

    table.append(
        "<tr>" +
        "<th>Endereço    </th>" +
        "<th>Número      </th>" +
        "<th>Complemento </th>" +
        "<th>Telefone    </th>" +
        "<th>Quadra      </th>" +
        "<th>Garagem     </th>" +
        "<th>Piscina     </th>" +
        "<th>Data Compra </th>" +
        "<th>Valor       </th>" +
        "<th>Ações       </th>" +
        "</tr>"
    );

    apts.forEach(el => {
        table.append(
            "<tr id='" + el.idApts + "' >" +
            "<td id ='" + el.idApts + "E'>" + el.adress + "</td>" +
            "<td id ='" + el.idApts + "N'>" + el.number + "</td>" +
            "<td id ='" + el.idApts + "C'>" + el.adjunct + "</td>" +
            "<td id ='" + el.idApts + "F'>" + el.phone + "</td>" +
            "<td id ='" + el.idApts + "Q'>" + el.court + "</td>" +
            "<td id ='" + el.idApts + "G'>" + el.garage + "</td>" +
            "<td id ='" + el.idApts + "P'>" + el.pool + "</td>" +
            "<td id ='" + el.idApts + "D'>" + el.date + "</td>" +
            "<td id ='" + el.idApts + "V'>" + el.value + "</td>" +

            "<td> <input type ='button' id='btnEditApts' onclick='EditApts(" + el.idApts + ")' value='Editar' class = 'btn btn-warning' >" +
            "<input type ='button' id='btnRemoveApts' onclick ='RemoveApts(" + el.idApts + ")' value ='Excluir' class = 'btn btn-danger'></input> </td>"
        );
    });
}

function SaveApt(adress, adjunct, number, phone, date, value, court, garage, pool) {

    var object = new Object();

    idApts++;

    object.idApts = idApts;
    object.adress = adress;
    object.adjunct = adjunct;
    object.number = number;
    object.phone = phone;
    object.date = date;
    object.value = value;
    object.court = court;
    object.garage = garage;
    object.pool = pool;

    listApts.push(object);

    console.log(listApts);
    LoadTableApts(listApts);

}

function EditApts(id) {
    var object = new Object();


    listApts.forEach(el => {
        if (el.idApts == id) {
            object.idApts = el.idApts;
            object.adress = el.adress;
            object.adjunct = el.adjunct;
            object.number = el.number;
            object.phone = el.phone;
            object.date = el.date;
            object.value = el.value;
            object.court = el.court;
            object.garage = el.garage;
            object.pool = el.pool;
        }
    });

    if (object != null) {

        $("#txtEnderecoApt").val(object.adress);
        $("#txtComplementoApt").val(object.adjunct);
        $("#txtNumeroApt").val(object.number);
        $("#txtTelefoneApt").val(object.phone);
        $("#txtDataCompraApt").val(object.date);
        $("#txtValorApt").val(object.value);

        if (object.court == "Sim") {
            $("#checkQuadraApt").prop("checked", true);
        } else {
            $("#checkQuadraApt").prop("checked", false);
        }

        if (object.garage == "Sim") {
            $("#checkGaragemApt").prop("checked", true);
        } else {
            $("#checkGaragemApt").prop("checked", false);
        }

        if (object.pool == "Sim") {
            $("#checkPiscinaApt").prop("checked", true);
        } else {
            $("#checkPiscinaApt").prop("checked", false);
        }


        RemoveApts(object.idApts);


    } else {
        console.log(object);
    }
}

function RemoveApts(id) {
    var newListApts = new Array();
    listApts.forEach(el => {
        if (el.idApts != id) {
            newListApts.push(el);
        }
    });
    listApts = newListApts;
    LoadTableApts(listApts);
}

function ClearFieldsApt() {
    $("#txtEnderecoApt").val("");
    $("#txtComplementoApt").val("");
    $("#txtNumeroApt").val("");
    $("#txtTelefoneApt").val("");
    $("#txtDataCompraApt").val("");
    $("#txtValorApt").val("");
    $("#checkGaragemApt").prop("checked", false);
    $("#checkQuadraApt").prop("checked", false);
    $("#checkPiscinaApt").prop("checked", false);

}

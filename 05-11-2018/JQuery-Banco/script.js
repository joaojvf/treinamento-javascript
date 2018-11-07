var lSemConta = new Array();
var lJuridica = new Array();
var lFisica = new Array();
var control = 0,
    altId = -1;

//Definição dos JS
//$(this).hide() - elemento corrente
//$("p").hide() - todos os <p>
//$(".test").hide() - classe igual a teste
//$("#test").hide() - id igual a teste


$(document).ready(function () {
    $("#frmSemConta").hide();
    $("#frmContaFisica").hide();
    $("#frmContaJuridica").hide();
    $("#tabSemConta").hide();

    LoadMask();

    $("#selCliente").change(function (e) {
        switch ($(this).val()) {
            case "vazio":
                $("#frmSemConta").hide();
                $("#frmContaFisica").hide();
                $("#frmContaJuridica").hide();
                break;

            case "semConta":
                $("#frmSemConta").show();
                $("#frmContaFisica").hide();
                $("#frmContaJuridica").hide();
                break;

            case "juridica":
                $("#frmSemConta").hide();
                $("#frmContaFisica").hide();
                $("#frmContaJuridica").show();
                break;

            case "fisica":
                $("#frmSemConta").hide();
                $("#frmContaFisica").show();
                $("#frmContaJuridica").hide();
                break;
        }

    });


    //-------------------------------------SEM CONTA --------------------------------------//

    $("#btnSalvaSemConta").click(function (e) {
        var nome, tel, cpf, obs;
        nome = $("#txtNomeSemConta").val();
        tel = $("#txtFoneSemConta").val();
        cpf = $("#txtCpfSemConta").val();
        obs = $("#txtObservacoes").val();

        if (nome != "" && tel != "" && cpf != "") {
            SalvaSemConta(nome, tel, cpf, obs);
            LimpaCamposSemConta();
            $("#tabSemConta").show();
        } else {
            return alert("Preencha todos os campos para salvar!");
        }

    });

    //------------------------------------FISICA-------------------------------------------//
    $("#selDep").change(function (e) {
        switch ($(this).val()) {
            case "vazio":
                $("#frmDep").hide();
                break;

            case "nao":
                $("#frmDep").show();
                LoadFrmRef();
                break;

            case "sim":
                $("#frmDep").show();
                LoadFrmDep();
                break;
        }
    });

    $("#btnSalvaFis").click(function (e) {
        var nome, tel, cpf, obs;
        nome = $("#txtNomeFisica").val();
        tel = $("#txtFoneFisica").val();
        cpf = $("#txtCpfFisica").val();
        obs = $("#txtObservacoes").val();

        if (nome != "" && tel != "" && cpf != "") {
            SalvaFisica(nome, tel, cpf, obs);
            LimpaCamposFisica();
            $("#tabFisica").show();
        } else {
            return alert("Preencha todos os campos para salvar!");
        }

    });
    
    //-------------------------------------JURIDICA----------------------------------------//
    $("#selLim").change(function (e) {
        switch ($(this).val()) {
            case "vazio":
                $("#frmLim").hide();
                break;

            case "inferior":
                $("#frmLim").show();
                LoadFrmInf();
                break;

            case "igualSuperior":
                $("#frmLim").show();
                LoadFrmIgualSup();
                break;
        }

    });
});
//------------------------------------SEM CONTA----------------------------------------//
function SalvaSemConta(nome, tel, cpf, obs) {
    if (altId == -1) {
        var obj = new Object();
        control++

        obj.id = control;
        obj.nome = nome;
        obj.tel = tel;
        obj.cpf = cpf;
        obj.obs = obs;

        lSemConta.push(obj);
    } else {
        lSemConta.forEach(el => {
            if (el.id == altId) {
                el.id = altId;
                el.nome = nome;
                el.tel = tel;
                el.cpf = cpf;
                el.obs = obs;

                altId = -1;
            }
        });
    }

    CarTabSemConta();
}

function CarTabSemConta() {
    var tab = $("#tabSemConta");
    tab.html("");
    tab.append(
        "<thead><tr><th>NOME</th><th>CPF</th><th>TELEFONE</th><th>AÇÕES</th></tr></thead>"
    );

    lSemConta.forEach(el => {
        tab.append(
            "<tr id='" + el.id + "' >" +
            "<td>" + el.nome + "</td>" +
            "<td>" + el.cpf + "</td>" +
            "<td>" + el.tel + "</td>" +
            "<td> <input type ='button' onclick='EditSemConta(" + el.id + ")' value='Editar' class = 'btn btn-warning margin-rigth'  >" +
            "<input type ='button' onclick ='DelSemConta(" + el.id + ")' value ='Excluir' class = 'btn btn-danger'></input> </td>"
        );
    });
}



function EditSemConta(id) {
    lSemConta.forEach(el => {
        if (el.id == id) {
            $("#txtNomeSemConta").val(el.nome);
            $("#txtFoneSemConta").val(el.tel);
            $("#txtCpfSemConta").val(el.cpf);
            $("#txtObservacoes").val(el.obs);
            altId = el.id;
            LoadMask();
        }
    });
}


function DelSemConta(id) {
    var newList = new Array();

    lSemConta.forEach(el => {
        if (el.id != id)
            newList.push(el);
    })

    lSemConta = newList;
    CarTabSemConta();
}

function LimpaCamposSemConta() {
    $("#txtNomeSemConta").val("");
    $("#txtFoneSemConta").val("");
    $("#txtCpfSemConta").val("");
    $("#txtObservacoes").val("");
}
//------------------------------------FISICA-------------------------------------------//

function SalvaFisica() {

}

function DelFisica(id) {  

}

function EditFisica(id){

}

function LoadFrmRef() {
    var formRef = $("#frmDep");
    formRef.html("");

    formRef.append(
        "<h3>Informações de Referência</h3></br>" +
        "<div class='form-group'> <label for ='txtNomeRef'>Nome da Referência</label>" +
        "<input type='text' id='txtNomeRef' class='form-control'/></div>"

        +
        "<div class='form-group'><label for='txtFoneRef'>Telefone:</label>" +
        "<input type='text' id='txtFoneRef' class='form-control txtFone'/></div>"
    );

    LoadMask();

}

function LoadFrmDep() {
    var formDep = $("#frmDep");
    formDep.html("");

    formDep.append(
        "<h3>Informações do Dependente</h3></br>" +
        "<div class='form-group'> <label for ='txtNomeDep'>Nome do Dependente</label>" +
        "<input type='text' id='txtNomeDep' class='form-control'/></div>"

        +
        "<div class='form-row'>" +
        "<div class='form-group col-md-6'><label for='txtFoneDep'>Telefone do Dependente:</label>" +
        "<input type='text' id='txtFoneDep' class='form-control txtFone'/></div>" +
        "<div class='form-group col-md-6'><label for='txtCpfDep'>CPF do Dependente:</label>" +
        "<input type='text' id='txtCpfDep' class='form-control txtCpf'/></div>"
    );

    LoadMask();
}

function LimpaCamposFisica() {
    $("#txtNomeFisica").val("");
    $("#txtFoneFisica").val("");
    $("#txtCpfFisica").val("");

    $("#txtNomeDep").val("");
    $("#txtFoneDep").val("");
    $("#txtCpfDep").val("");

    $("#txtNomeRef").val("");
    $("#txtFoneRef").val("");
    $("#selDep").val();
}


//-------------------------------------JURIDICA----------------------------------------//

function LoadFrmInf() {
    var formLim = $("#frmLim");
    formLim.html("");

    formLim.append(
        "<h3>Informações Limite</h3></br>" +
        "<div class='form-group'> <label for ='txtValorLim'>Valor</label>" +
        "<input type='text' id='txtValorLim' class='form-control txtDinheiro'/></div>"
    );

    LoadMask();
}

function LoadFrmIgualSup() {
    var formLim = $("#frmLim");
    formLim.html("");

    formLim.append(

        "<h3>Informações Limite</h3></br>" +

        "<div class='form-row'>" +
        "<div class='form-group col-md-6'><label for='txtNomeLim'>Referência Pessoal:</label>" +
        "<input type='text' id='txtNomeLim' class='form-control txtCpf'/></div>" +
        "<div class='form-group col-md-6'><label for='txtFoneLim'>Telefone Referência:</label>" +
        "<input type='text' id='txtFoneLim' class='form-control txtFone'/></div>" +

        "<div class='form-row'>" +
        "<div class='form-group col-md-6'><label for='txtAgencia'>Agência:</label>" +
        "<input type='text' id='txtAgencia' class='form-control txtAgencia'/></div>" +
        "<div class='form-group col-md-6'><label for='txtConta'>Telefone Conta:</label>" +
        "<input type='text' id='txtConta' class='form-control txtConta'/></div>" +

        "<div class='form-group col'><label>Banco:</label></br>" +
        "<select id='selBanco' class='form-control'>" +
        "<option value='itau'>Itau</option>" +
        "<option value='bradesco'>Bradesco</option></select></div></div>"
    );

    LoadMask();
}

//------------------------------------UTILS--------------------------------//

function LoadMask() {
    $(".txtFone").mask('(00) Z 0000-0000', {
        translation: {
            'Z': {
                pattern: /9/,
                optional: true
            }
        }
    });

    $(".txtCpf").mask('000.000.000-00', {
        reverse: true
    });

    $(".txtDinheiro").mask("#.##0,00", {
        reverse: true
    });

    $(".txtAgencia").mask("0000-0", {
        reverse: true
    });

    $(".txtConta").mask("00.000-0", {
        reverse: true
    });
}
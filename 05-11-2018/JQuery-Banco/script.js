//Definição dos JS
//$(this).hide() - elemento corrente
//$("p").hide() - todos os <p>
//$(".test").hide() - classe igual a teste
//$("#test").hide() - id igual a teste

$(document).ready(function () {
    $("#frmSemConta").hide();
    $("#frmContaFisica").hide();
    $("#frmContaJuridica").hide();
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

//------------------------------------FISICA-------------------------------------------//
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
        "<div class='form-group col-md-6'><label for='txtNomeRef'>Referência Pessoal:</label>" +
        "<input type='text' id='txtNomeRef' class='form-control txtCpf'/></div>" +
        "<div class='form-group col-md-6'><label for='txtFoneRef'>Telefone Referência:</label>" +
        "<input type='text' id='txtFoneRef' class='form-control txtFone'/></div>" +

        "<div class='form-group col-md-12'> <label>Banco:</label><br>" +
        "<select id='selBanco' class='form-control'>" +
        " <option value='itau'>Itau</option>" +
        " <option value='bradesco'>Bradesco</option></select></div>" +    

        "<div class='form-row'>" +
        "<div class='form-group col-md-6'><label for='txtAgenciaRef'>Agência:</label>" +
        "<input type='text' id='txtAgenciaRef' class='form-control'/></div>" +
        "<div class='form-group col-md-6'><label for='txtContaRef'>Conta:</label>" +
        "<input type='text' id='txtContaRef' class='form-control'/></div>" 
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

}
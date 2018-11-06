//Definição dos JS
//$(this).hide() - elemento corrente
//$("p").hide() - todos os <p>
//$(".test").hide() - classe igual a teste
//$("#test").hide() - id igual a teste

$(document).ready(function () {
    $("#frmSemConta").hide();
    $("#frmContaFisica").hide();
    $("#frmContaJuridica").hide();

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



});
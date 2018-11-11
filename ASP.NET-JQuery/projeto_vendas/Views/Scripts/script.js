
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

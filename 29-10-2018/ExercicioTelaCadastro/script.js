

function btnSalvarForm() {
    var flg = 0;
    var _nome = document.getElementById("txtNome").value
    var _fone = document.getElementById("txtTelefone").value
    var _tipoPessoa = document.getElementById("tipoPessoa").value

    if (_nome == "") {
        flg = 1;
        alert("campo NOME obrigatorio");
    }
    if (_fone == "") {
        flg = 1;
        alert("campo TELEFONE obrigatorio");
    }
    if (flg == 0) {
        var lista = document.getElementById("Itens").innerHTML;
        lista += "<tr>"
            + "<td>" + _nome + "</td>"
            + "<td>" + _fone + " </td> "
            + "<td>" + _tipoPessoa + " </td> "
            + "<td> <button class='btn btn-danger' onclick='btnExcluirForm(this.parentNode.parentNode.rowIndex)'>Excluir</button> </td>"
            + "</tr >";


        document.getElementById("Itens").innerHTML = lista;
    }
}

function btnExcluirForm(i) {
    document.getElementById("Itens").deleteRow(i);
}


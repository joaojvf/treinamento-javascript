
//js do html Pagina5
function funcaoTeste() 
{
    document.getElementById("demo").innerHTML = "alterando o texto";
}
//********************************************************************//


//js do html Pagina6
function alteraCor() 
{
    document.getElementById("divTeste").style.backgroundColor = 'blue';
}
//********************************************************************//


//js do html Pagina7
function ExibirArray() 
{
    var fruits, text, fLen, i;

    fruits = ["Banana", "Laranja", "Uva", "Abacaxi"];


    fLen = fruits.length;
    
    text = "<ul>";
    
    for (i = 0; i < fLen; i++) 
    {
        if(fruits[i] == "Laranja")
        {
            text += "<li><b>" + fruits[i] + "</b></li>";
        }
        else
        {
            text += "<li>" + fruits[i] + "</li>";
        }
    };


    for (i = 0; i < fLen; i++) 
    {
        if(fruits[i] == "Laranja")
        {
            text += "<li><b>" + fruits[i] + "</b></li>";
        }
        else
        {
            text += "<li>" + fruits[i] + "</li>";
        }
    };

    text += "</ul>";



    document.getElementById("texto").innerHTML = text;

}
//********************************************************************//

//js do html Pagina8
function trabalhandoComArray() 
{
    var nome = ["Teste1", "Teste2"];

    nome.push("teste 3"); 

    var dados = "";

    for (i = 0; i < nome.length; i++) 
    {
        
        dados += nome[i] + "</br>";
        
    };

    document.getElementById("texto").innerHTML = dados;
    
    nome.pop();              // Removes ultimo

    var dados = "";

    for (i = 0; i < nome.length; i++) 
    {
        
        dados += nome[i] + "</br>";
        
    };

    document.getElementById("texto").innerHTML = dados;
    
    nome.shift();              // Removes primeiro

    var dados = "";

    for (i = 0; i < nome.length; i++) 
    {
        
        dados += nome[i] + "</br>";
        
    };

    document.getElementById("texto").innerHTML = dados;
    
}

//********************************************************************//

//js do html Pagina9

function btnSalvar() 
{
    var nome = [];

    nome.push( document.getElementById("txtNome").value);
    
    var dados = "";

    for (i = 0; i < nome.length; i++) 
    {
        
        dados += nome[i] + "</br>";
        
    };

    document.getElementById("ListaSalva").innerHTML = dados;

}

//********************************************************************//

//js do html Pagina10

function btnSalvarForm() 
{
    var flg = 0;
    var _nome = document.getElementById("txtNome").value
    var _fone =document.getElementById("txtFone").value
    var _endereco =document.getElementById("txtEndereco").value
    
  if(_nome == "")
  {
    flg =1;
    alert("campo NOME obrigatorio");
  }
  if(_fone == "")
  {
    flg =1;
    alert("campo TELEFONE obrigatorio");
  }
  if(_endereco == "")
  {
    flg =1;
    alert("campo ENDERECO obrigatorio");
  }

  if(flg == 0 )
{
  var lista =  document.getElementById("ListaSalva").innerHTML ;
  lista += _nome + " - " +_fone + " - " +_endereco + "</br>" ;
  document.getElementById("ListaSalva").innerHTML = lista;
}

}

//********************************************************************//

//js do html Pagina11
function selectFunction()
{
    
    var selectcor = document.getElementById('selecao').value;
    document.getElementById('cor').style.backgroundColor = selectcor;
}
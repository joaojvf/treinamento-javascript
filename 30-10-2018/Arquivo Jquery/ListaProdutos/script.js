//Definição dos JS
//$(this).hide() - elemento corrente
//$("p").hide() - todos os <p>
//$(".test").hide() - classe igual a teste
//$("#test").hide() - id igual a teste

var listProducts = new Array();
var cart = new Array();
var count = 0, discount = 0;
var total = 0;


$(document).ready(function () {

    $("#ShoppingCart").hide();

    NewProduct("Computador", "1000.00", "Unitário", "images/computer.jpg");
    NewProduct("Notbook Nitro 5", "1500.00", "Unitário", "images/laptop.jpg");
    NewProduct("Impressora HP", "300.00", "Unitário", "images/printer.jpg");
    NewProduct("Folha Sulfite", "5.00", "Pacote", "images/paper.jpg");

    console.log(listProducts);
    PrintProducts();

    $("input[name=selector]:radio").click(function () {
        var id = $(this).attr("value");

        var html = "<center>"
            + "<h3>" + listProducts[id].name + "</h3>"
            + "<img src=" + listProducts[id].img + " class='div-img' ></img>"
            + "</center>"
            + "<div><b>Valor: " + listProducts[id].price + "</b></div>"
            + "<div><b> Unidade: " + listProducts[id].unity + " </b></div>"
            + "<b> Quantidade: </b>"
            + "<input type ='number'  class='input-changeable' id = 'Amount' /> <br><br>"
            + "<input type='button' class='btn btn-success' value='Comprar' onclick='AddToCart(" + listProducts[id].id + ")'/>";

        $("#ProductSelected").html(html);
    });

    $("tr").on("click", ".remover", function (e) {
        $(this).closest('tr').remove();
    });

    $("#Discount").on('keyup', function () {
        var nTotal = GetTotal();
        if (this.value > 100 || this.value < 0) {
            return alert("Digite um desconto válido!");
        } else if (this.value == 0 || this.value == "") {
            $('#TotalPrice').text(nTotal.toFixed(2));
        } else {
            nTotal = (GetTotal() - ((this.value * GetTotal()) / 100));
            $('#TotalPrice').text(nTotal.toFixed(2));
        }
    });

});

function GetTotal() {
    var newTotal = 0;
    for (var i = 0; i < cart.length; i++) {
        newTotal += cart[i].subtotal;
    }
    return newTotal;
}

function NewProduct(name, price, unity, img) {
    var product = new Object();
    product.id = count++;
    product.name = name;
    product.price = price;
    product.unity = unity;
    product.img = img;

    listProducts.push(product);
}

function AddToListCart(id, amount) {
    var newProduct = new Object();
    for (var i = 0; i < listProducts.length; i++) {
        if (listProducts[i].id == id) {
            if (cart.length == 0) {
                newProduct.id = listProducts[i].id;
                newProduct.name = listProducts[i].name;
                newProduct.price = listProducts[i].price;
                newProduct.unity = listProducts[i].unity;
                newProduct.amount = amount;
                var subtotal = parseFloat(listProducts[i].price);
                subtotal = subtotal * amount;
                newProduct.subtotal = subtotal;

                cart.push(newProduct);

                return true;

            } else {
                var pos = findPosition(id);
                for (var j = 0; j < cart.length; j++) {
                    if (cart[j].id == id) {
                        cart[j].amount += amount;
                        cart[j].subtotal = (cart[j].price * cart[j].amount);
                        return false;

                    }
                }

                newProduct.id = id;
                newProduct.name = listProducts[i].name;
                newProduct.price = listProducts[i].price;
                newProduct.unity = listProducts[i].unity;
                newProduct.amount = amount;
                newProduct.subtotal = (listProducts[i].price * amount);
                cart.push(newProduct);

                return true;
            }

        }

    }
}

function findPosition(id) {
    {
        for (var i = 0; i < cart.length; i++) {
            if (cart[i].id == id) {
                return i;
            }
        }
        return -1;
    }
}


function PrintProducts() { //Listar produtos para serem comprados
    var printer = "";

    for (product in listProducts) {
        printer += "<tr>"
            + "<td> <input type='radio' name='selector' value='" + listProducts[product].id + "'>"
            + listProducts[product].name + "</input> </td>"
            + "</tr>";
    }
    $("#tblProducts").html(printer);
}


function AddToCart(id) { //Adicionar a tabela de produtos comprados 
    var amount = $('#Amount').val();
    if (amount <= 0) {
        return alert("A quantidade deve ser maior que 0!");
    } else {
        var control = AddToListCart(id, parseFloat(amount));
        id = findPosition(id);
        console.log(id);
        if (control) {

            if (id >= 0) {
                var line = "<tr id ='" + cart[id].id + "'> <td id = '" + cart[id].id + "A'>" + cart[id].amount + "</td>"
                    + "<td>" + cart[id].name + "</td>"
                    + "<td>" + cart[id].price + "</td>"
                    + "<td id = '" + cart[id].id + "S'>" + cart[id].subtotal + "</td>"
                    + "<td> <input type ='button' class='btn btn-outline-danger' onclick='remove(" + cart[id].id + ", this, " + (cart[id].subtotal) + ")'  value='Excluir'></input> </tr> ";


                var lineTotal = document.getElementById("divTotalPrice").rowIndex;
                var table = document.getElementById("tblShoppingCart");

                var tr = table.insertRow(lineTotal);
                tr.innerHTML = line;

                $('#TotalPrice').text(AddMask(GetTotal().toFixed(2)));
                $("#ShoppingCart").show();


            } else {
                console.log("Erro na busca");

            }

        } else {
            $("#" + cart[id].id + "A").text(cart[id].amount);
            $("#" + cart[id].id + "S").text(cart[id].subtotal);
            $('#TotalPrice').text(AddMask(GetTotal().toFixed(2)));
        }
    }

}


function AddMask(value) {
    return "R$ " + value.replace('.', ',').replace(/(\d)(?=(\d{3})+\,)/g, "$1.");
}


function deleteList(id) {
    var newCart = new Array();
    for (var i = 0; i < cart.length; i++) {
        if (cart[i].id != id) {
            newCart[i] = cart[i];
        }
    }

    cart = newCart;
}


(function ($) {
    remove = function (id, item, price) {
        var tr = $(item).closest('tr');
        tr.fadeOut(function () {
            tr.remove();
        });
        deleteList(id);


        console.log(cart);
        $('#TotalPrice').text(AddMask(GetTotal().toFixed(2)));



        return false;
    }
})(jQuery);

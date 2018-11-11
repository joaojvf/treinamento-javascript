using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Objects.Objetos
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public Fornecedor Fornecedor { get; set; }
    }
}
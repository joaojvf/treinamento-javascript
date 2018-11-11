using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Objects.Objetos
{
    public class Itens
    {
        public Venda Venda { get; set; }
        public Cliente Cliente { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
    }
}
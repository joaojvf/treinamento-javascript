using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Objects.Objetos
{
    public class Venda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataVenda { get; set; }
        public double TotalVenda { get; set; }

    }
}
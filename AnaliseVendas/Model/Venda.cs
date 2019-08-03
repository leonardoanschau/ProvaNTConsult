using System;
using System.Collections.Generic;
using System.Text;

namespace AnaliseVendas.Model
{
    public class Venda
    {
        public int Id { get; set; }
        public List<ItemVenda> ItemVendas { get; set; }

        public Vendedor Vendedor { get; set; }
        public Venda()
        {
            ItemVendas = new List<ItemVenda>();
        }
    }
}

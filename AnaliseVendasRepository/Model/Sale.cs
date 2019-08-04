using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnaliseVendas.Model
{
    public class Sale
    {
        public int Id { get; set; }
        public List<SaleItem> SaleItems { get; set; }
        public string Salesman { get; set; }

        public double Total
        {
            get
            {
                return this.SaleItems.Sum(x => x.Price * x.Quantity);
            }
        }

        public Sale()
        {
            SaleItems = new List<SaleItem>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AnaliseVendasRepository.Model
{
    public class Report
    {
        public int ClientCount { get; set; }
        public int SalesmanCount { get; set; }

        public int ExpensiveSaleId { get; set; }

        public string WorstSalesman { get; set; }
    }
}

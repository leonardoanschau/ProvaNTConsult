using AnaliseVendas.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnaliseVendasRepository.Model
{
    public class DataFile
    {
        public List<Client> Clients { get; set; }
        public List<Sale> Sales { get; set; }
        public List<Salesman> Salesman { get; set; }

        public DataFile()
        {
            Clients = new List<Client>();
            Sales = new List<Sale>();
            Salesman = new List<Salesman>();
        }
    }
}

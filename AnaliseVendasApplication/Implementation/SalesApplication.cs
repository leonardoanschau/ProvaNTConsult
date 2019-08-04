using AnaliseVendas.Model;
using AnaliseVendasApplication.Interface;
using AnaliseVendasRepository.Interface;
using AnaliseVendasRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnaliseVendas.Service
{
    public class SalesApplication: ISalesApplication
    {
        private readonly ISaleRepository _saleRepository;

        public SalesApplication(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public Report Process()
        {
            List<DataFile> files = new List<DataFile>();
            string[] dataFiles = _saleRepository.SearchAllDataFiles();

            foreach (string file in dataFiles)
            {
                files.Add(_saleRepository.ReadDataFile(file));
            }

            return this.Report(files);
        }

        public string[] SearchAllDataFiles()
        {
            string[] filesPath = _saleRepository.SearchAllDataFiles();

            return filesPath;
        }

        public Report Report(List<DataFile> dataFiles)
        {
            Report report = new Report();
            List<Client> clients = new List<Client>();
            List<Salesman> salesmen = new List<Salesman>();
            List<Sale> sales = new List<Sale>();

            foreach (var dataFile in dataFiles)
            {
                clients.AddRange(dataFile.Clients.Select(x => x).ToList());
                salesmen.AddRange(dataFile.Salesman.Select(x => x).ToList());
                sales.AddRange(dataFile.Sales.Select(x => x).ToList());
            }

            report.ClientCount = clients.Count;
            report.SalesmanCount = salesmen.Count;
            report.ExpensiveSaleId = sales.OrderByDescending(x => x.Total).First().Id;
            report.WorstSalesman = sales.OrderBy(x => x.Total).First().Salesman;

            _saleRepository.SaveReport(report);

            return report;
        }

    }

}

using AnaliseVendasApplication.Interface;
using AnaliseVendasRepository.Interface;
using AnaliseVendasRepository.Model;
using System;
using System.Collections.Generic;
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

        public List<DataFile> Process()
        {
            List<DataFile> files = new List<DataFile>();
            string[] dataFiles = _saleRepository.SearchAllDataFiles();

            foreach (string file in dataFiles)
            {
                files.Add(_saleRepository.ReadDataFile(file));
            }

            return files;
        }

        public string[] SearchAllDataFiles()
        {
            string[] filesPath = _saleRepository.SearchAllDataFiles();

            return filesPath;
        }

    }

}

using AnaliseVendas.Model;
using AnaliseVendasRepository.Enumerator;
using AnaliseVendasRepository.Interface;
using AnaliseVendasRepository.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AnaliseVendas.Repository
{
    public class SaleRepository : ISaleRepository
    {
        public string[] SearchAllDataFiles()
        {
            return Directory.GetFiles($"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\data\\in\\", " *.dat", SearchOption.AllDirectories);
        }

        public DataFile ReadDataFile(string path)
        {
            DataFile dataFile = new DataFile();

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                List<string> lineDetails = line.Split('ç').ToList();

                int layoutId = int.Parse(lineDetails.First());

                switch (layoutId)
                {
                    case (int)EnumLayoutId.Salesman:
                        dataFile.Salesman.Add(this.MakeSalesman(lineDetails));
                        break;
                    case (int)EnumLayoutId.Client:
                        dataFile.Clients.Add(this.MakeClient(lineDetails));
                        break;
                    case (int)EnumLayoutId.Sale:
                        dataFile.Sales.Add(this.MakeSale(lineDetails));
                        break;
                    default:
                        //log error
                        break;
                }
            }

            return dataFile;
        }

        private Salesman MakeSalesman(List<string> linhas)
        {
            return new Salesman
            {
                Cpf = linhas.ElementAt(1),
                Name = linhas.ElementAt(2),
                Salary = double.Parse(linhas.ElementAt(3))
            };
        }

        private Client MakeClient(List<string> line)
        {
            return new Client
            {
                Cnpj = line.ElementAt(1),
                Name = line.ElementAt(2),
                BusinessArea = line.ElementAt(3)
            };
        }

        private Sale MakeSale(List<string> line)
        {
            List<SaleItem> saleItem = new List<SaleItem>();

            string[] arraySaleItem = line.ElementAt(2).Replace("[", string.Empty).Replace("]", string.Empty).Split(',');

            foreach (var saleItemDetail in arraySaleItem)
            {
                saleItem.Add(this.MakeSaleItem(saleItemDetail));
            }

            return new Sale
            {
                Id = int.Parse(line.ElementAt(1)),
                SaleItems = saleItem,
                Salesman = line.ElementAt(3)
            };
        }

        private SaleItem MakeSaleItem(string line)
        {
            List<string> saleItem = line.Split('-').ToList();

            return new SaleItem
            {
                Id = int.Parse(saleItem.ElementAt(0)),
                Quantity = int.Parse(saleItem.ElementAt(1)),
                Price = double.Parse(saleItem.ElementAt(2))
            };
        }

        public void SaveReport(Report report)
        {
            StringBuilder content = new StringBuilder();

            content.AppendLine($"Quantidade de Clientes no arquivo de entrada: {report.ClientCount}");
            content.AppendLine($"Quantidade de Vendedores no arquivo de entrada: {report.SalesmanCount}");
            content.AppendLine($"ID da venda mais cara: {report.ExpensiveSaleId}");
            content.AppendLine($"Pior vendedor: {report.WorstSalesman}");

            File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\data\\out\\flat_file_name.done.dat", content.ToString());
        }
    }

}

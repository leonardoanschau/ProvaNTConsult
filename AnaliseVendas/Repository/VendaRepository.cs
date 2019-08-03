using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AnaliseVendas.Repository
{
    public class VendaRepository
    {
        public string[] SearchAllDataFiles()
        {
            return Directory.GetFiles(@"C:\Projetos_Testes\data\in\", "*.dat", SearchOption.AllDirectories);
        }

        public void ReadDataFile(string path)
        {
            try
            {
                StreamReader reader = new StreamReader(path);

                while (!reader.EndOfStream)
                {
                    string data = reader.ReadLine();

                    Console.WriteLine(data);
                }
            }
            catch (Exception)
            {

            }

        }
        public void SaveDataFile()
        {

        }
    }
}

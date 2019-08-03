using AnaliseVendas.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnaliseVendas.Service
{
    public class VendaService
    {
        private void SearchAllDataFiles()
        {
            VendaRepository vendaRepository = new VendaRepository();

            string[] filesPath = vendaRepository.SearchAllDataFiles();

            foreach (string file in filesPath)
            {

            }
        }

    }

}

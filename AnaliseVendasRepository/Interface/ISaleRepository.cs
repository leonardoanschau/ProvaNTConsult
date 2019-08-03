using AnaliseVendasRepository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnaliseVendasRepository.Interface
{
    public interface ISaleRepository
    {
        string[] SearchAllDataFiles();
        DataFile ReadDataFile(string path);
    }
}

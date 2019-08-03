using AnaliseVendasRepository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnaliseVendasApplication.Interface
{
    public interface ISalesApplication
    {
        string[] SearchAllDataFiles();
        List<DataFile> Process();
    }
}

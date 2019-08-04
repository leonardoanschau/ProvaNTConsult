using System;
using System.Collections.Generic;
using System.Text;

namespace AnaliseVendasApplication.Interface
{
    public interface ISalesHostedService
    {
        void Process(object state);
    }
}

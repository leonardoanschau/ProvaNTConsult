using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnaliseVendasApplication.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AnaliseVendasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesApplication _salesApp;
        public SalesController(ISalesApplication salesApp)
        {
            _salesApp = salesApp;
        }
    }
}

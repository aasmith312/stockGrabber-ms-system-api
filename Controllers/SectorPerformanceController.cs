using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using stockGrabber_ms_system_api.Contracts.Interfaces;
using stockGrabber_ms_system_api.Implementation.Entites;
using stockGrabber_ms_system_api.Implementation.Entites.Base;
using stockGrabber_ms_system_api.Implementation.Interfaces;

namespace stockGrabber_ms_system_api.Controllers
{
    [Route("api/[controller]")]
    public class SectorPerformanceController : Controller
    {
        ISectorPerformanceRepository repo;
        public SectorPerformanceController(ISectorPerformanceRepository repo)
        {
            this.repo = repo;
        }

        // GET api/values
        [HttpGet("{.format?}"), FormatFilter]
        public IActionResult Get([FromQuery] string format)
        {
            var retObj = this.repo.GetSectorPerformance();

            return new ObjectResult(retObj);
        }


        
    }
}

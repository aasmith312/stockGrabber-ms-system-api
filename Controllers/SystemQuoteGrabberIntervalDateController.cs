using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stockGrabber_ms_system_api.Contracts.Interfaces;
using stockGrabber_ms_system_api.Implementation.Entites;
using stockGrabber_ms_system_api.Implementation.Entites.Base;
using stockGrabber_ms_system_api.Implementation.Interfaces;

namespace stockGrabber_ms_system_api.Controllers
{
    [Route("api/[controller]")]
    public class SystemQuoteGrabberIntervalDateController : Controller
    {
        IIntervalDateQuoteRepository repo;
        public SystemQuoteGrabberIntervalDateController(IIntervalDateQuoteRepository repo)
        {
            this.repo = repo;
        }

        // GET api/values
        [HttpGet]
        public IntervalDateQuote Get()
        {
            var retObj = new IntervalDateQuote();
            retObj.Add(new DateQuote(){
                        Open = 1.0M,
                        High = 1.0M,
                        Low = 1.0M,
                        Close = 1.0M,
                        Volume = 1.0M,
                        MetaData = new MetaData(){
                            TimeZone = "US/Eastern",
                            LastRefresh = DateTime.UtcNow.AddHours(5),
                            Symbol = "IBM"
                        }
            });

            return retObj;
        }

        [HttpGet("{ticker}/{interval}")]
        public IEnumerable<IDateQuote> Get(string ticker, int interval)
        {
            return repo.GetQuotes(ticker, interval);
        }

        // GET api/values/5
        [HttpGet("{ticker}"), FormatFilter]
        public IIntervalDateQuote Get(string ticker)
        {
            var retObj = repo.GetQuotes(ticker, 0); 
            return retObj;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            


        }



        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Threading.Tasks;
using Avapi;
using Avapi.AvapiTIME_SERIES_DAILY;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Microsoft.Extensions.Configuration;
using stockGrabber_ms_system_api.Implementation.Entites;
using System.Collections.Generic;

namespace stockGrabber_ms_system_api.Implementation.Interfaces
{
    public class SectorPerformanceRepository : ISectorPerformanceRepository
    {
        IConfiguration _configuration;

        public SectorPerformanceRepository()
        {
        }

        public SectorPerformanceRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public SectorDatas GetSectorPerformance()
        {

            var connection = AvapiConnection.Instance;
            Console.WriteLine($"suboption1 = {_configuration["Data:ApiProviderKey"]}");

            connection.Connect("I7EOK16FWL1N1LKM");

            var sectorPerformance= connection.GetQueryObject_SECTOR();
            var results = sectorPerformance.QueryPrimitive();
            var data = results.Data;

            return new SectorDatas(data);
        }




    }



}
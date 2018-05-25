using System;
using System.Threading.Tasks;
using Avapi;
using Avapi.AvapiTIME_SERIES_DAILY;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Microsoft.Extensions.Configuration;
using stockGrabber_ms_system_api.Implementation.Entites;

namespace stockGrabber_ms_system_api.Implementation.Interfaces
{
    public class IntervalDateQuoteRepository : IIntervalDateQuoteRepository
    {
        IConfiguration _configuration;

        public IntervalDateQuoteRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public IntervalDateQuote GetQuotes(string ticker, int interval)
        {
            var connection = AvapiConnection.Instance;
            Console.WriteLine($"suboption1 = {_configuration["Data:ApiProviderKey"]}");

            connection.Connect("I7EOK16FWL1N1LKM");

            // Get the TIME_SERIES_DAILY query object
            var time_series_daily =
                connection.GetQueryObject_TIME_SERIES_DAILY();

            // Perform the TIME_SERIES_DAILY request and get the result
            var time_series_dailyResponse = 
            time_series_daily.Query(
                 ticker,
                 Const_TIME_SERIES_DAILY.TIME_SERIES_DAILY_outputsize.compact);

            var data = time_series_dailyResponse.Data;

            if(data.Error)
                throw new ApplicationException(data.ErrorMessage);

            return new IntervalDateQuote(time_series_dailyResponse.Data);
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }


    }
}
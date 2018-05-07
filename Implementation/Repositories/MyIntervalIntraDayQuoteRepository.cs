using System;
using System.Threading.Tasks;
using Avapi;
using Avapi.AvapiTIME_SERIES_DAILY;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using stockGrabber_ms_system_api.Implementation.Entites;

namespace stockGrabber_ms_system_api.Implementation.Interfaces
{
    public class MyIntervalIntraDayQuoteRepository : IIntervalDateQuoteRepository
    {
        public IntervalDateQuote GetQuotes(string ticker, int interval)
        {
            //https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=MSFT&interval=15min&outputsize=full&apikey=demo
            //https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&outputsize=full&apikey=I7EOK16FWL1N1LKM
            //https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=MSFT&interval=5min&outputsize=full&apikey=I7EOK16FWL1N1LKM
 
            var client = new RestSharp.RestClient("https://www.alphavantage.co");
            var request = new RestRequest("query", Method.GET);
            request.AddQueryParameter("function", "TIME_SERIES_INTRADAY");
            request.AddQueryParameter("symbol", ticker);
            request.AddQueryParameter("interval", String.Format("{0}min", interval));
            request.AddQueryParameter("outputsize", "full");
            request.AddQueryParameter("apikey", "");

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            var jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);


            return new IntervalDateQuote();
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
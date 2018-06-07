using System;
using stockGrabber_ms_system_api.Contracts.Interfaces;

namespace stockGrabber_ms_system_api.Implementation.Entites.Base
{
    [Serializable]
    public class MetaData : IMetaData
    {
        public string Info { get; set; }
        public string Symbol { get; set; }
        public DateTime LastRefresh { get; set; }
        public string TimeZone { get; set; }

        public MetaData(){}
        public MetaData(Avapi.AvapiTIME_SERIES_DAILY.MetaData_Type_TIME_SERIES_DAILY metaData)
        {
            this.Info = metaData.Information;
            this.Symbol = metaData.Symbol;
            this.LastRefresh = DateTime.Parse(metaData.LastRefreshed);
            this.TimeZone = metaData.TimeZone;
        }

        public MetaData(string info, string symbol, string lastRefresh, string timeZone)
        {
            this.Info = info;
            this.Symbol = symbol;
            this.LastRefresh = DateTime.Parse(lastRefresh);
            this.TimeZone = timeZone;
        }
    }
}
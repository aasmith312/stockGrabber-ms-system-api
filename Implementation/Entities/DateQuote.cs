using System;
using stockGrabber_ms_system_api.Contracts.Interfaces;
using stockGrabber_ms_system_api.Implementation.Entites.Base;

namespace stockGrabber_ms_system_api.Implementation.Entites
{
    [Serializable]
    public class DateQuote : Quote, IDateQuote
    {
        public DateTime DateStamp {get; set;}
        
        public DateQuote(){}
        public DateQuote(Avapi.AvapiTIME_SERIES_DAILY.TimeSeries_Type_TIME_SERIES_DAILY item) : this()
        {
            this.Close = Decimal.Parse(item.close);
            this.High = Decimal.Parse(item.high);
            this.Low = Decimal.Parse(item.low);
            this.Open = Decimal.Parse(item.open);
            this.DateStamp = DateTime.Parse(item.DateTime);
            this.Volume = Decimal.Parse(item.volume);
        }


        public DateQuote(Avapi.AvapiTIME_SERIES_DAILY.TimeSeries_Type_TIME_SERIES_DAILY item, MetaData metaData) 
        : this(item)
        {
            this.MetaData = metaData;
        }

    }
}
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using stockGrabber_ms_system_api.Contracts.Interfaces;
using stockGrabber_ms_system_api.Implementation.Entites.Base;

namespace stockGrabber_ms_system_api.Implementation.Entites
{
    public class IntervalDateQuote : List<IDateQuote>, IIntervalDateQuote
    {
        public IntervalDateQuote(){}
        public IntervalDateQuote(Avapi.AvapiTIME_SERIES_DAILY.IAvapiResponse_TIME_SERIES_DAILY_Content data)
        {
                this.MetaData = new MetaData(data.MetaData);

                foreach(var item in data.TimeSeries)
                {
                    this.Add(new DateQuote(item, this.MetaData));
                }
        }

        public IMetaData MetaData {get;set;}
    }
}
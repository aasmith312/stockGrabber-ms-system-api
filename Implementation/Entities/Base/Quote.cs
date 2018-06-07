using System;
using  stockGrabber_ms_system_api.Contracts.Interfaces;

namespace stockGrabber_ms_system_api.Implementation.Entites.Base
{
    [Serializable]
    public class Quote : IQuote
    {
        public MetaData MetaData { get; set;}

        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }

        public Quote(){}
        public Quote(MetaData metaData)
        {
            this.MetaData = metaData;
        }


    }
}
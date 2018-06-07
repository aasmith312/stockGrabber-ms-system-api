using stockGrabber_ms_system_api.Contracts.Interfaces;
using stockGrabber_ms_system_api.Implementation.Entites.Base;

namespace stockGrabber_ms_system_api.Contracts.Interfaces
{
    public interface IQuote
    {
        decimal Open { get; set; }
        decimal High { get; set; }
        decimal Low { get; set; }
        decimal Close { get; set; }
        decimal Volume { get; set; }
        MetaData MetaData {get;set;}
    }
}
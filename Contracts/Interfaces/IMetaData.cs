using System;

namespace stockGrabber_ms_system_api.Contracts.Interfaces
{
    public interface IMetaData
    {
        string Info { get; set; }
        string Symbol { get; set; }
        DateTime LastRefresh { get; set; }
        string TimeZone { get; set; }
    }
}
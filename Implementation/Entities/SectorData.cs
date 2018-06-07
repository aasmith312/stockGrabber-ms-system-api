using System.Collections.Generic;
using System.Reflection;
using Avapi.AvapiSECTOR;

namespace stockGrabber_ms_system_api.Implementation.Entites
{
    public class SectorData
    {
        public string RankName { get; set; }
        List<SectorToValuePair> _values = new List<SectorToValuePair>();
        public List<SectorToValuePair> Values
        {
            get { return this._values; }
            set { this._values = value; }
        }
        public SectorData()
        {



        }
        public SectorData(IAvapiResponse_SECTOR_Content data)
        {

        }
    }
}
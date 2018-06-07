namespace stockGrabber_ms_system_api.Implementation.Entites
{
    public class SectorToValuePair
    {
        public string SectorName{get;set;}
        public decimal Percent {get;set;}

        public SectorToValuePair(){}
        public SectorToValuePair(string sectorName, string value)
        {
            this.SectorName = sectorName;
            var tmpResult = decimal.Zero;
            
            value = value.Replace("%", string.Empty);

            if(decimal.TryParse(value, out tmpResult)){
                this.Percent = tmpResult;
            }
        }
    }
}
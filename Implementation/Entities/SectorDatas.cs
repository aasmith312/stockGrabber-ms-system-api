using System.Collections.Generic;
using Avapi.AvapiSECTOR;
using stockGrabber_ms_system_api.Implementation.Entites;

namespace stockGrabber_ms_system_api.Implementation.Entites
{
    public class SectorDatas : List<SectorData>
    {
        private IAvapiResponse_SECTOR_Content data;

        public SectorDatas(IAvapiResponse_SECTOR_Content data)
        {
            this.data = data;

            foreach (var item in data.GetType().GetProperties())
            {
                if (item.Name.ToUpper().Contains("RANK"))
                {
                    var tmpData = item.GetValue(data);

                    var tmpSectorData = new SectorData();
                    foreach (var strItem in tmpData.GetType().GetProperties())
                    {
                        var tmpInnerData = strItem.GetValue(tmpData);

                        if (tmpInnerData.GetType() == typeof(string))
                        {
                            if (strItem.Name.Equals("RankName"))
                            {
                                tmpSectorData.RankName = tmpInnerData as string;
                            }
                            else
                            {
                                tmpSectorData.Values.Add(new SectorToValuePair(strItem.Name, tmpInnerData as string));
                            }
                        }
                    }
                    this.Add(tmpSectorData);
                }
            }
        }
    }
}
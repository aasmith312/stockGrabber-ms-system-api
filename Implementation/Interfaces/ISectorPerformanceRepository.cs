using stockGrabber_ms_system_api.Implementation.Entites;

namespace stockGrabber_ms_system_api.Implementation.Interfaces
{
    public interface ISectorPerformanceRepository
    {
        SectorDatas GetSectorPerformance();
    }
}
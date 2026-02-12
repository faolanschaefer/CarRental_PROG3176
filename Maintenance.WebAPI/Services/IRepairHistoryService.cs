using Maintenance.WebAPI.DTOs;

namespace Maintenance.WebAPI.Services
{
    public interface IRepairHistoryService
    {
        List<RepairHistoryDto> GetByVehicleId(int vehicleId);
    }
}

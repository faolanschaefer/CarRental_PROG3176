using Maintenance.WebAPI.DTOs;

namespace Maintenance.WebAPI.Services
{
    public interface IRepairHistoryService
    {
        IEnumerable<RepairHistoryDto> GetByVehicleId(int vehicleId);
        RepairHistoryDto AddRepair(RepairHistoryDto record);
    }
}

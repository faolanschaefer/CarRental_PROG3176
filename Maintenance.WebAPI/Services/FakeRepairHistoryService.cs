using Maintenance.WebAPI.DTOs;

namespace Maintenance.WebAPI.Services
{
    public class FakeRepairHistoryService : IRepairHistoryService
    {
        private List<RepairHistoryDto> fakeData = new List<RepairHistoryDto>();
        public RepairHistoryDto AddRepair(RepairHistoryDto record)
        {
            record.Id = fakeData.Count + 1; // Simulate auto-increment ID
            fakeData.Add(record);
            return record;
        }

        public IEnumerable<RepairHistoryDto> GetByVehicleId(int vehicleId)
        {
            var results = fakeData.Where(r => r.VehicleId == vehicleId);
            return results.Any() ? results.ToList() :
            new List<RepairHistoryDto>() {
                new RepairHistoryDto
                {
                    Id = 1,
                    VehicleId = vehicleId,
                    RepairDate = DateTime.Now.AddDays(-10),
                    Description = "Oil change",
                    Cost = 89.99m,
                    PerformedBy = "Quick Lube"
                },
                new RepairHistoryDto
                {
                    Id = 2,
                    VehicleId = vehicleId,
                    RepairDate = DateTime.Now.AddDays(-40),
                    Description = "Brake pad replacement",
                    Cost = 350.00m,
                    PerformedBy = "Auto Repair Pro"
                }
            };
        }
    }
}

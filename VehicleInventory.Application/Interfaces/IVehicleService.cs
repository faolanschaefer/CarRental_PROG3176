using VehicleInventory.Application.DTOs;

namespace VehicleInventory.Application.Interfaces
{
    public interface IVehicleService
    {

        VehicleDto CreateVehicle(CreateVehicleDto dto);

        VehicleDto GetVehicleById(int id);

        IEnumerable<VehicleDto> GetAllVehicles();

        void UpdateVehicleStatus(int id, UpdateVehicleStatusDto dto);

        void ReleaseVehicleReservation(int id);

        void DeleteVehicle(int id);
    }
}

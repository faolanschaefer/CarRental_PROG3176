using System.Text.Json.Serialization;

namespace VehicleInventory.Domain.Vehicle
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VehicleStatus
    {
        Available,
        Reserved,
        Rented,
        Maintenance
    }
}

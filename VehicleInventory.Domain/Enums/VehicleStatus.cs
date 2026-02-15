using System.Text.Json.Serialization;

namespace VehicleInventory.Domain.Enums
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

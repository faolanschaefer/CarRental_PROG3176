using System.Text.Json.Serialization;

namespace VehicleInventory.Domain.Vehicle
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VehicleType
    {
        Sedan,
        SUV,
        Truck,
        Van
    }
}

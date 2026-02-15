using System.Text.Json.Serialization;

namespace VehicleInventory.Domain.Enums
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

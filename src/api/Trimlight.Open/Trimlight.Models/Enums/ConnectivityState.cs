using System.Text.Json.Serialization;

namespace Trimlight.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ConnectivityState : byte
{
    Offline = 0,
    Online = 1,
}
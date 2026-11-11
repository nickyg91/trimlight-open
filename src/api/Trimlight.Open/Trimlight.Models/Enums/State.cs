using System.Text.Json.Serialization;

namespace Trimlight.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum State : byte
{
    Normal = 0,
    Upgrading = 1
}
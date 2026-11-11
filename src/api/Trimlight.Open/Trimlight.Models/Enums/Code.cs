using System.Text.Json.Serialization;

namespace Trimlight.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Code : short
{
    Success = 0,
    Error = 10001,
    WrongPassword = 10002,
}
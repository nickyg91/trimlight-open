using System.Text.Json.Serialization;

namespace Trimlight.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SwitchState : byte
{
    LightOff = 0,
    ManualMode = 1,
    TimerMode = 2,
}
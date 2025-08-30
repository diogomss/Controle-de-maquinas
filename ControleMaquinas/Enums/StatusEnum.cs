using System.Text.Json.Serialization;

namespace ControleMaquinas.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusEnum
    {
        Operando, 
        ParadaParaManutenção,
        Desligada
    }
}

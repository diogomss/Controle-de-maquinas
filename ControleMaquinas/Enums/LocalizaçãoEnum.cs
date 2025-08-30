using System.Text.Json.Serialization;

namespace ControleMaquinas.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))] //Tranforma o enum em string no JSON
    public enum LocalizaçãoEnum
    {
        Estamparia,
        Pintura,
        Montagem,
        Embalagem,
        Expedição
    }
}

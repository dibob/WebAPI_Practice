using System.Text.Json.Serialization;

namespace WebAPI_Practice.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HealthCareEnum
   {
      SUS,
      Plano,
      Particular
   }
}

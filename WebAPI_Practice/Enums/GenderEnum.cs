using System.Text.Json.Serialization;

namespace WebAPI_Practice.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
   public enum GenderEnum
   {
      Female,
      Male
   }
}

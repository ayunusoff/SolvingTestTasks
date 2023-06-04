using System.Text.Json.Serialization;

namespace AltPoint.Application.DTOs.Errors
{
    public class Error
    {
        public int status { get; set; }
        public ErrorCode code { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ErrorException>? exceptions { get; set; }
    }
}

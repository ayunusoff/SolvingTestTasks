using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AltPoint.Application.DTOs.Errors
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum ErrorCode
    {
        ENTITY_NOT_FOUND,
        VALIDATION_EXCEPTION,
        INTERNAL_SERVER_ERROR
    }
}

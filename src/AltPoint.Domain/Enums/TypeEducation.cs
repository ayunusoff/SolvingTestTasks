using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AltPoint.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TypeEducation
    {
        secondary,// - Среднее
        secondarySpecial,// - Среднее специальное
        incompleteHigher,// - Незаконченное высшее
        higher,// - Высшее
        twoOrMoreHigher,// - Два и более высших образований
        academicDegree// - Академическая степень
    }
}

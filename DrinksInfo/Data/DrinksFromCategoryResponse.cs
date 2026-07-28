using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;

namespace DrinksInfo.Data
{
    internal record DrinksFromCategoryResponse(
        [property: JsonPropertyName("drinks")] List<DrinkMinimalInfo> DrinkMinimals
        );
}

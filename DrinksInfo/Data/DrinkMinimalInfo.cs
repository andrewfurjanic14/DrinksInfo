using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DrinksInfo.Data
{
    internal record DrinkMinimalInfo(
            [property: JsonPropertyName("strDrink")] string Name,
            [property: JsonPropertyName("idDrink")] string Id
        )
    {
        public override string ToString()
        {
            return Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DrinksInfo.Data
{
    internal record DrinkCategory(
            [property: JsonPropertyName("strCategory")] string Name
            )
    {
        public string SearchableName => Name.Replace(" ", "_");
        public override string ToString()
        {
            return Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DrinksInfo.Data
{
    internal record Drink(
        [property: JsonPropertyName("idDrink")] string? Id = null,
        [property: JsonPropertyName("strDrink")] string? Name = null,
        [property: JsonPropertyName("strGlass")] string? Glass = null,
        [property: JsonPropertyName("strInstructions")] string? Instructions = null,
        [property: JsonPropertyName("strIngredient1")] string? Ingredient1 = null,
        [property: JsonPropertyName("strIngredient2")] string? Ingredient2 = null,
        [property: JsonPropertyName("strIngredient3")] string? Ingredient3 = null,
        [property: JsonPropertyName("strIngredient4")] string? Ingredient4 = null,
        [property: JsonPropertyName("strIngredient5")] string? Ingredient5 = null,
        [property: JsonPropertyName("strIngredient6")] string? Ingredient6 = null,
        [property: JsonPropertyName("strMeasure1")] string? Measure1 = null,
        [property: JsonPropertyName("strMeasure2")] string? Measure2 = null,
        [property: JsonPropertyName("strMeasure3")] string? Measure3 = null,
        [property: JsonPropertyName("strMeasure4")] string? Measure4 = null,
        [property: JsonPropertyName("strMeasure5")] string? Measure5 = null,
        [property: JsonPropertyName("strMeasure6")] string? Measure6 = null
        )
    {
        public override string ToString()
        {
            var ingredients = new[] { Ingredient1, Ingredient2, Ingredient3, Ingredient4, Ingredient5, Ingredient6 }
                .Where(x => !string.IsNullOrEmpty(x));

            var measures = new[] { Measure1, Measure2, Measure3, Measure4, Measure5, Measure6 }
                .Where(x => !string.IsNullOrEmpty(x));

            var zipped = ingredients
                .Zip(measures, (i, m) => $"Ingredient: {i}\n\tMeasure:{m}\n")
                .ToList();

            string output = 
                $"""
                Id - {Id}
                Name - {Name}
                Glass - {Glass}

                """;
            foreach (var str in zipped)
            {
                output += str;
            }

            output += Instructions;

            return output;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DrinksInfo.Data
{
    internal record DrinkFromIdResponse(
        List<Drink> Drinks
        )
    {
        public Drink Drink => Drinks.FirstOrDefault() 
            ?? throw new InvalidOperationException("Drink from Id response failed");
    }
}

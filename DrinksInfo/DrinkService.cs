using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using DrinksInfo.Data;

namespace DrinksInfo
{
    internal class DrinkService
    {
        HttpClient _client;
        public DrinkService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/");
        }

        public async Task<List<DrinkCategory>> GetCategoriesAsync()
        {
            var response = await _client.GetFromJsonAsync<DrinkCategoryResponse>("/api/json/v1/1/list.php?c=list");
            if (response is null)
                throw new InvalidOperationException("API [drink category] response failed");
            return response.Categories;
        }

        public async Task<List<DrinkMinimalInfo>> GetDrinkMinimalsFromCategoryAsync(DrinkCategory category)
        {
            var name = category.SearchableName;
            var response = await _client.GetFromJsonAsync<DrinksFromCategoryResponse>($"/api/json/v1/1/filter.php?c={name}");
            if (response is null)
                throw new InvalidOperationException("API [drinks from category] response failed");
            return response.DrinkMinimals;
        }

        public async Task<Drink> GetDrinkFromIdAsync(string id)
        {
            var response = await _client.GetFromJsonAsync<DrinkFromIdResponse>($"/api/json/v1/1/lookup.php?i={id}");
            if (response is null)
                throw new InvalidOperationException("API [drink from id] response failed");
            return response.Drink;
        }
    }
}

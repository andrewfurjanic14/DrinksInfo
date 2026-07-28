using DrinksInfo.Data;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrinksInfo.Views
{
    internal class UI
    {
        private DrinkService _drinkService;
        public UI(HttpClient client)
        {
            _drinkService = new DrinkService(client);
        }
        public async Task RunAsync()
        {
            await Menu();
        }
        private async Task Menu()
        {
            var categories = await _drinkService.GetCategoriesAsync();
            bool exit = false;

            while (!exit)
            {
                var choice = PromptService.SelectDrinkCategory(categories);
                switch (choice.Action)
                {
                    case UserAction.Select:
                        var category = choice.Data;
                        await ChooseDrink(category);
                        break;
                    case UserAction.Exit:
                        exit = true;
                        break;
                }
            }
        }

        private async Task ChooseDrink(DrinkCategory category)
        {
            var minimals = await _drinkService.GetDrinkMinimalsFromCategoryAsync(category);
            bool exit = false;

            while (!exit)
            {
                var choice = PromptService.SelectDrink(minimals);
                switch (choice.Action)
                {
                    case UserAction.Select:
                        var minimalInfo = choice.Data;
                        var drink = await _drinkService.GetDrinkFromIdAsync(minimalInfo.Id);
                        Console.WriteLine(drink);
                        break;
                    case UserAction.Exit:
                        exit = true;
                        break;
                }
            }

        }
    }
}

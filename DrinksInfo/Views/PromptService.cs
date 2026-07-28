using DrinksInfo.Data;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrinksInfo.Views
{
    internal static class PromptService
    {
        public static UserOption<DrinkCategory> SelectDrinkCategory(IEnumerable<DrinkCategory> categories)
        {
            var choices = categories.ToUserOptions(x => x.Name)
                .Prepend(new UserOption<DrinkCategory>("Exit", UserAction.Exit));

            UserOption<DrinkCategory> choice = AnsiConsole.Prompt(
                new SelectionPrompt<UserOption<DrinkCategory>>()
                    .AddChoices(choices)
                );
            return choice;
        }

        public static UserOption<DrinkMinimalInfo> SelectDrink(IEnumerable<DrinkMinimalInfo> drinkMinimals)
        {
            var choices = drinkMinimals.ToUserOptions(x => x.Name ?? throw new InvalidOperationException())
                .Prepend(new UserOption<DrinkMinimalInfo>("Exit", UserAction.Exit));

            var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<UserOption<DrinkMinimalInfo>>()
                        .AddChoices(choices)
                );
            return choice;
        }
    }
}

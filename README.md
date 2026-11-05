# DrinksInfo
DrinksInfo is a .NET console application that lets you browse drink categories from TheCocktailDB API and select a drink to view its details.
## Features
- Browse available drink categories
- Select a category and view matching drinks
- Fetch and display detailed drink information
- Interactive terminal UI powered by Spectre.Console
## Prerequisites
- .NET SDK 10.0 or later
- Internet access to reach the public CocktailDB API
## Getting Started
1. Clone the repository.
2. Open a terminal in the project root.
3. Restore dependencies and run the app:
```bash
dotnet restore
dotnet run --project DrinksInfo
```
## Project Structure
```text
DrinksInfo/
├── Data/                 # API response models and drink data classes
├── Views/                # Console prompts and UI flow
├── DrinkService.cs        # API client logic for CocktailDB endpoints
├── Program.cs            # Application entry point
├── DrinksInfo.csproj     # .NET project configuration
└── ...
```
## API Source
This project uses the public CocktailDB API:
- https://www.thecocktaildb.com/api/json/v1/1/
## Notes
- The app is designed as a lightweight interactive lookup tool rather than a full web or mobile application.
- Some API responses may vary depending on the endpoint and data availability from the upstream service.

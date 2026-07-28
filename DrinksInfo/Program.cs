using DrinksInfo.Views;

namespace DrinksInfo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using HttpClient client = new();

            var ui = new UI(client);

            try
            {
            await ui.RunAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

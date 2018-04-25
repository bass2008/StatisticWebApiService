using RestEase;
using ReviewMe.Client.Console.Metadata;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReviewMe.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Run().Wait();
        }

        static async Task Run()
        {
            try
            {
                await MainAsync();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Message: {ex.Message}; StackTrace: {ex.StackTrace}");
            }
            System.Console.ReadKey();
        }
        
        static async Task MainAsync()
        {
            var api = RestClient.For<IReviewMeWeb>("http://localhost:49943");

            await api.DeleteVisitorsCount("player1");

            var list = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(Task.Run(async () =>
                {
                    await api.AddHumanVisitors("player1", i);
                }));
            }
            var res = await api.GetVisitorsCountAsync("player1");
            System.Console.WriteLine(res);
        }
    }
}

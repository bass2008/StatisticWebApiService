using RestEase;
using System.Threading.Tasks;

namespace ReviewMe.Client.Console.Metadata
{
    public interface IReviewMeWeb
    {
        [Get("/visitors/count")]
        Task<int> GetVisitorsCountAsync(string player);

        [Get("/visitors/add")]
        Task AddHumanVisitors(string player, int count);

        [Delete("/visitors/clear")]
        Task DeleteVisitorsCount(string player);
    }
}

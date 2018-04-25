using RestEase;
using System.Threading.Tasks;

namespace ReviewMe.Client.Console.Metadata
{
    public interface IReviewMeWeb
    {
        [Get("/visitors/count")]
        Task<int> GetVisitorsCountAsync(string player);

        [Get("/add")]
        Task AddHumanVisitors(string player, int count);

        [Delete("/visitors/count")]
        Task DeleteVisitorsCount(string player);
    }
}

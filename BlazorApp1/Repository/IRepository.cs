using BlazorApp1.Models;

namespace BlazorApp1.Repository
{
    public interface IRepository
    {
        List<Game> GetAllGames();
    }
}

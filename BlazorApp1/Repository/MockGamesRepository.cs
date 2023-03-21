using BlazorApp1.Models;

namespace BlazorApp1.Repository
{
    public class MockGamesRepository : IRepository
    {
        List<Game> _games;

        public MockGamesRepository()
        {
            _games = new List<Game>()
            {
                new Game()
                {
                    Name = "Farming Simulator",
                    Genre = "Simulator",
                    ReleaseDate = new DateTime(2019,11,19)
                },
                new Game()
                {
                    Name = "The Wither",
                    Genre = "Action/RPG",
                    ReleaseDate = new DateTime(2015,05,18)
                },
                new Game()
                {
                    Name = "Destroy All Humans!",
                    Genre = "Action-Adventure",
                    ReleaseDate = new DateTime(2020,07,28)
                }
            };
        }
        public List<Game> GetAllGames()
        {
            return _games;
        }
    }
}

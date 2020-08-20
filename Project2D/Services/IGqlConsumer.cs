using Project2D.Models;
using System.Threading.Tasks;

namespace Project2D.Services
{
    public interface IGqlConsumer
    {
        public Task<Page> GetSeasonalAnimeList();
        public Task<Media> GetMedia(int id);
    }
}

using Project2D.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2D.Services
{
    public interface IGqlConsumer
    {
        public Task<AnimeIndex> GetSeasonalAnimeList();
        public Task<Media> GetMedia();
    }
}

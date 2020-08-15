using Microsoft.AspNetCore.Mvc.RazorPages;
using Project2D.Models;
using Project2D.Services;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Project2D.Pages
{
    public class SeasonalAnimeModel : PageModel
    {
        private readonly IGqlConsumer _consumer;
        public SeasonalAnimeModel(IGqlConsumer consumer)
        {
            _consumer = consumer;
        }

        public AnimeIndex Anime { get; set; }
        
        public async Task OnGet()
        {
            Anime = await _consumer.GetSeasonalAnimeList();
        }
    }
}
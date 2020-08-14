using Microsoft.AspNetCore.Mvc.RazorPages;
using Project2D.Models;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Project2D.Pages
{
    public class SeasonalAnimeModel : PageModel
    {
        private readonly GqlConsumer _consumer;
        public SeasonalAnimeModel(GqlConsumer consumer)
        {
            _consumer = consumer;
        }

        public AnimeIndex Anime { get; set; }
        
        public async Task OnGet()
        {
            Debug.WriteLine("SeasonalAnime OnGet Reached...");
            Anime = await _consumer.GetSeasonalAnimeList();
        }
    }
}
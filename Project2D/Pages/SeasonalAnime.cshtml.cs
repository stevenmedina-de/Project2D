using Microsoft.AspNetCore.Mvc.RazorPages;
using Project2D.Models;
using System.Threading.Tasks;
using Project2D.Services;
using Page = Project2D.Models.Page;

namespace Project2D.Pages
{
    public class SeasonalAnimeModel : PageModel
    {
        private readonly IGqlConsumer _consumer;
        public SeasonalAnimeModel(IGqlConsumer consumer)
        {
            _consumer = consumer;
        }
        public Page MediaPage { get; set; }

        public async Task OnGet()
        {
            MediaPage = await _consumer.GetSeasonalAnimeList();
        }
    }
}
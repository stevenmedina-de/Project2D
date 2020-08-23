using Microsoft.AspNetCore.Mvc.RazorPages;
using Project2D.Models;
using Project2D.Services;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project2D.Pages
{
    public class AnimeModel : PageModel
    {
        private readonly IGqlConsumer _consumer;
        public AnimeModel(IGqlConsumer consumer)
        {
            _consumer = consumer;
        }
         public Media Anime { get; set; }
        
        public async Task OnGet(int id)
        {
            Anime = await _consumer.GetMedia(id);
        }
    }
}
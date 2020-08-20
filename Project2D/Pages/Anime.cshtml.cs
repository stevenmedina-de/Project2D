using Microsoft.AspNetCore.Mvc.RazorPages;
using Project2D.Models;
using Project2D.Services;

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
        
        public void OnGet(int id)
        {

        }
    }
}
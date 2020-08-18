using Microsoft.AspNetCore.Mvc.RazorPages;
using Project2D.Models;
using System.Threading.Tasks;

using System.Diagnostics;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL;
using Project2D.ResponseTypes;

namespace Project2D.Pages
{
    public class SeasonalAnimeModel : PageModel
    {        
        public Media Anime { get; set; }

        public async Task OnGet()
        {
            using var graphQLClient = new GraphQLHttpClient("https://graphql.anilist.co", new NewtonsoftJsonSerializer());

            var request = new GraphQLRequest
            {
                Query = @"
                    query {
                        Media (seasonYear:2020, season:SUMMER, format:TV) {
                            id
                            title {
                                romaji
                                english
                                native
                                userPreferred
                            }
                            coverImage {
                                color
                                medium
                            }
                        }
                    }"
            };

            var res = await graphQLClient.SendQueryAsync<MediaResponseType>(request);
            Anime = res.Data.Media;

        }
    }
}
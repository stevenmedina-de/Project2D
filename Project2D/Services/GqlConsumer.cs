using GraphQL;
using GraphQL.Client.Abstractions;
using Project2D.Models;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Text.Json;

namespace Project2D.Services
{
    public class GqlConsumer : IGqlConsumer
    {
        private readonly IGraphQLClient _client;
        public GqlConsumer(IGraphQLClient client)
        {
            _client = client;
        }

        public async Task<AnimeIndex> GetSeasonalAnimeList()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                    query {
                        TVAnime: Page(page: 1, perPage: 50) {
                            pageInfo {
                                total
                                perPage
                                currentPage
                                lastPage
                                hasNextPage
                            }

                            media(seasonYear:2020, season:SUMMER, format:TV) {
                                title {
                                    userPreferred
                                }
                                coverImage {
                                    large
                                }
                            }
                        }
                    }"
            };

            var response = await _client.SendQueryAsync<AnimeIndex>(query);
            Debug.WriteLine(JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true }));
            return response.Data;
        }

        public async Task<Media> GetMedia()
        {
            var query = new GraphQLRequest
            {
                Query = @"query {
                    Media (seasonYear:2020, season:SUMMER) {
                        id
                    }
                }"
            };

            var response = await _client.SendQueryAsync<Media>(query);
            Debug.WriteLine(JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true }));
            return response.Data;
        }
    }
}

using GraphQL.Client.Abstractions;
using Project2D.Models;
using System.Threading.Tasks;
using Project2D.ResponseTypes;
using GraphQL;

namespace Project2D.Services
{
    public class GqlConsumer : IGqlConsumer
    {
        private readonly IGraphQLClient _client;
        public GqlConsumer(IGraphQLClient client)
        {
            _client = client;
        }

        public async Task<Page> GetSeasonalAnimeList()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                    query 
                    {
                        Page(page:1, perPage:50)
                        {
                            pageInfo
                            {
                                total,
                                perPage,
                                currentPage,
                                lastPage,
                                hasNextPage
                            }
                            media(season:SUMMER, seasonYear:2020, format:TV)
                            {
                                id,
                                title
                                {
                                    userPreferred
                                }
                                coverImage
                                {
                                    large
                                }
                            }
                        }   
                    }
                "
            };

            var response = await _client.SendQueryAsync<PageInfoAndMediaResponseType>(query);
            return response.Data.Page;
        }

        public async Task<Media> GetMedia(int id)
        {
            var query = new GraphQLRequest
            {
                Query = @"query {
                    Media (seasonYear:2020, season:SUMMER, format:TV, id:108632) {
                        title {
                            userPreferred
                        }
                        coverImage {
                            color
                            medium
                            large
                            extraLarge
                        }
                    }
                }"
            };

            var response = await _client.SendQueryAsync<MediaResponseType>(query);
            return response.Data.Media;
        }
    }
}

using GraphQL.Client.Abstractions;
using Project2D.Models;
using System.Threading.Tasks;
using Project2D.ResponseTypes;
using GraphQL;

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
                Query = @"
                    query MediaInfo($mediaId: Int)
                    {
                        Media (id: $mediaId) 
                        {
                            id
                            title 
                            {
                                romaji
                                english
                                native
                                userPreferred
                            }
                            type
                            format
                            status
                            description(asHtml: false)
                            startDate 
                            {
                                year
                                month
                                day
                            }
                            endDate 
                            {
                                year
                                month
                                day
                            }
                            season
                            seasonYear
                            episodes      
                            duration
                            source(version:2)
                            trailer 
                            {
                                id
                                site
                                thumbnail
                            }
                            coverImage 
                            {
                                color
                                extraLarge
                                large
                                medium
                            }
                            bannerImage
                            genres
                            averageScore
                            meanScore
                            tags 
                            {
                                id
                                name
                                description
                                category
                                rank
                                isGeneralSpoiler
                                isMediaSpoiler
                                isAdult
                            }
                            isAdult
                            nextAiringEpisode 
                            {
                                id
                                airingAt
                                timeUntilAiring
                                episode
                            }
                            externalLinks 
                            {
                                id
                                url
                                site
                            }
                            streamingEpisodes 
                            {
                                title
                                thumbnail
                                url
                                site
                            }
                            siteUrl
                        }
                    }
                ",
                Variables = new
                {
                    mediaId = id
                }
            };

            var response = await _client.SendQueryAsync<MediaResponseType>(query);
            Debug.WriteLine(JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true }));
            return response.Data.Media;
        }
    }
}

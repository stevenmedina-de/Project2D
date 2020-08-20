using System.Collections.Generic;

namespace Project2D.Models
{
    public enum MediaType
    {
        ANIME,
        MANGA
    }
    public enum MediaFormat
    {
        TV,
        TV_SHORT,
        MOVIE,
        SPECIAL,
        OVA,
        ONA,
        MUSIC,
        MANGA,
        NOVEL,
        ONE_SHOT
    }
    public enum MediaStatus
    {
        FINISHED,
        RELEASING,
        NOT_YET_RELEASED,
        CANCELLED
    }
    public enum MediaSeason
    {
        WINTER,
        SPRING,
        SUMMER,
        FALL
    }
    public enum MediaSource
    {
        ORIGINAL,
        MANGA,
        LIGHT_NOVEL,
        VISUAL_NOVEL,
        VIDEO_GAME,
        OTHER,
        NOVEL,
        DOUJINSHI,
        ANIME
    }

    public class Media
    {
        public int ID { get; set; }
        public Title Title { get; set; }
        public MediaType Type { get; set; }
        public MediaFormat Format { get; set; }
        public MediaStatus Status { get; set;}
        public string Description { get; set; }
        public FuzzyDate StartDate { get; set; }
        public FuzzyDate EndDate { get; set; }
        public MediaSeason Season { get; set; }
        public int SeasonYear { get; set; }
        public int? Episodes { get; set; }
        public int Duration { get; set; }
        public MediaSource Source { get; set; }
        public MediaTrailer Trailer { get; set; }
        public MediaCoverImage CoverImage { get; set; }
        public string BannerImage { get; set; }
        public List<string> Genres { get; set; }
        public int AverageScore { get; set; }
        public int MediaScore { get; set; }
        public List<MediaTag> Tags { get; set; }
        public bool IsAdult { get; set; }
        public AiringSchedule NextAiringEpisode { get; set; }
        public List<MediaExternalLink> ExternalLinks { get; set; }
        public List<MediaStreamingEpisode> StreamingEpisodes { get; set; }
        public string SiteUrl { get; set; }
    }
}
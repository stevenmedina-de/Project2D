using System.Collections.Generic;

namespace Project2D.Models
{
    public class IndexResponse
    {
        public PageContent Page { get; set; }

        public class PageContent
        {
            public PageInfoContent PageInfo { get; set; }
            public List<MediaContent> Media { get; set; }

            public class PageInfoContent
            {
                public int Total { get; set; }
                public int PerPage { get; set; }
                public int CurrentPage { get; set; }
                public int LastPage { get; set; }
                public bool HasNextPage { get; set; }
            }
            public class MediaContent
            {
                public TitleContent Title { get; set; }
                public CoverImageContent CoverImage { get; set; }

                public class TitleContent
                {
                    public string UserPreferred { get; set; }
                }
                public class CoverImageContent
                {
                    public string Large { get; set; }
                }
            }
        }
    }
}

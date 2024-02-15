using HackerBestStories.Helper;

namespace HackerBestStories.Models
{
    public class StoryDetailsResponse
    {
        public string title { get; set; }
        public string uri { get; set; }
        public string postedBy { get; set; }
        public string time { get; set; }
        public int score { get; set; }
        public string commentCount { get; set; }
    }
}

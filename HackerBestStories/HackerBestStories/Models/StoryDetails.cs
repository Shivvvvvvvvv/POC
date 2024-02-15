using HackerBestStories.Helper;
using Newtonsoft.Json;
using System.Globalization;

namespace HackerBestStories.Models
{
    public class StoryDetails
    {
        public string title { get; set; }
        public string url { get; set; }
        public string by { get; set; }
        public string time { get; set; }
        [JsonConverter(typeof(StringToIntConverter))]
        public int score { get; set; }
    }
}

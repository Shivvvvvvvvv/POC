using HackerBestStories.Interfaces;
using HackerBestStories.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Polly;

namespace HackerBestStories.Services
{
    public class HackerNewsService : IHackerNewsService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private readonly IAsyncPolicy<HttpResponseMessage> _rateLimitingPolicy;

        public HackerNewsService(HttpClient httpClient, IMemoryCache memoryCache)
        {
            _httpClient = httpClient;
            _memoryCache = memoryCache;

            // Rate limiting policy - 10 requests per second
            _rateLimitingPolicy = Policy.RateLimitAsync(10, TimeSpan.FromSeconds(1)).AsAsyncPolicy<HttpResponseMessage>();

        }

        public async Task<List<int>> GetAsyncBestStoryIds()
        {
            
            if (!_memoryCache.TryGetValue("BestStoryIds", out List<int> bestStoryIds))
            {
                var response = await _httpClient.GetStringAsync("https://hacker-news.firebaseio.com/v0/beststories.json");
                bestStoryIds = JsonConvert.DeserializeObject<List<int>>(response);

                // Cache the result for 5 minutes
                _memoryCache.Set("BestStoryIds", bestStoryIds, TimeSpan.FromMinutes(5));
            }

            return bestStoryIds;
        }

        public async Task<StoryDetails> GetAsyncStoryDetails(int storyId)
        {

            if (!_memoryCache.TryGetValue($"StoryDetails_{storyId}", out StoryDetails storyDetails))
            {
                var response = await _httpClient.GetStringAsync($"https://hacker-news.firebaseio.com/v0/item/{storyId}.json");
                storyDetails = JsonConvert.DeserializeObject<StoryDetails>(response);

                // Cache the result for 5 minutes
                _memoryCache.Set($"StoryDetails_{storyId}", storyDetails, TimeSpan.FromMinutes(5));
            }

            return storyDetails;
        }
    }
}

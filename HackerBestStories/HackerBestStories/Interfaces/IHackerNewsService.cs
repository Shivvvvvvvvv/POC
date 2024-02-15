using HackerBestStories.Models;

namespace HackerBestStories.Interfaces
{
    public interface IHackerNewsService
    {
        Task<List<int>> GetAsyncBestStoryIds();
        Task<StoryDetails> GetAsyncStoryDetails(int storyId);
    }
}

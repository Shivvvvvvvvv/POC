using HackerBestStories.Interfaces;
using HackerBestStories.Models;
using Microsoft.AspNetCore.Mvc;

namespace HackerBestStories.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HackerNewsController : ControllerBase
    {
        private readonly IHackerNewsService _hackerNewsService;

        public HackerNewsController(IHackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;
        }

        [HttpGet("best-stories/{storiescount}")]
        public async Task<IActionResult> GetBestStories(int storiescount)
        {
            if (storiescount <= 0)
            {
                return BadRequest("Invalid value for 'storiescount'.");
            }

            var bestStoryIds = await _hackerNewsService.GetAsyncBestStoryIds();

            var topNStories = new List<StoryDetails>();
            foreach (var storyId in bestStoryIds)
            {
                var storyDetails = await _hackerNewsService.GetAsyncStoryDetails(storyId);
                topNStories.Add(storyDetails);
            }

            var topScoreStory = topNStories.OrderByDescending(x => x.score).Take(storiescount).Select(x=> new StoryDetailsResponse() { 
            title = x.title,
            uri = x.url,
            postedBy = x.by,
            time = x.time,
            score = x.score,
            commentCount = string.Empty
            });

            return Ok(topScoreStory);
        }
    }
}

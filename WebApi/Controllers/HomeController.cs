using Microsoft.AspNetCore.Mvc;
using PostsNamespace;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("{index}")]
        public async Task< IActionResult> Get(int index)
        {
            GetterData getter = new GetterData();
            VKUsersPosts posts = await getter.GetLast5Posts("738489146");

            Dictionary<char, int>[] dicts = await OccurrenceСounter.CollectOccurrences(posts);

            return Ok(dicts[index]);
        }
    }
}

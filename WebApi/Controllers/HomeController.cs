using Microsoft.AspNetCore.Mvc;
using PostsNamespace;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("{index}")]
        public async Task< IActionResult> Get(int index)
        {
            GetterData getter = new GetterData();
            VKUsersPosts posts = await getter.GetLast5Posts("738489146");

            OccurrencesData dicts = await OccurrenceСounter.CollectOccurrences(posts);

            try
            {
                return Ok(dicts.Data[index]);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}

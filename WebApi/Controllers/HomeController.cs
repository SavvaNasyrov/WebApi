using Microsoft.AspNetCore.Mvc;
using PostsNamespace;
using System.Text.Json;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        /*
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
        */

        [HttpGet("{ind}")]
        public async Task< IActionResult> JsonString(int ind) 
        {
            GetterData getter = new GetterData();
            VKUsersPosts posts = await getter.GetLast5Posts("738489146");

            OccurrenceСounter сounter = new (new())

            OccurrencesData dicts = await OccurrenceСounter.CollectOccurrences(posts);

            try
            {
                return Ok( JsonSerializer.Deserialize(dicts.JsonString, typeof(Dictionary<char, int>[])));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}

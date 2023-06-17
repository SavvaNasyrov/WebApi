using Microsoft.AspNetCore.Mvc;
using PostsNamespace;
using System.Text.Json;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        private WebApiContext webApiContext;
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

        public HomeController(WebApiContext webApiContext)
        {
            this.webApiContext = webApiContext;
        }


        [HttpGet("{owner_id}")]
        public async Task< IActionResult> JsonString(string owner_id) 
        {

            try
            {
                GetterData getter = new GetterData();
                VKUsersPosts posts = await getter.GetLast5Posts(owner_id);

                OccurrenceСounter сounter = new(new(webApiContext));

                OccurrencesData dicts = await сounter.CollectOccurrences(posts);
            }
            catch 
            {
                return BadRequest();
            }

            return Ok("ok");
        }
    }
}

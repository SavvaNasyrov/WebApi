using Microsoft.EntityFrameworkCore;
using PostsNamespace;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class OccurrenceСounter
    {
        public string LogPath { get; set; } = "ResCounterLog.txt";

        private readonly WriteToDBService writeToDB;

        public OccurrenceСounter(WriteToDBService writeToDB)
        {
            this.writeToDB = writeToDB;
        }

        private async Task<Task> WriteStartLog()
        {
            await File.AppendAllTextAsync(LogPath, $"Started occurrence counting: {DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff")} \n");
            return Task.FromResult(0);
        }

        private async Task<Task> WriteEndLog()
        {
            await File.AppendAllTextAsync(LogPath, $"Ended occurrence counting: {DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff")} \n");
            return Task.FromResult(0);
        }

        public async Task<OccurrencesData> CollectOccurrences(VKUsersPosts posts)
        {
            await WriteStartLog();

            OccurrencesData result = new(posts.response.items[0].owner_id.ToString());

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 32; i++)
                {
                    if (i == 6) result.Data[j].Add('ё', 0);
                    result.Data[j].Add((char)(1072 + i), 0);
                }
            }

            for (int j = 0; j < 5; j++)
            {
                string text = posts.response.items[j].text;
                RemoveSalt( ref text ); 

                FindOccurrences(ref result.Data[j], text );
            }


            await WriteEndLog();

            result.UpdateJsonString();

            writeToDB.WriteOccurrencesData(result);

            return result;
        }

        private void FindOccurrences(ref Dictionary<char, int> dict, string text)
        {
            foreach (var ch in text)
            {
                foreach (var key in dict.Keys)
                {
                    if (ch == key) dict[key]++;
                }
            }
        }

        private void RemoveSalt(ref string text)
        {
            string result = new string(text.Where(t => char.IsLetter(t)).ToArray());
            result.ToLower();
            text = result;
        }
    }
}

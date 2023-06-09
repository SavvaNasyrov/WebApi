﻿using PostsNamespace;

namespace WebApi.Controllers
{
    public static class OccurrenceСounter
    {
        public static string LogPath { get; set; } = "ResCounterLog.txt";

        private static async Task<Task> WriteStartLog()
        {
            await File.AppendAllTextAsync(LogPath, $"Started occurrence counting: {DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff")} \n");
            return Task.FromResult(0);
        }

        private static async Task<Task> WriteEndLog()
        {
            await File.AppendAllTextAsync(LogPath, $"Ended occurrence counting: {DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff")} \n");
            return Task.FromResult(0);
        }

        public static async Task<Dictionary<char, int>[]> CollectOccurrences(VKUsersPosts posts)
        {
            await WriteStartLog();

            Dictionary<char, int>[] result = {
                new Dictionary<char, int>(33),
                new Dictionary<char, int>(33),
                new Dictionary<char, int>(33),
                new Dictionary<char, int>(33),
                new Dictionary<char, int>(33)
            };

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 32; i++)
                {
                    result[j].Add((char)(1072 + i), 0);
                }
                result[j].Add('ё', 0);
            }

            for (int j = 0; j < 5; j++)
            {
                string text = posts.response.items[j].text;
                RemoveSalt( ref text ); 

                FindOccurrences(ref result[j], text );
            }

            await WriteEndLog();

            return result;
        }

        private static void FindOccurrences(ref Dictionary<char, int> dict, string text)
        {
            foreach (var ch in text)
            {
                foreach (var key in dict.Keys)
                {
                    if (ch == key) dict[key]++;
                }
            }
        }

        private static void RemoveSalt(ref string text)
        {
            string result = new string(text.Where(t => char.IsLetter(t)).ToArray());
            result.ToLower();
            text = result;
        }
    }
}

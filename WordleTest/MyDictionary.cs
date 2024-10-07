using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace WordleTest
{
    internal class MyDictionary
    {

        private static readonly HttpClient client = new HttpClient();
        private List<string> validWords = new List<string>();

        public async Task InitializeAsync()
        {
            try
            {
                string url = "https://random-word-api.herokuapp.com/all";
                var response = await client.GetFromJsonAsync<List<string>>(url);

                if (response != null && response.Count > 0)
                {
                    validWords = response;
                }
                else
                {
                    Console.WriteLine("No words found in the dictionary.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while initializing the dictionary: {ex.Message}");
            }
        }

        public async Task<string> GetRandomWordAsync(int length)
        {
            try
            {
                string url = "https://random-word-form.herokuapp.com/word?number=1&length=" + length;
                var response = await client.GetFromJsonAsync<List<string>>(url);

                if (response != null && response.Count > 0)
                {
                    return response[0];
                }
                else
                {
                    return "No word found";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return "Error";
            }
        }
        public bool IsValidWord(string word)
        {
            return validWords.Contains(word.ToLower());
        }

    }
}

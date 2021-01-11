using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WordStack.Web.Models;

namespace WordStack.Web
{
    public interface IWordStackClient
    {
        public Task<IEnumerable<WordType>> WordTypes();
        public Task<IEnumerable<Word>> Words(int wordTypeId);
        public Task<IEnumerable<Sentence>> Sentences();
        public Task AddNewSentence(Sentence sentence);
    }

    public class WordStackClient : IWordStackClient
    {
        private readonly HttpClient Client;
        public WordStackClient(HttpClient client)
        {
            Client = client;
        }

        public async Task AddNewSentence(Sentence sentence)
        {
            var sentenceJson = new StringContent(JsonSerializer.Serialize(sentence), Encoding.UTF8, "application/json");

            using var httpResponse = await Client.PostAsync("/sentence", sentenceJson);

            httpResponse.EnsureSuccessStatusCode();
        }
        

        public async Task<IEnumerable<Sentence>> Sentences()
        {
            var response = await Client.GetAsync("/sentence");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<Sentence>>(responseStream);
        }

        public async Task<IEnumerable<Word>> Words(int wordTypeId)
        {
            var response = await Client.GetAsync($"/word/{wordTypeId}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<Word>>(responseStream);
        }

        public async Task<IEnumerable<WordType>> WordTypes()
        {
            var response = await Client.GetAsync("/wordtype");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<WordType>>(responseStream);
        }
    }
}

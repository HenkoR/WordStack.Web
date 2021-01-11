using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordStack.Web.Models;

namespace WordStack.Web
{
    public interface IWordStackClient
    {
        public Task<IEnumerable<WordType>> WordTypes();
        public Task<IEnumerable<Word>> Words();
        public Task<IEnumerable<Sentence>> Sentences();
        public Task AddNewSentence(Sentence sentence);
    }

    public class WordStackClient : IWordStackClient
    {
        public WordStackClient()
        {

        }

        public async Task AddNewSentence(Sentence sentence)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Sentence>> Sentences()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Word>> Words()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WordType>> WordTypes()
        {
            throw new NotImplementedException();
        }
    }
}

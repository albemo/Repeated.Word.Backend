using RepeatedWord.Backend.Domain.Models;
using RepeatedWord.Backend.Domain.ViewModels;
using RepeatedWord.Backend.Infrastructure.Repository;
using RepeatedWord.Backend.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepeatedWord.Backend.WebApi.Services
{
    public class SentenceService : BaseRepository<Sentence>, ISentenceService
    {
        private readonly IRepository<Sentence> _repository;
        private readonly IWordService _wordService;

        public SentenceService(IRepository<Sentence> repository,
            IWordService wordService) :base(repository)
        {
            _repository = repository;
            _wordService = wordService;
        }

        public async Task<List<WordViewModel>> GetRepeatedWordsInASentence(string text)
        {
            //Convert the string into an array of words  
            string[] items = text.Split(new char[] { ' ', '.', ',', '?', '!', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

            var model = items
                .GroupBy(word => word) // Group by word 
                .Select(x => new WordViewModel // Projection to return
                {
                    Text = x.Key,
                    Count = x.Count()
                })
                .OrderByDescending(x => x.Count) // sort by count of repeated words descending
                .ToList();

            var item = await AddAsync(new Sentence { Text = text });

            foreach (var word in model)
            {
                var w = new Word
                {
                    Text = word.Text,
                    Count = word.Count,
                    SentenceId = item.Id
                };

                await _wordService.AddAsync(w);
            }

            return model;   
        }
    }
}

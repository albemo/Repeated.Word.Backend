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
    public class WordService : BaseRepository<Word>, IWordService
    {
        public WordService(IRepository<Word> repository) :base(repository)
        {
        }
    }
}

using RepeatedWord.Backend.Domain.Models;
using RepeatedWord.Backend.Domain.ViewModels;
using RepeatedWord.Backend.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepeatedWord.Backend.WebApi.Interfaces
{
    public interface IWordService : IRepository<Word>
    {
    }
}

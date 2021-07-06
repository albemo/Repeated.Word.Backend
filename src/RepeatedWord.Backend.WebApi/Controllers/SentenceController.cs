using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepeatedWord.Backend.Domain.ViewModels;
using RepeatedWord.Backend.WebApi.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace RepeatedWord.Backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class SentenceController : ControllerBase
    {
        private readonly ISentenceService _sentenceService;

        public SentenceController(ISentenceService wordService)
        {
            _sentenceService = wordService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = await _sentenceService.QueryNoTracking()
                .Include(x => x.Words)
                .ToListAsync();

            var items = query.Select(x => new SentenceViewModel
            {
                Id = x.Id,
                Text = x.Text,
                Words = x.Words.Select(y => new WordViewModel
                {
                    Id = y.Id,
                    Text = y.Text,
                    Count = y.Count,
                    SentenceId = y.SentenceId
                }).ToList()
            }).ToList();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = await _sentenceService.QueryNoTracking()
                .Include(x => x.Words)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (query == null)
                return NotFound($"Item not found with id {id}");

            var model = new SentenceViewModel
            {
                Id = query.Id,
                Text = query.Text,
                Words = query.Words.Select(x => new WordViewModel
                {
                    Id = x.Id,
                    Text = x.Text,
                    Count = x.Count
                }).ToList()
            };

            return Ok(model);
        }

        [HttpGet("repeat")]
        public async Task<IActionResult> RepeatedWordInASentence(string text)
        {
            var model = await _sentenceService.GetRepeatedWordsInASentence(text);

            return Ok(model);
        }
    }
}

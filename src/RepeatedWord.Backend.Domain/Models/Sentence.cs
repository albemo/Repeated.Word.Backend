using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatedWord.Backend.Domain.Models
{
    public class Sentence
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public IList<Word> Words { get; set; } = new List<Word>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatedWord.Backend.Domain.ViewModels
{
    public class WordViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int Count { get; set; }

        public int SentenceId { get; set; }

        public WordViewModel Sentence { get; set; }
    }
}

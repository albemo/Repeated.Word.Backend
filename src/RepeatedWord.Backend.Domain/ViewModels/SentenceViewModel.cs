using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatedWord.Backend.Domain.ViewModels
{
    public class SentenceViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public IList<WordViewModel> Words { get; set; } = new List<WordViewModel>();
    }
}

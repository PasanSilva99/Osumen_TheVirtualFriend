using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osumen_ChatKnoladgeBase
{
    public class Word
    {
        public string PosTag { get; set; }
        public string Original { get; set; }
        public string Lemma { get; set; }
        public string Ner { get; set; }
    }
}

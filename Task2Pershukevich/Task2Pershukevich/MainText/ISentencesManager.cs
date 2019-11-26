using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Pershukevich.MainText.TextElements;

namespace Task2Pershukevich.MainText
{
    public interface ISentencesManager
    {
        void AddSentenceToText(Sentence sentence);
        void RemoveSentenceFromText(Sentence sentence);
        void ClearAllSentences();
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Pershukevich.MainText.TextElements.SentenceElements;

namespace Task2Pershukevich.MainText.TextElements
{
    public enum SentenceType
    {
        Declarative, //.
        Interrogative, //?
        Exclamatory, //!
    }

    public class Sentence : ICollection<Word>
    {
        public int Count => words.Count;
        public bool IsReadOnly => false;

        private IList<Word> words;
        private IList<PunctuationMark> punctuationMarks;
        public SentenceType SentenceType { get; set; }

        public Sentence(IList<Word> wordsList)
        {
           words = wordsList;
        }

        public Sentence()
        {
            words = new List<Word>();
            punctuationMarks = new List<PunctuationMark>();
        }

        public ICollection<Word> GetAllWords()
        {
            return words;
        }

        public ICollection<PunctuationMark> GetPunctuationMarks()
        {
            return punctuationMarks;
        }

        public void AddPunctuation(char punctMark, int position) 
        {
            PunctuationMark punctuationMark = new PunctuationMark(punctMark, position);
            punctuationMarks.Add(punctuationMark);
        }

        public static SentenceType SetType(char lastSymbol)
        {
            SentenceType sentType = SentenceType.Declarative;

            switch (lastSymbol)
            {
                case '.':
                    sentType = SentenceType.Declarative;
                    break;
                case '?':
                    sentType = SentenceType.Interrogative;
                    break;
                case '!':
                    sentType = SentenceType.Exclamatory;
                    break;
                default:
                    sentType = SentenceType.Declarative;
                    break;
            }

            return sentType;
        }

        public IEnumerable<Word> GetWordsFromInterrogativeSentences(int lenght)
        {
            return words.Where(w => w.GetWordsLenght() == lenght).Distinct();
        }

        //public IEnumerable<Word> GetWordsStartingFromConsonant(int lenght, string vowelsAppConfig)
        //{
        //    return words.Where(x => x.GetWordsLenght() == lenght)
        //        .Where(w => !vowelsAppConfig.Contains(char.ToLower(w.GetFirstSymbol())));
        //}

        public void ReplaceWordsWithSubstring(int lenght, string subString)
        {
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].GetWordsLenght() == lenght)
                {
                    words[i] = Word.CreateWordFromString(subString);

                    ReplacingStringPositionChange(lenght, subString.Length);
                }
            }
        }
        
        public void DeleteConsonantWords(int lenght, string vowelsAppConfig)
        {
            for (int i = 0; i < words.Count(); i++)
            {
                if (!vowelsAppConfig.Contains(char.ToLower(words[i].GetFirstSymbol())) && words[i].GetWordsLenght() == lenght)
                {
                    words[i] = Word.CreateWordFromString(string.Empty);
                    ReplacingStringPositionChange(lenght, 0);
                }
            }
        }

        private void ReplacingStringPositionChange(int lenght, int subStringLength)
        {
            foreach (PunctuationMark punctMark in punctuationMarks)
            {
                punctMark.ChangePositionForReplacing(lenght, subStringLength);
            }
        }

        public void Add(Word word)
        {
            words.Add(word);
        }

        public void Clear()
        {
            words.Clear();
        }

        public bool Contains(Word item)
        {
            bool isContaining = false;

            if (words.Contains(item))
            {
                isContaining = true;
            }

            return isContaining;
        }

        public void CopyTo(Word[] array, int arrayIndex)
        {
            words.CopyTo(array, arrayIndex);
        }

        public bool Remove(Word item)
        {
            bool isRemoved = false;

            if (words.Remove(item))
            {
                isRemoved = true;
            }

            return isRemoved;
        }

        public IEnumerator<Word> GetEnumerator()
        {
            return GetAllWords().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder outputString = new StringBuilder();

            foreach (Word word in words)
            {
                outputString.Append(word.ToString() + " ");
            }

            try
            {
                foreach (PunctuationMark punctMark in punctuationMarks)
                {
                    outputString = outputString.Insert(punctMark.GetPositionInSentence(), Convert.ToString(punctMark.GetFirstSymbol()));
                }
            }
            catch(ArgumentOutOfRangeException ex) { throw ex; }

            return outputString.ToString();
        }
    }
}

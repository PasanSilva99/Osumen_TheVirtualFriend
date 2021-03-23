using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleNetNlp;

namespace Osumen_ChatKnoladgeBase
{
    public class NLPProcessor
    {
        public String InputMessage { get; set; }

        /// <summary>
        /// Filter the sentences from the Input Message
        /// </summary>
        /// <param name="InputMessage">User Input Message</param>
        /// <returns>Array of Seperated Sentences</returns>
        public Sentence[] FilterSentences(String InputMessage)
        {
            List<Sentence> Sentences = new List<Sentence>();

            try
            {
                if(InputMessage != null)
                {
                    char[] Seperators = { '.', '?'};  // Possible charactors

                    String[] SplittedMessage = InputMessage.Split(Seperators); // Split the message according to the mentioned Charactors

                    // Add all messages as sentences
                    foreach(var message in SplittedMessage)
                    {
                        Sentences.Add(new Sentence(message));
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return Sentences.ToArray();
        }
        public Word[] ProcessSentence(Sentence Sentence)
        {
            var Words = new List<Word>();

            // Check Wether the Sentence is Not Null
            if (!Sentence.Equals(null))
            {
                // Lemmatization
                var lemmas = Sentence.Lemmas;

                // Re build the sentece using Lemmatized Words
                var LemmatizedSentBuilder = new StringBuilder();

                foreach (String word in lemmas)
                {
                    LemmatizedSentBuilder.Append(word + " ");
                }

                var LemmatizedSentence = new Sentence(LemmatizedSentBuilder.ToString());

                // POS Tagging
                var posTags = LemmatizedSentence.PosTags;

                // Analyze the Sentiment
                 var sentiment = Sentence.Sentiment;

                // NER Tagging
                var nerTags = LemmatizedSentence.NerTags;

                // Appened the processed Sentence in to word List

                for (int i = 0; i < lemmas.Count; i++)
                {
                    Words.Add(new Word
                    {
                        Lemma = lemmas.ToArray()[i],
                        Original = Sentence.Words.ToArray()[i],
                        PosTag = posTags.ToArray()[i],
                        Ner = nerTags.ToArray()[i],
                    });
                }

            }

            return Words.ToArray();
        }
     
    }
}

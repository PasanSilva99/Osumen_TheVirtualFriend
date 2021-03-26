using Osumen_ChatKnoladgeBase.Trainer;
using Osumen_TheVirtualFriendML.Model;
using SimpleNetNlp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Osumen_ChatKnoladgeBase.Trainer.ModelHandler;

namespace Osumen_ChatKnoladgeBase.Chat
{
    public class ChatAI
    {
        ModelHandler Handler = new ModelHandler();
        private static Intent[] RegisteredIntents;

        public void RefreshIntents()
        {
            RegisteredIntents = Handler.ReadTrainData();
        }

        /// <summary>
        /// Get the reply directly
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ModelOutput GetReply(String input)
        {
            try
            {
                if (RegisteredIntents.Equals(null))
                {
                    RefreshIntents();
                }
                else
                {
                    var inputStr = new ModelInput()
                    {
                        Col1 = input,
                    };

                    ModelOutput modelOutput = ConsumeModel.Predict(inputStr);

                    String PredectedTag = modelOutput.Prediction;
                    var Score = modelOutput.Score;

                    return modelOutput;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        NLPProcessor Processor = new NLPProcessor();

        /// <summary>
        /// Get the sentences of an input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Sentence[] GetSentences(String input)
        {
            return Processor.FilterSentences(input);
        }

        /// <summary>
        /// Get all processed words from a Sentence
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Word[] GetWords(String input)
        {
            var sentences = Processor.FilterSentences(input);

            var wordList = new List<Word>();

            foreach(var sentence in sentences)
            {
                var fetchedWords = Processor.ProcessSentence(sentence);
                foreach(var word in fetchedWords)
                {
                    wordList.Add(word);
                }
            }

            return wordList.Equals(null) ? null : wordList.ToArray();
        }

        /// <summary>
        /// Fill the placeholders of any string
        /// </summary>
        /// <param name="input">The sentence</param>
        /// <param name="PlaceHolderStartString">How the placeholder starts</param>
        /// <param name="PlaceholderEndString">How the place holder end</param>
        public void FillPlaceholders(String input)
        {
            var placeholders = new List<PlaceHolderVar>();

            if (input.Contains("*~~*#"))
            {
                // Has placeholders
                Console.WriteLine("Fetching Placeholders");
                String[] seperators = { "*~", "~*" };
                String[] words = input.Split(seperators, StringSplitOptions.None);

                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].StartsWith("#") && words[i].EndsWith("#"))
                    {
                        //words[i] = value; 
                    }
                }

                foreach (var s in words)
                {
                    Console.Write(s);
                }

                Console.WriteLine();
            }
        }

    }



    public class PlaceHolderVar
    {
        public String Placeholder { get; set; }

        public String ReplyString { get; set; }

    }
}

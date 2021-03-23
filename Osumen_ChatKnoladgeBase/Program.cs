using SimpleNetNlp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Osumen_ChatKnoladgeBase.NLPProcessor;
using static Osumen_ChatKnoladgeBase.Classifier;
using Osumen_ChatKnoladgeBase.Trainer;

namespace Osumen_ChatKnoladgeBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============================================");
            Console.WriteLine("        Osumen Chat Knoladge Base");
            Console.WriteLine("            Console Visualizer");
            Console.WriteLine("============================================");
            Console.WriteLine();

            while (true)
            {

                Console.Write("Console Input : User Message Input > ");
                String inputString = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("*********************************************");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Starting NLP Process");

                NLPProcessor processor = new NLPProcessor();

                Sentence[] sentences = processor.FilterSentences(inputString);

                Word[] ProcessedWords;


                foreach (Sentence sentence in sentences)
                {
                    ProcessedWords = processor.ProcessSentence(sentence);
                    Console.WriteLine();
                    Console.WriteLine();
                    foreach (Word word in ProcessedWords)
                    {
                        Console.Write($"({word.Original}, \'{word.Lemma}\', \'{word.PosTag}\', \"{word.Ner}\") ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("#############################################");
                Console.WriteLine("NLP Process Complete");

                Console.WriteLine("*********************************************");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("All Tasks Complete");

                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;

                ModelHandler hn = new ModelHandler();

                hn.readTrainData();

                var trainingData = hn.fitDataAsTagPattern();

                hn.SelializeTrainingTAG(trainingData);


                Console.Write("Re run? (y/n) > ");

                if (Console.ReadLine() != "y")
                {
                    break;
                }

            }

            Console.WriteLine("============================================");
            Console.WriteLine("        Osumen Chat Knoladge Base");
            Console.WriteLine("            Console Visualizer");
            Console.WriteLine("============================================");
            Console.WriteLine();


            Console.ReadKey();
        }
    }
}

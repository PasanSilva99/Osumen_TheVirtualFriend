using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;
using Newtonsoft.Json;

namespace Osumen_ChatKnoladgeBase.Trainer
{
    public class ModelHandler
    {
        public class Intent
        {
            public String Tag { get; set; }
            public String[] Patterns { get; set; }
            public String[] Responses { get; set; }
        }

        Intent[] trainintents = null;

        public class IntentTrainingDataTAG
        {
            [LoadColumn(0)]
            [ColumnName("Label")]
            public String Tag { get; set; }
            [LoadColumn(1)]
            public String Pattern { get; set; }
        }

        List<Intent> _intents = new List<Intent>();

        public void saveModel()
        {
            using (StreamWriter file = File.CreateText(@"D:\intents.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, _intents);
            }
        }

        public Intent[] ReadTrainData()
        {
            Console.WriteLine("##########################################");
            Console.WriteLine("              Reading File ");
            var jsonString = File.ReadAllText(@"D:\intents.json");
            trainintents = JsonConvert.DeserializeObject<Intent[]>(jsonString);

            Console.WriteLine("Ser");
            foreach (var s in trainintents)
            {
                Console.WriteLine(s.Tag);
            }
            Console.WriteLine("##########################################");

            return trainintents;

        }

        

        public void TrainModel()
        {
            MLContext mLContext = new MLContext();

            TextLoader textLoader = mLContext.Data.CreateTextLoader<IntentTrainingDataTAG>(separatorChar: ',', hasHeader: false);

            IDataView data = textLoader.Load(@"D:\intentStr.txt");


        }

        public Intent FindIntent(String tag, Intent[] intent)
        {
            Console.WriteLine("Searching Tag : " + tag);

            foreach(var i in intent)
            {
                Console.WriteLine("Tag: " + i.Tag.ToLower() + "?,");

                if(i.Tag.ToLower() == tag.ToLower())
                {
                    return i;
                }
            }
            return null;
        }

        public IntentTrainingDataTAG[] fitDataAsTagPattern()
        {
            Console.WriteLine("+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+");
            Console.WriteLine("                Loading Chat Model\n");

            List<IntentTrainingDataTAG> intentTrainingDataTAGs = new List<IntentTrainingDataTAG>();

            foreach(var I in trainintents)
            {
                Console.Write("{ " + I.Tag + ", (");
                for(int i = 0; i < I.Patterns.Length; i++)
                {
                    Console.Write(I.Patterns[i] + ", ");
                    intentTrainingDataTAGs.Add(new IntentTrainingDataTAG
                    {
                        Tag = I.Tag,
                        Pattern = I.Patterns[i]
                    });
                }
                Console.Write(" )}");
                Console.WriteLine();
            }

            Console.WriteLine("\n             Done Chat Model Loading ");
            Console.WriteLine("+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+");

            return intentTrainingDataTAGs.ToArray();

        }

        public void SelializeTrainingTAG(IntentTrainingDataTAG[] ts)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("             Serializing Tags\n");

            using (StreamWriter file = File.CreateText(@"D:\TrainingData.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, ts);
            }

            Console.WriteLine("\n               Done Serializing");
            Console.WriteLine("=============================================");

        }

        public void CraeteCSV(IntentTrainingDataTAG[] tr)
        {
            List<String> intentsStr = new List<String>();

            foreach(var inte in tr)
            {
                intentsStr.Add(inte.Tag + "," + inte.Pattern + "\n");
            }

            File.WriteAllLines(@"D:\intentStr.txt", intentsStr);
        }

    }
}

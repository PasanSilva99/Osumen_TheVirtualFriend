using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Windows.Storage;

namespace Osumen_TheVirtualFriend.ChatKnoladgeBase.Model
{
    public class Intent
    {
        public String TAG { get; set; }
        public String[] Patterns { get; set; }
        public String[] Responces { get; set; }
    }

    public class IntentsForTraining
    {
        public String TAG { get; set; }
        public String Pattern { get; set; }
    }


    class ModelHandler
    {
        // To save the Intents that read from the file.
        Intent[] intents;

        // To save the Intents that are ready for the model
        IntentsForTraining[] intentsForTraining;

        public void PrepareIntentsFile()
        {
            
        }

        public async Task<IntentsForTraining[]> PrepareTrainDataAsync()
        {
 
                // ITD = I { T, Pn }

                // Read the data from the existing file
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                    StorageFile sampleFile =
                         await storageFolder.GetFileAsync("intents.json");
                    string jsonString = await FileIO.ReadTextAsync(sampleFile);

                    intents = JsonConvert.DeserializeObject<Intent[]>(jsonString); // This holdts all the intents that read from the file. With all properties

                    // To train the model, We have to Siplyfy the Data
                    List<IntentsForTraining> ListIFT = new List<IntentsForTraining>();

                    for (int i = 0; i < intents.Length; i++)
                    {
                        foreach (var pattern in intents[i].Patterns)
                        {
                            ListIFT.Add(new IntentsForTraining() { TAG = intents[i].TAG, Pattern = intents[i].Patterns[i] });
                        }
                    }

            return ListIFT.ToArray();
        }

        public ModelHandler()
        {

        }

    }
}

using Osumen_ChatKnoladgeBase.Trainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Osumen_ChatKnoladgeBase.Classifier;
using static Osumen_ChatKnoladgeBase.Trainer.ModelHandler;

namespace Osumen_ChatKnoladgeBase
{
    class ChatGen
    {
        public String GenerateReply(String tag, Intent[] intents)
        {
            Intent intent = new ModelHandler().FindIntent(tag, intents);

            String[] Resposes = intent.Responses;

            Random r = new Random();
            String RandomizedReply = Resposes[r.Next(0, Resposes.Length)];

            if (RandomizedReply.Contains("*~~*#"))
            {
                String req = RandomizedReply.Substring(RandomizedReply.IndexOf("*~~*#"), RandomizedReply.LastIndexOf("#*~~*"));
                Console.WriteLine("Req = " + req);

                String Reply = "";

                

                return Reply;
            }
            else
            {
                return RandomizedReply;
            }
        }
    }
}

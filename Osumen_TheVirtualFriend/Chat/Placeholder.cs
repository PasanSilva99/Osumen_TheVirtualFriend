using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osumen_ChatKnoladgeBase.Placeholders
{
    public class PlaceHolderVar
    {
        public String Placeholder { get; set; }

        public String ReplyString { get; set; }
    }

    class PlaceHolderFunctions
    {
        public PlaceHolderVar[] GetRegisteredPlaceholders()
        {
            var jsonString = File.ReadAllText(@"D:\OsumenDatabase\Placeholders.json");
            var placeholders = JsonConvert.DeserializeObject<PlaceHolderVar[]>(jsonString);

            return placeholders;
        }
    }
}

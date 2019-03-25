using System.Linq;
using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace FountainPlus
{
    class Flags
    {
        // Different flags go here
        public string name;

        // Import function
        public static Flags Import(string s)
        {
            Flags output = new Flags();

            foreach (string file in Directory.GetFiles("./JSON/"))
            {
                output = JsonConvert.DeserializeObject<Flags>(File.ReadAllText(f));
                if (output.name == s) { return output; }
            }

            return null;
        }
    }
}

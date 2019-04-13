using System;
using System.IO;
using Newtonsoft.Json;

namespace FountainPlus {
    class Flags {

        // Different flags go here
        public string name;
        public double version;
        public string delimiter;
        public string globalStyle;
        public string jsSnippet;

        // Import function
        public static Flags Import(string s)
        {
            Flags output = new Flags();

            // If JSON directory exists, search for file
            if (Directory.Exists("./JSON/")) {
                foreach (string f in Directory.GetFiles("./JSON/")) {
                    try {
                        output = JsonConvert.DeserializeObject<Flags>(File.ReadAllText(f));
                        if (output.name == s) { return output; }
                    }

                    catch { }
                }
            }

            // If not, create a directory
            else { Directory.CreateDirectory("./JSON"); }

            return null;
        }
    }
}
using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace FountainPlus {
    class Flags {

        // Different flags go here
        public string name;
        public double version;
        public string delimiter;
        public string author;
        public string globalStyle;
        public string jsSnippet;

        // Import function
        public static Flags Import(string s)
        {
            Flags output = new Flags();

            // If JSON directory exists, search for file

            if (Directory.Exists("./JSON/")) {
                int i = 0;

                //For each file in the directory
                foreach (string f in Directory.GetFiles("./JSON/")) {

                    try
                    {
                        //Try deserializing it
                        output = JsonConvert.DeserializeObject<Flags>(File.ReadAllText(f));
                        if (output.name == s)
                        {
                            //Reading the javascript from the separate file
                            using (StreamReader inputFile = new StreamReader("./JSON/" + output.jsSnippet))
                            {
                                output.jsSnippet = inputFile.ReadToEnd();
                                inputFile.Close();
                            }
                            
                            return output;
                        }
                    }

                    catch {  }
                }
            }

            // If not, create a directory
            else { Directory.CreateDirectory("./JSON"); }

            return null;
        }
    }
}
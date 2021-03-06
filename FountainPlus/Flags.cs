﻿using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace FountainPlus {
    class Flags {

        // Different flags go here
        public string name;
        public double version;
        public char delimiter;
        public string author;
        public string globalStyle;
        public string jsSnippet;

        // Import function
        public static Flags Import(string s)
        {
            Flags output = new Flags();

            // If JSON directory exists, search for file

            if (Directory.Exists("./JSON/")) {

                //For each file in the directory
                foreach (string f in Directory.GetFiles("./JSON/")) {

                    try
                    {
                        //Try deserializing it
                        output = JsonConvert.DeserializeObject<Flags>(File.ReadAllText(f));

                        if (output.name == s)
                        {

                            System.Windows.MessageBox.Show(output.jsSnippet + " - Yeah!");

                            //Reading the javascript from the separate file
                            using (StreamReader inputFile = new StreamReader("./JSON/" + output.jsSnippet))
                            {
                                output.jsSnippet = inputFile.ReadToEnd();
                                inputFile.Close();

                                System.Windows.MessageBox.Show(output.jsSnippet + " - Yeah!");
                            }

                            return output;
                        }
                    }

                    catch
                    {
                        return null;
                    }
                }
            }

            // If not, create a directory
            else { Directory.CreateDirectory("./JSON"); }

            return null;
        }
    }
}
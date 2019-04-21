using System;
using System.Diagnostics;

namespace FountainPlus
{
    class Fountain
    {
        // Ultimate output
        public static string output;

        // Process input
        public static string Process(string input, Flags currentFlag)
        {
            output = "<meta http-equiv=\"X - UA - Compatible\" content=\"IE =11\" >\n";

            //If we do have a flag loaded, then we're running this2
            if (currentFlag != null)
            {
                output += "<html>\r\n\r\n<head>\r\n    " +
                    "<script>\r\n        " +
                    "var lines = [];\r\n        " +
                    "var style = \"font-family: Courier New, Courier, monospace;\"" +
                    "var texts = [";

                input = input.Replace("\r\n", "\n");
                string[] splitByDelimiter = input.Split('\n');

                for (int i = 0; i < splitByDelimiter.Length; i++)
                {
                    Trace.WriteLine("I have this many strings: " + splitByDelimiter.Length);

                    if (i == (splitByDelimiter.Length - 1))
                    {
                        Trace.WriteLine("Chose option 1");
                        output += "\"";
                        output += splitByDelimiter[i];
                        output += "\"";
                    }
                    else
                    {
                        Trace.WriteLine("Chose option 2");

                        output += "\"";
                        output += splitByDelimiter[i];
                        output += "\"";
                        output += ",";
                    }
                }

                output += "];\r\n" +
                    "Array.prototype.slice.call(texts).forEach(function (entry) {\r\n" +
                    currentFlag.jsSnippet +
                    "         });\r\n\r\n    " +
                    "</script>\r\n" +
                    "</head>\r\n\r\n" +

                    "<body>\r\n\r\n    " +
                        "<div id=\"p_text\">\r\n    " +
                        "</div>\r\n\r\n    " +
                        "<script>\r\n        " +
                            "var html = \"\";\r\n\r\n        " +
                            "lines.forEach(function (entry) {\r\n            " +
                            "html += entry.toString();\r\n        " +
                            "});\r\n\r\n        " +
                            "document.getElementById(\"p_text\").innerHTML = html;\r\n    " +
                        "</script>\r\n" +
                    "</body>\r\n\r\n" +
                    "</html>";

            }
            //If we don't have a flag loaded (such as when we're in HTML mode) this gets run instead
            else
            {
                output += input;
            }

            return output;
        }


    }
}
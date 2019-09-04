using System.Collections.Generic;
using System.IO;

namespace FileParser
{
    public class EdiReader
    {
        string Path;

        public EdiReader(string path)
        {
            this.Path = path;
        }

        public string[] ExtractData()
        {
            string content = File.ReadAllText(this.Path);
            string[] segments = content.Split("'");

            List<string> locations = new List<string>();

            foreach (string s in segments)
            {
                string[] el = s.Split("+");
                if (el[0].Replace("\r\n", string.Empty) == "LOC")
                {
                    locations.Add(el[1] + el[2]);
                }
            }

            string[] newLocations = locations.ToArray();

            return newLocations;
        }
    }
}

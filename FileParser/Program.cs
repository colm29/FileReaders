using System;

namespace FileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            EdiReader r = new EdiReader("..//EDIFiles//testFile.EDI");
            string[] locations = r.ExtractData();
            Console.WriteLine("EDIFACT LOCATIONS:");
            foreach (string loc in locations)
            {
                Console.WriteLine(loc);
            }

            XMLReader x = new XMLReader("..//XMLFiles//sample.XML");
            string[] refs = x.ReadXML();
            Console.WriteLine("-------------------");
            Console.WriteLine("XML RefText Values:");
            foreach (string rf in refs)
            {
                Console.WriteLine(rf);
            }


        }
    }
}

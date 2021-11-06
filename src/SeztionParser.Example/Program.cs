using SeztionParser.Facades;
using SeztionParser.Helpers;
using System;
using System.Collections.Generic;

namespace SeztionParser.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string BASE_PATH = "../../../";
            var sections = SectionsFile.Load($"{BASE_PATH}Aim_Headshot.ini");

            Console.WriteLine("------------------- Process (1) -------------------");
            Console.WriteLine("[Alpha]");
            //This prints the data of the "Alpha" section.
            foreach (var data in sections["Alpha"])
                Console.WriteLine(data);
            
            Console.WriteLine();

            Console.WriteLine("[Beta]");
            //This prints the data of the "Beta" section.
            foreach (var data in sections["Beta"])
                Console.WriteLine(data);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("\n\n");

            Console.WriteLine("------------------- Process (2) -------------------");
            foreach (var sectionName in sections.GetNames())
                Console.WriteLine($"Section: {sectionName}");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("\n\n");

            Console.WriteLine("------------------- Process (3) -------------------");
            foreach (var data in sections.GetAll())
                Console.Write(data.ToString());
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("\n\n");

            Console.WriteLine("------------------- Process (4) -------------------");
            foreach (var section in sections)
                Console.Write(section.ToString());
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("\n\n");

            Console.WriteLine("------------------- Process (5) -------------------");
            Console.WriteLine(sections.ToString());
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("\n\n");

            Console.WriteLine("------------------- Process (6) -------------------");
            foreach (var(name, data) in sections)
                Console.WriteLine($"{name}, {data.Count}");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("\n\n");

            Console.WriteLine("------------------- Process (7) -------------------");
            foreach (double value in sections.ToDouble("Angles"))
                Console.WriteLine(value);
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("\n\n");

            Console.WriteLine("------------------- Process (8) -------------------");
            Console.WriteLine($"Interior: {sections.GetFirstLineInt("Interior")}");
            Console.WriteLine($"Angle: {sections.GetFirstLineDouble("Angles")}");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("\n\n");
        }
    }
}

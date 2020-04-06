using System;
using System.Collections.Generic;
// Write a function that accepts a string, and returns a 2-4 character acronym for it.
//
// Examples:
// Application Performance -> AP
// The Department of Homeland Security -> DHS
// Texas -> TXS
// US Air Force -> USAF

namespace Swinmlane
{
    class Program
    {
        static public string GetAcronym(string input)
        {
            string acronym = string.Empty;
            List<string> exception = new List<string>() { "The" };
            List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
            var parts = input.Split(' ');
            if (parts.Length == 1)
            {
                var carr = parts[0].ToCharArray();
                for (int i = 0; i < carr.Length; i++)
                {
                    if (vowels.Contains(carr[i]))
                        continue;
                    acronym += (Convert.ToString(carr[i]).ToUpper());
                }
            }
            else
            {
                for (int i = 0; i < parts.Length; i++)
                {
                    if (exception.Contains(parts[i]))
                        continue;
                    var holder = parts[i];
                    if (holder == parts[i].ToLower())
                        continue;
                    if (holder == parts[i].ToUpper())
                    {
                        acronym += holder;
                        continue;
                    }
                    acronym += parts[i][0];
                }
            }
            if (acronym.Length < 2)
                return acronym;
            if (acronym.Length >= 2 && acronym.Length < 4)
                return acronym;
            return acronym.Substring(0, 4);
        }

        static void Main(string[] args)
        {
            List<string> testcase = new List<string>()
            {
                "Application Performance",
                "The Department of Homeland Security",
                "Texas",
                "US Air Force"
            };
            testcase.ForEach(s =>
            {
                Console.WriteLine(GetAcronym(s));
            });

            Console.ReadKey();
        }
    }
}
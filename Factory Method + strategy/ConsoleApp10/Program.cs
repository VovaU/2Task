using System;
using System.Text.RegularExpressions;

namespace ConsoleApp10
{
    public class ByRegexParser : IParser
    {
        public int GetDigitsCount(string input)
        {
            var regex = new Regex(@"\d");
            int count = regex.Matches(input).Count;
            return count;
        }
    }

    public interface IParser
    {
        int GetDigitsCount(string input);
    }

    public class ByCharParser : IParser
    {
        public int GetDigitsCount(string input)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (c > 47 && c < 58)

                    count++;
            }

            return count;
        }
    }

    public abstract class Creator
    {
        public abstract IParser Create(string type);
    }

    public class ConcreateCreator : Creator

    {
        public override IParser Create(string type)
        {
            switch (type)
            {
                case "regex":
                    return new ByRegexParser();
                case "char":
                    return new ByCharParser();
                default: return null;
            }
        }
    }

    public class DigitsCountParser
    {
        public int GetDigitsCount(string input, IParser parser)

        {
            return parser.GetDigitsCount(input);
        }
    }

    public class Program
    {
        public static void Main(string[] args)

        {
            string input = "hello09";
            string type = "regex";
            Creator creator = new ConcreateCreator();
            var parser = creator.Create(type);
            DigitsCountParser digitsCount = new DigitsCountParser();
            Console.WriteLine(digitsCount.GetDigitsCount(input, parser));
            type = "char";
            parser = creator.Create(type);
            Console.WriteLine(digitsCount.GetDigitsCount(input, parser));
            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            Kyiv _kyiv = Kyiv.getInstance();
            Console.WriteLine(_kyiv.Country);
            Console.Read();
        }
    }

    public class Kyiv
    {
        private static Kyiv _instance;
        public string Country { get; private set; } = "Ukraine";
        public static Kyiv getInstance()
        {
            if (_instance == null)
            {
                _instance = new Kyiv();
            }
            return _instance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository  _request = new Repository();
            _request.Request();
            Console.ReadKey();
        }

        
    }

    interface IRepository
    {
        void Request();
    }

    class Repository: LegacyRepository, IRepository
    {
        public void Request()
        {
            RequestToDataBase();
        }   
    }

    class LegacyRepository
    {
        public void RequestToDataBase()
        {
            Console.WriteLine("Hi, from Legacy");
        }
    }
}

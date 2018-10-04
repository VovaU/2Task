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
            DetailFactory factory = new DetailFactory(new Worker(),new PhoneDetail() );
            factory.CreateDetail();
            factory.DetailInformation();
            Console.ReadKey();
        }
    }

    class DetailFactory
    {
        private Worker _worker;
        private PhoneDetail _phoneDetail;
        public DetailFactory(Worker worker, PhoneDetail detail)
        {
            _worker = worker;
            _phoneDetail = detail;
        }

        private string info = "";

        public void CreateDetail()
        {
            info = $"Maker: {_worker.Name}, Detail name: {_phoneDetail.NameOfDetail}";
        }

        public void DetailInformation()
        {
            Console.WriteLine(info);
        }

    }

    class Worker
    {
        public string Name = "Arnold";

        public Worker(string name = "Arnold")
        {
            Name = name;
        }
    }

    class PhoneDetail
    {
        public string NameOfDetail;

        public PhoneDetail(string name = "RAM")
        {
            NameOfDetail = name;
        }
    }



}

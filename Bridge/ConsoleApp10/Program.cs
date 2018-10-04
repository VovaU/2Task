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
            Phone _xPhone = new Xiaomi(new WirelessCharger());
            _xPhone.ChargePhone();
            Console.ReadKey();
        }
    }

    abstract class Charger
    {
        public string NameOfCharger;
        public void Charge()
        {
            Console.WriteLine($"I am charging by {NameOfCharger}");
        }
    }


     abstract class Phone
    {
        public Charger _charger;

        public Phone(Charger charger)
        {
            _charger = charger;
        }

        public virtual void ChargePhone()
        {
            _charger.Charge();
        }
    }

     class Xiaomi : Phone
    {
        public Xiaomi(Charger charger) : base(charger)
        { 
        }
    }

    class WirelessCharger : Charger
    {
        public WirelessCharger()
        {
            base.NameOfCharger = "Wireless charger";
        }
    }
}

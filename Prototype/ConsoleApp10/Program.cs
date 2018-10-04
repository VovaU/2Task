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
            Rectangle r = new Rectangle(null);
            r.X = 1;
            r.width = 2;
            Console.WriteLine($"r: {r.X}, {r.width}");
            Rectangle r2 = r.Clone() as Rectangle;
            Console.WriteLine($"r2: {r2.X}, {r2.width}");
            Console.ReadKey();
        }
    }

    public abstract class Shape
    {
        public int X;
        public int Y;
        public string Color;

        public Shape(Shape source)
        {
            if (source != null)
            {
                this.X = source.X;
                this.Y = source.Y;
                this.Color = source.Color;
            }
        }

        public abstract Shape Clone();
    }


    public class Rectangle : Shape
    {
        public int width;
        public int height;

        public Rectangle(Rectangle source) : base(source)
        {
            if (source != null)
            {
                this.width = source.width;
                this.height = source.height;
            }
        }

        public override Shape Clone()
        {
            return new Rectangle(this);
        }
    }
}

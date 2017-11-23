using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;
            bool[] chek = new bool[3];

            for (int i = 0; i < 3; i++)
            {
                chek[i] = false;
            }
            do
            {
                Console.WriteLine("a");
                string line = Console.ReadLine();
                chek[0] = double.TryParse(line, out a);
                Console.WriteLine("b");
                line = Console.ReadLine();
                chek[1] = double.TryParse(line, out b);
                Console.WriteLine("c");
                line = Console.ReadLine();
                chek[2] = double.TryParse(line, out c);
            } while (chek[0] == false || chek[1] == false || chek[2] == false);
            double D = b * b - 4 * a * c;
            if (D > 0)
            {
                double x1 = (-b - Math.Sqrt(D)) / (2 * a);
                Console.WriteLine("x1="+ x1);
                double x2 = (-b + Math.Sqrt(D)) / (2 * a);
                Console.WriteLine("x2="+ x2);
            }
            else
            {
                if (D == 0)
                {
                    double x = -b / (2 * a);
                    Console.WriteLine("x="+ x);
                }
                else
                {
                    Console.WriteLine("nope");
                }
            }
            
        }
    }
}

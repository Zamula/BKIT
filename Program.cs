using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    delegate string DosomeThing( int p1, string p2, double p3);
    class Program
    {
        static string DoPation(int p1, string p2, double p3 = 14.5)
        {
            string str = p2 + p3.ToString();
            for (int i = 0; i < p1; i++)
            {
                str += '!';
            }
            return str;
        }
        static string DoSad(int p1, string p2, double p3 = 12.6)
        {
            string str = p2 + p3.ToString();
            for (int i = 0; i < p1; i++)
            {
                str += '(';
            }
            return str;
        }

        static void DosomeThingMethod(string str, int i1, double i2, DosomeThing imdoing)
        {
            string result = imdoing(i1, str, i2);
            Console.WriteLine(result);
        }
        static void DosomeThingMethodFunc(string str, int i1, double i2, Func<int, string, double, string> imdoing)
        {
            string Result = imdoing(i1, str, i2);
            Console.WriteLine(Result);
        }

        // 22222222222222222222222222222
        static void TypeInfo()
        {
            Reflect obj = new Reflect();
            Type t = obj.GetType();

            Console.WriteLine("\nКонструкторы:");
            foreach (var x in t.GetConstructors())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nМетоды:");
            foreach (var x in t.GetMethods())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nСвойства:");
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }
        }
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;
            
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }

            return Result;
        }

        static void AttributeInfo()
        {
            Type t = typeof(Reflect);
            Console.WriteLine("\nСвойства, помеченные атрибутом:");
            foreach (var x in t.GetProperties())
            {
                object attrObj;
                if (GetPropertyAttribute(x, typeof(Atr), out attrObj))
                {
                    Atr attr = attrObj as Atr;
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }
        }

        static void InvokeMemberInfo()
        {
            Type t = typeof(Reflect);
            Console.WriteLine("\nВызов метода:");
            
            Reflect fi = (Reflect)t.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });
            
            object[] parameters = new object[] { "Dan", "Katty" };
            object Result = t.InvokeMember("SayHello", BindingFlags.InvokeMethod, null, fi, parameters);
            Console.WriteLine("SayHello(Dan, Katty)={0}", Result);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("ПЕРВАЯ ЧАСТЬ!!!!");
            string str = "sos";
            int i1 = 3;
            double i2 = 13.3;
            DosomeThingMethod(str, i1, i2, DoPation);
            DosomeThingMethodFunc(str, i1, i2, DoSad);
            DosomeThing p1 = (int i11, string str1, double i22) =>
            {
                string result = str1 + i22.ToString();
                for (int i = 0; i < i11; i++)
                {
                    result += "metod";
                }
                return result;
            };
            DosomeThingMethod("лямбда-выражения1", i1, i2, p1);
            DosomeThingMethodFunc("лямбда-выражения2", i1, i2,
                (int i11, string str1, double i22) =>
                {
                    string result = str1 + i22.ToString();
                    for (int i = 0; i < i11; i++)
                    {
                        result += "Func";
                    }
                    return result;
                }
                );
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("ВТОРАЯ ЧАСТЬ!!!!");
            TypeInfo();
            InvokeMemberInfo();
            AttributeInfo();

            Console.ReadLine();



        }
    }
}

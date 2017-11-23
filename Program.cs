using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_сем_2_лаба
{
    class Program
    {
        static void Main(string[] args)
        {
           circle first;
            first = new circle(4);
            rectangle second = new rectangle(2, 4);
            square third = new square(6);

            Console.WriteLine("Вывод значений через Iprint:");
            first.print();
            second.print();
            third.print();

            ArrayList figure_list = new ArrayList() { first, second, third };
            List<Figure> figure_list2 = new List<Figure>() { first, second, third };
            figure_list.Sort();

            Console.WriteLine("\nВывод отсортированных значений в ArrayList:");

            foreach (Figure f in figure_list)
            {
                Console.WriteLine(f);
            }

            figure_list2.Sort();

            Console.WriteLine("\nВывод отсортированных значений в List:");

            foreach (Figure f in figure_list2)
            {
                Console.WriteLine(f);
            }

            Console.WriteLine("\nМатрица[3,3,2]");
            Matrix<Figure> matrix = new Matrix<Figure>(3, 3, 2, new FigureMatrixCheckEmpty());
            matrix[0, 0, 0] = first;
            matrix[1, 1, 0] = second;
            matrix[2, 2, 1] = third;
            Console.WriteLine(matrix.ToString());

            //Выход за границы индекса и обработка исключения 
            try
            {
                Figure temp = matrix[12, 12, 12];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nСписок");
            SimpleList<Figure> list = new SimpleList<Figure>();
            list.Add(first);
            list.Add(second);
            list.Add(third);
            Console.WriteLine("\nПеред сортировкой:");
            foreach (var x in list) Console.WriteLine(x);
            //сортировка
            list.Sort();
            Console.WriteLine("\nПосле сортировки:");
            foreach (var x in list) Console.WriteLine(x);
            
            Console.WriteLine("\nСтек");

            SimpleStack<Figure> stack = new SimpleStack<Figure>();
            //добавление данных в стек
            stack.Push(first);
            stack.Push(second);
            stack.Push(third);
            //чтение данных из стека
            while (stack.Count > 0)
            {
                Figure f = stack.Pop();
                Console.WriteLine(f);
            }

            Console.ReadLine();
        }
    }
    public interface Iprint
    {
        void print();
    }
    abstract class Figure : IComparable
    {
        public double squr;

        public int CompareTo(object obj)
        {
            Figure p = (Figure)obj;
            if (this.squr < p.squr) return -1;
            else if (this.squr == p.squr) return 0;
            else return 1;
        }

  
    }
    class circle : Figure, Iprint
    {
        int r;

        public circle(int x)
        {
            r = x;
            squr = 3.14 * r * r;
        }
        public override string ToString()
        {
            string result = "radius : " + r.ToString();
            result = result + "; ploshad : ";
            result = result + squr.ToString();
            return result;
        }
        public void print()
        {
            Console.WriteLine(this.ToString());
        }


    }

    class rectangle : Figure, Iprint
    {
        int w;
        protected int l;
        public rectangle(int x, int y)
        {
            w = x;
            l = y;
            squr = w * l;
        }
        public rectangle(int x)
        {
            l = x;
            squr = l * l;
        }
        public override string ToString()
        {
            string result = w.ToString() + " : weidth ; ";
            result = result + l.ToString() + " : long; " + squr.ToString() + " : ploshad";
            return result;
        }
        public void print()
        {
            Console.WriteLine(this.ToString());
        }

    }

    class square : rectangle, Iprint
    {
        public square(int x) : base(x)
        {
            l = x;
        }
        public override string ToString()
        {
            string result = l.ToString() + " : long; " + squr.ToString() + " : ploshad";
            return result;
        }
        public void print()
        {
            Console.WriteLine(this.ToString());
        }

    }
    public class Matrix<T>
    {
        Dictionary<string, T> _matrix = new Dictionary<string, T>();
        
        int maxX;
        int maxY;
        int maxZ;
        IMatrixCheckEmpty<T> сheckEmpty;

        public Matrix(int px, int py, int pz, IMatrixCheckEmpty<T> сheckEmptyParam)
        {
            this.maxX = px;
            this.maxY = py;
            this.maxZ = pz;
            this.сheckEmpty = сheckEmptyParam;
        }
        
        public T this[int x, int y, int z]
        {
            set
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                this._matrix.Add(key, value);
            }
            get
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                if (this._matrix.ContainsKey(key))
                {
                    return this._matrix[key];
                }
                else
                {
                    return this.сheckEmpty.getEmptyElement();
                }
            }
        }
        void CheckBounds(int x, int y, int z)
        {
            if (x < 0 || x >= this.maxX)
            {
                throw new ArgumentOutOfRangeException("x", "x=" + x + " выходит за границы");
            }
            if (y < 0 || y >= this.maxY)
            {
                throw new ArgumentOutOfRangeException("y", "y=" + y + " выходит за границы");
            }
            if (z < 0 || z >= this.maxZ)
            {
                throw new ArgumentOutOfRangeException("z", "z=" + z + " выходит за границы");
            }
        }
        
        string DictKey(int x, int y, int z)
        {
            return x.ToString() + "_" + y.ToString() + "_" + z.ToString();
        }
        
        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            for (int k = 0; k < this.maxZ; k++)
            {
                string temp = "z = " + k.ToString() + '\n';
                b.Append(temp);
                for (int j = 0; j < this.maxY; j++)
                {
                    b.Append("[");
                    for (int i = 0; i < this.maxX; i++)
                    {
                        //Добавление разделителя-табуляции 
                        if (i > 0)
                        {
                            b.Append("\t");
                        }
                        //Если текущий элемент не пустой 
                        if (!this.сheckEmpty.checkEmptyElement(this[i, j, k]))
                        {
                            //Добавить приведенный к строке текущий элемент 
                            b.Append(this[i, j, k].ToString());
                        }
                        else
                        {
                            //Иначе добавить признак пустого значения 
                            b.Append(" - ");
                        }
                    }
                    b.Append("]\n");
                }
            }
            return b.ToString();
        }
    }

    class FigureMatrixCheckEmpty : IMatrixCheckEmpty<Figure>
    {
        public Figure getEmptyElement()
        {
            return null;
        }
        
        public bool checkEmptyElement(Figure element)
        {
            bool Result = false;
            if (element == null)
            {
                Result = true;
            }
            return Result;
        }
    }

    public interface IMatrixCheckEmpty<T>
    {
        T getEmptyElement();
        bool checkEmptyElement(T element);
    }
}

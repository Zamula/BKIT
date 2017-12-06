using System;

namespace lab_6
{
    class Reflect : IComparable
    {
        public Reflect() { }
        public Reflect(string  i) { }
        public Reflect(string i, string j) { }

        public string SayHello(string str, string str1) { return "Hi " + str + " and " + str1; }
        public string SayBuy(string str) { return "Buy" + str; }
        public string property1
        {
            get { return _property1; }
            set { _property1 = value; }
        }
        private string _property1;
        public int property2 { get; set; }
        [Atr(Description = "Описание для property3")]
        public double property3 { get; private set; }

        public int myfield1;
        public float myfield2;
        public int CompareTo(object obj)
        {
            return 0;
        }

    }
}

using System;
namespace lab_6
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    class Atr : Attribute
    {
        public Atr() { }
        public Atr(string Desc)
        {
            Description = Desc;
        }
        public string Description { get; set; }
    }
}

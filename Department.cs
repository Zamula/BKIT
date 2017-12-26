
namespace lab_7
{
    class Department
    {
        public int id;
        public string name;

        public Department(int i, string n)
        {
            this.id = i;
            this.name = n;
        }

        public override string ToString()
        {
            return "id=" + this.id.ToString() + "; наименование отдела : " + this.name.ToString();
        }
    }
}

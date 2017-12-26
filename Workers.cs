namespace lab_7
{
    class Workers
    {
        public int id;
        public string name;
        public int dep_id;

        public Workers(int i, string n, int d)
        {
            this.id = i;
            this.name = n;
            this.dep_id = d;
        }

        public override string ToString()
        {
            return "id=" + this.id.ToString() + "; фамилия : " + this.name.ToString() + "; отдел : " + this.dep_id.ToString(); 
        }
    }
}

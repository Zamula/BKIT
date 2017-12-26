using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_7
{
    class Program
    {
        static List<Workers> staff = new List<Workers>
        {
            new Workers(1,"Иванов", 1),
            new Workers(2,"Абрамов", 2),
            new Workers(3,"Кузнецова", 3),
            new Workers(4,"Козлова", 4),
            new Workers(5,"Александрова", 5),
            new Workers(6,"Жуков", 6),
            new Workers(7,"Филиппов", 7),
            new Workers(8,"Орехов", 8),
            new Workers(9,"Горшкова", 9),
            new Workers(10,"Петухов", 1),
            new Workers(11,"Ильин", 2),
            new Workers(12,"Калашникова", 3),
            new Workers(13,"Князев", 4),

        };

        static List<Department> dep = new List<Department>
        {
            new Department(1, "Снабжение"),
            new Department(2, "Отдел кадров"),
            new Department(3, "Бухгалтерия"),
            new Department(4, "Диспетчерский"),
            new Department(5, "Маркетинговый "),
            new Department(6, "Финансовый"),
            new Department(7, "Закупки"),
            new Department(8, "Управление"),
            new Department(9, "Охрана"),
        };

        static List<WorkersOfDepartments> link = new List<WorkersOfDepartments>
        {
            new WorkersOfDepartments(1,1),
            new WorkersOfDepartments(2,2),
            new WorkersOfDepartments(3,3),
            new WorkersOfDepartments(4,4),
            new WorkersOfDepartments(5,5),
            new WorkersOfDepartments(6,6),
            new WorkersOfDepartments(7,7),
            new WorkersOfDepartments(8,8),
            new WorkersOfDepartments(9,9),
            new WorkersOfDepartments(10,1),
            new WorkersOfDepartments(11,2),
            new WorkersOfDepartments(12,3),
            new WorkersOfDepartments(13,4),

        };

        static void Main(string[] args)
        {
            
            
            // ПУНКТ 44444444444


            Console.WriteLine("список всех сотрудников и отделов, отсортированный по отделам");
            var selectStuff = from s in staff
                              join t in dep on s.dep_id equals t.id
                              orderby t.id
                              select new { Id = s.id, Name = s.name, IdDep = t.id, NameDep = t.name };
            foreach (var t in selectStuff)
                Console.WriteLine("ID сотрудника : {0}, Фамилия : {1}, Отдел : {2}", t.Id, t.Name, t.NameDep);



            Console.WriteLine("\n\nсписок всех сотрудников, у которых фамилия начинается с буквы «А»");
            var selectStuff2 = from t in staff
                               where t.name.ToUpper().StartsWith("А")
                               orderby t.dep_id
                               select t;
            foreach (var t in selectStuff2)
                Console.WriteLine(t);


            Console.WriteLine("\n\nсписок всех отделов и количество сотрудников в каждом отделе");
            var selectStuff3 = from t in selectStuff
                               group t by t.NameDep into depGroup
                               select new
                               {
                                   Dep = depGroup.Key,
                                   Count = depGroup.Count()
                               };
            foreach (var t in selectStuff3)
                Console.WriteLine("Название отдела : {0}, Количество сотрудников: {1}", t.Dep, t.Count);


            Console.WriteLine("\n\nсписок отделов, в которых хотя бы у одного сотрудника фамилия начинается с буквы «А»");
            var selectStuff4 = from t in selectStuff
                               where t.Name.ToUpper().StartsWith("А")
                               orderby t.IdDep
                               select t;
            foreach (var t in selectStuff4)
                Console.WriteLine("{1} : {0}", t.NameDep, t.IdDep);


            Console.WriteLine("\n\nсписок отделов, в которых у всех сотрудников фамилия начинается с буквы «А»");
            var selectStuff5 = from t in selectStuff
                               group t by t.NameDep into depGroup
                               where depGroup.All(t => t.Name.ToUpper().StartsWith("А"))
                               select new
                               {
                                   Dep = depGroup.Key
                               };
            foreach (var t in selectStuff5)
                Console.WriteLine("{0}", t.Dep);


            // ПУНКТ 6666666666666

            Console.WriteLine("\n\n\n\nсписок всех отделов и список сотрудников в каждом отделе");
            var link1 = from x in staff
                       join l in link on x.id equals l.w into temp
                       from t1 in temp
                       join y in dep on t1.d equals y.id into temp2
                       from t2 in temp2
                       group t2 by t2.id into office
                       select new
                       {
                           ID = office.Key,
                           Count = office.Count(),
                           Worker = from w in staff
                                    where w.dep_id == office.Key
                                    select w
                       };
            
            foreach (var off in link1)
            {
                Console.WriteLine("{0} : {1}", off.ID, off.Count);
                foreach (Workers worker in off.Worker)
                    Console.WriteLine(worker.name);
            }

        }
    }
}

using System;
using System.Collections.Generic;

namespace Collectlt
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Employee> employees = new List<Employee>
            //{
            //    new Employee{Name="Scott"},
            //    new Employee{Name="Alex"}
            //};
            //employees.Add(new Employee { Name = "Dani" });
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee.Name);
            //}
            //for (int i  = 0; i  < employees.Count; i ++)
            //{
            //    Console.WriteLine(employees[i].Name);
            //}

            //FIFO data structure
            //Queue<Employee> line = new Queue<Employee>();
            //line.Enqueue(new Employee { Name = "Alex" });
            //line.Enqueue(new Employee { Name = "Dani" });
            //line.Enqueue(new Employee { Name = "Chris" });
            //while (line.Count > 0)
            //{
            //    var employee = line.Dequeue(); ;
            //    Console.WriteLine(employee.Name);
            //}

            //LIFO data structure
            //Stack<Employee> stack = new Stack<Employee>();
            //stack.Push(new Employee { Name = "Alex" });
            //stack.Push(new Employee { Name = "Dani" });
            //stack.Push(new Employee { Name = "Chris" });
            //while (stack.Count > 0)
            //{
            //    var employee = stack.Pop(); ;
            //    Console.WriteLine(employee.Name);
            //}

            //HashSet<int> set = new HashSet<int>();
            //set.Add(1);
            //set.Add(2);
            //set.Add(2);
            //foreach (var item in set)
            //{
            //    Console.WriteLine(item);
            //}

            //LinkedList<int> list = new LinkedList<int>();
            //list.AddFirst(2);
            //list.AddFirst(3);
            //var first = list.First;
            //list.AddAfter(first, 5);
            //list.AddBefore(first, 10);

            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}

            Dictionary<string,List<Employee>> employeesByName = new Dictionary<string,List<Employee>>();
            employeesByName.Add("Scott",
                new List<Employee> { new Employee { Name = "Scott" } });


            employeesByName["Scott"].Add(new Employee { Name = "Scott" });

            foreach (var item in employeesByName)
            {
                foreach (var employee in item.Value)
                {
                    Console.WriteLine(employee.Name);

                }
            }
        }
    }
}


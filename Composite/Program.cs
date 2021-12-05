  using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee furkan = new Employee { Name = "Furkan Dur" };
            Employee selim = new Employee { Name = "Selim Dur" };
            Employee engin = new Employee { Name = "Engin Demiroğ" };

            selim.AddSubordinates(furkan);
            engin.AddSubordinates(furkan);

            Console.WriteLine(selim.Name);
            foreach (Employee manager in selim)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (Employee employee in manager)
                {
                    Console.WriteLine("  {0}",employee.Name);
                }
            }

            Console.ReadLine();
        }

    }

    interface IPerson
    {
        string Name { get; set; }
    }

    
    class Employee:IPerson,IEnumerable<IPerson>
    {
        private List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinates(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinates(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

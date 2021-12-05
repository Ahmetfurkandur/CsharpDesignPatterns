using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesingPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer { Name = "Furkan", Surname = "Dur", City = "Kayseri" };   
            
            var customer2 = (Customer)customer1.Clone();
            customer2.Name = "Şaban";

            Console.WriteLine(customer1.Name);
            Console.WriteLine(customer2.Name);

            
            Console.Read();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public string Name { get; set; }
        public string Surname { get; set; }
        
    }

    class Customer : Person
    {
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
        public string City { get; set; }
    }
}

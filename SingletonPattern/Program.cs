using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var _customerManager = CustomerManager.CreateAsSingleton();
            _customerManager.Add();
            Console.ReadKey();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object();
        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            //Normally Singleton
            //return _customerManager ?? (_customerManager = new CustomerManager());

            //Thread safe singleton
            lock (_lockObject)
            {
                if (_customerManager==null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
        }

        public void Add()
        {
            Console.WriteLine("Added!");
        }
    }
}

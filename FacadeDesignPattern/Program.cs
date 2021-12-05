using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();

            customerManager.Save();

            Console.ReadKey();
        }
        
    }

    class Logging:ILogging
    {
       public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    interface ILogging
    {
        void Log();
    }

    class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize:IAuthorize
    {
        public void UserCheck()
        {
            Console.WriteLine("User Checked");
        }
    }

    internal interface IAuthorize
    {
        void UserCheck();
    }

    class CustomerManager
    {
        private CrossCuttingConcernsFacade _concerns;

        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernsFacade();

        }

        public void Save()
        {
            _concerns.logging.Log();
            _concerns.caching.Cache();
            _concerns.authorize.UserCheck();
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging logging;
        public ICaching caching;
        public IAuthorize authorize;

        public CrossCuttingConcernsFacade()
        {
            logging = new Logging();
            caching = new Caching();
            authorize = new Authorize();
        }
    }
}

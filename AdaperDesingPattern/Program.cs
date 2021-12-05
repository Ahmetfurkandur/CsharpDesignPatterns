using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();
            Console.ReadLine();
        }
    }

    class ProductManager
    {
        private readonly ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved");
        }
    }

    class FdLogger:ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Logged {message}");
        }
    }

    internal interface ILogger
    {
        void Log(string message);
    }

    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with Log4Net");
            
        }
    }
    class Log4NetAdapter : ILogger
    {
        Log4Net _log4Net = new Log4Net();
        public void Log(string message)
        {
            _log4Net.LogMessage(message);
        }
    }
}

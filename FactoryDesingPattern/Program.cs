using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesingPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            BlogManager blogManager = new BlogManager(new LoggerFactory2());
            blogManager.Save();

            Console.ReadLine();
        }
    }

    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new BlogLogger();
        }
    }

    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class BlogLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Blog is logged successful!! by BlogLogger");
        }
    }

    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("logged by Log4NetLogger");
        }
    }
    public class BlogManager
    {
        private ILoggerFactory _loggerFactory;

        public BlogManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved!!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}

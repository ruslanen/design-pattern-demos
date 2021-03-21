using System;

namespace DesignPatternDemos.Strategy
{
    public class ConsoleLoggingStrategy : ILoggingStrategy
    {
        public void Log(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}
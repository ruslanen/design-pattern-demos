using System;
using System.IO;

namespace DesignPatternDemos.Strategy
{
    public class FileLoggingStrategy : ILoggingStrategy
    {
        public void Log(string message)
        {
            File.WriteAllText("log.txt", $"{DateTime.Now}: {message}");
        }
    }
}
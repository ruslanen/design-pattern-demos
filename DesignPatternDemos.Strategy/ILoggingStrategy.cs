using System;

namespace DesignPatternDemos.Strategy
{
    public interface ILoggingStrategy
    {
        void Log(string message);
    }
}
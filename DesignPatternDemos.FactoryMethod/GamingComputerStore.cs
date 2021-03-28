using System;

namespace DesignPatternDemos.FactoryMethod
{
    /// <summary>
    /// Конкретный создатель
    /// </summary>
    public class GamingComputerStore : ComputerStore
    {
        protected override Computer CreateComputer(string type)
        {
            switch (type)
            {
                case "budget":
                    return new GamingComputerBudget();
                case "top":
                    return new GamingComputerTop();
                default:
                    throw new ArgumentException("Unreachable code");
            }
        }
    }
}
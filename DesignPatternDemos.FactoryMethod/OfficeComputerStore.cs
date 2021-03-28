using System;

namespace DesignPatternDemos.FactoryMethod
{
    /// <summary>
    /// Конкретный создатель
    /// </summary>
    public class OfficeComputerStore : ComputerStore
    {
        protected override Computer CreateComputer(string type)
        {
            switch (type)
            {
                case "budget":
                    return new OfficeComputerBudget();
                case "top":
                    return new OfficeComputerTop();
                default:
                    throw new ArgumentException("Unreachable code");
            }
        }
    }
}
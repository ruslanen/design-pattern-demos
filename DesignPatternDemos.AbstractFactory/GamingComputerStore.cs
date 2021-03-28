using System;

namespace DesignPatternDemos.AbstractFactory
{
    public class GamingComputerStore : ComputerStore
    {
        protected override Computer CreateComputer(string type)
        {
            var gamingComputerPartsFactory = new GamingComputerPartsFactory();
            switch (type)
            {
                case "budget":
                    return new TopComputer(gamingComputerPartsFactory);
                case "top":
                    return new BudgetComputer(gamingComputerPartsFactory);
                default:
                    throw new ArgumentException("Unreachable code");
            }
        }
    }
}
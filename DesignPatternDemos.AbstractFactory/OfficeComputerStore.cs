using System;

namespace DesignPatternDemos.AbstractFactory
{
    /// <summary>
    /// Конкретный создатель
    /// </summary>
    public class OfficeComputerStore : ComputerStore
    {
        protected override Computer CreateComputer(string type)
        {
            var officeComputerPartsFactory = new OfficeComputerPartsFactory();
            switch (type)
            {
                case "budget":
                    return new BudgetComputer(officeComputerPartsFactory);
                case "top":
                    return new TopComputer(officeComputerPartsFactory);
                default:
                    throw new ArgumentException("Unreachable code");
            }
        }
    }
}
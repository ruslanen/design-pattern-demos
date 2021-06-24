using System;

namespace DesignPatternDemos.Mediator
{
    public class CoffeeMachineDevice : Device
    {
        public CoffeeMachineDevice(IMediator mediator) : base(mediator)
        {
        }

        public override void Notify(string command)
        {
            Console.WriteLine("Command to coffee machine: " + command);
        }
    }
}
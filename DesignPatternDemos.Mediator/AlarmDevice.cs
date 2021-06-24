using System;

namespace DesignPatternDemos.Mediator
{
    public class AlarmDevice : Device
    {
        public AlarmDevice(IMediator mediator) : base(mediator)
        {
        }

        public override void Notify(string command)
        {
            Console.WriteLine("Command to alarm device: " + command);
        }
    }
}
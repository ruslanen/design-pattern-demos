using System;

namespace DesignPatternDemos.Mediator
{
    public class GrillDevice : Device
    {
        public GrillDevice(IMediator mediator) : base(mediator)
        {
        }

        public override void Notify(string command)
        {
            Console.WriteLine("Command to grill device: " + command);
        }
    }
}
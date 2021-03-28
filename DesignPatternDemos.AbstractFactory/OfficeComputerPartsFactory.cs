using DesignPatternDemos.AbstractFactory.Parts;

namespace DesignPatternDemos.AbstractFactory
{
    public class OfficeComputerPartsFactory : IComputerPartsFactory
    {
        public ICpu CreateCpu()
        {
            return new i3Cpu();
        }

        public IVideoCard CreateVideoCard()
        {
            return new Gtx750TiVideoCard();
        }

        public IRam CreateRam()
        {
            return new Ddr4_8gbRam();
        }
    }
}
using DesignPatternDemos.AbstractFactory.Parts;

namespace DesignPatternDemos.AbstractFactory
{
    public class GamingComputerPartsFactory : IComputerPartsFactory
    {
        public ICpu CreateCpu()
        {
            return new i9Cpu();
        }

        public IVideoCard CreateVideoCard()
        {
            return new Rtx3060VideoCard();
        }

        public IRam CreateRam()
        {
            return new Ddr4_16gbRam();
        }
    }
}
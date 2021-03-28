using DesignPatternDemos.AbstractFactory.Parts;

namespace DesignPatternDemos.AbstractFactory
{
    public interface IComputerPartsFactory
    {
        ICpu CreateCpu();
        
        IVideoCard CreateVideoCard();
        
        IRam CreateRam();
    }
}
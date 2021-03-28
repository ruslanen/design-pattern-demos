namespace DesignPatternDemos.AbstractFactory
{
    public class TopComputer : Computer
    {
        private readonly IComputerPartsFactory _computerPartsFactory;

        public TopComputer(IComputerPartsFactory computerPartsFactory)
        {
            _computerPartsFactory = computerPartsFactory;
        }
        
        protected override void Build()
        {
            Cpu = _computerPartsFactory.CreateCpu();
            VideoCard = _computerPartsFactory.CreateVideoCard();
            Ram = _computerPartsFactory.CreateRam();
        }
    }
}
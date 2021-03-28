namespace DesignPatternDemos.AbstractFactory
{
    public class BudgetComputer : Computer
    {
        private readonly IComputerPartsFactory _computerPartsFactory;

        public BudgetComputer(IComputerPartsFactory computerPartsFactory)
        {
            _computerPartsFactory = computerPartsFactory;
        }
        
        protected override void Build()
        {
            Cpu = _computerPartsFactory.CreateCpu();
            Ram = _computerPartsFactory.CreateRam();
            VideoCard = _computerPartsFactory.CreateVideoCard();
        }
    }
}
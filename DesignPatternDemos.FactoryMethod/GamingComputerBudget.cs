namespace DesignPatternDemos.FactoryMethod
{
    public class GamingComputerBudget : Computer
    {
        public override void InstallSoftware()
        {
            base.InstallSoftware();
            // Установить дополнительный софт
        }
    }
}
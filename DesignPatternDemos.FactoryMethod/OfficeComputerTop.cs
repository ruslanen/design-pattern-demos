namespace DesignPatternDemos.FactoryMethod
{
    public class OfficeComputerTop : Computer
    {
        public override void InstallSoftware()
        {
            // Установить специализированный софт
        }

        public override void Package()
        {
            // Упаковать в фирменную дорогую упаковку
        }
    }
}
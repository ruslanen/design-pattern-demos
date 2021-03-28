namespace DesignPatternDemos.FactoryMethod
{
    public class GamingComputerTop : Computer
    {
        public override void InstallSoftware()
        {
            base.InstallSoftware();
            // Установить дополнительный софт
        }

        public override void Package()
        {
            // Упаковать в фирменную дорогую упаковку
        }
    }
}
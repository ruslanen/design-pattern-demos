namespace DesignPatternDemos.FactoryMethod
{
    public abstract class Computer
    {
        public virtual void InstallSoftware()
        {
            // Установить базовый набор софта
        }

        public virtual void Package()
        {
            // Упаковать в стандартную упаковку
        }
    }
}
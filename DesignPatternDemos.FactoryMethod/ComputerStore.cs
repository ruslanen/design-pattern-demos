namespace DesignPatternDemos.FactoryMethod
{
    /// <summary>
    /// Абстрактный класс-создатель
    /// Определяет фабричный метод, реализуемый субклассами для создания экземпляров
    /// </summary>
    public abstract class ComputerStore
    {

        public Computer OrderComputer(string type)
        {
            Computer computer = CreateComputer(type);
            computer.InstallSoftware();
            computer.Package();
            return computer;
        }

        protected abstract Computer CreateComputer(string type);
    }
}
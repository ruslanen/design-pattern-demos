namespace DesignPatternDemos.ChainOfResponsibility
{
    /// <summary>
    /// Допустимо также создавать и интерфейс и базовый класс для выделения базовой логики обработчиков
    /// в цепочке обязанностей
    /// </summary>
    public interface IHandler
    {
        public IHandler NextHandler { get; set; }

        public void HandleMessage(CommandItem message);
    }
}
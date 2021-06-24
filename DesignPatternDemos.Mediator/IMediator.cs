namespace DesignPatternDemos.Mediator
{
    /// <summary>
    /// Посредник определяет интерфейс для обмена информацией с компонентами.
    /// Как правило, достаточно одного метода. В его параметрах можно передавать детали события:
    /// ссылку на компонент или другие данные.
    /// </summary>
    public interface IMediator
    {
        public void Send(string command, Device device);
    }
}
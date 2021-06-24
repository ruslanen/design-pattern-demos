namespace DesignPatternDemos.Mediator
{
    /// <summary>
    /// Реализации этого класса являются компонентами, содержащую бизнес-логику программы.
    /// Каждый компонент хранит ссылку на посредника, но работает с ним только через интерфейс.
    /// Компоненты не должны взаимодействовать друг с другом напрямую.
    /// </summary>
    public abstract class Device
    {
        private readonly IMediator _mediator;

        public Device(IMediator mediator)
        {
            _mediator = mediator;
        }

        public virtual void Send(string command)
        {
            _mediator.Send(command, this);
        }

        public abstract void Notify(string command);
    }
}
namespace DesignPatternDemos.Mediator
{
    /// <summary>
    /// Конкретный посредник содержит код взаимодействия нескольких компонентов между собой.
    /// </summary>
    public class CentralUnitMediator : IMediator
    {
        public Device AlarmDevice { get; set; }
        
        public CoffeeMachineDevice CoffeeMachineDevice { get; set; }
        
        public GrillDevice GrillDevice { get; set; }
        
        public void Send(string command, Device device)
        {
            // Если отправитель - будильник, то отправляем команду на приготовление кофе
            if (AlarmDevice == device)
            {
                CoffeeMachineDevice.Notify(command);
            }
            // Если отправитель - кофемашина, то отправляем команду на поджарку тостов
            else if (CoffeeMachineDevice == device)
            {
                GrillDevice.Notify(command);
            }
            // Если отправитель - грильница, то отправляем оповещение о том, что все действия выполнены
            else if (GrillDevice == device)
            {
                AlarmDevice.Notify(command);
            }
        }
    }
}
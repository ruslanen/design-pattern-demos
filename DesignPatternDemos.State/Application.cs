namespace DesignPatternDemos.State
{
    /// <summary>
    /// Экземпляр запущенного приложения. Имитирует использование паттерна "Состояние".
    /// Для реализации паттерна в реальном примере следует:
    /// 1. Собрать все доступные состояния
    /// 2. Создать экземпляр для хранения текущего состояния
    /// 3. Собрать все действия, которые могут выполняться системой
    /// 4. Создать класс, который моделирует конечный автомат.
    /// </summary>
    public class Application
    {
        private IApplicationState _currentState;

        public IApplicationState InitializeState => new InitializeState(this);
        
        public IApplicationState StartState => new StartState(this);
        
        public IApplicationState MigrateState => new MigrateState(this);
        
        public IApplicationState StopState => new StopState(this);

        public Application()
        {
            _currentState = InitializeState;
        }
        
        public void SetState(IApplicationState state)
        {
            _currentState = state;
        }

        public void Initialize()
        {
            _currentState.Initialize();
        }
        
        public void Start()
        {
            _currentState.Start();
        }

        public void Migrate()
        {
            _currentState.Migrate();
        }

        public void Stop()
        {
            _currentState.Stop();
        }
    }
}
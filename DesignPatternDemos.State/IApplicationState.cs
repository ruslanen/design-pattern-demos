namespace DesignPatternDemos.State
{
    /// <summary>
    /// Контракт для реализации состояний приложения
    /// </summary>
    public interface IApplicationState
    {
        /// <summary>
        /// Инициализировать приложение (приложение не готово к работе с пользователями)
        /// </summary>
        void Initialize();

        /// <summary>
        /// Провести миграции в приложении (приложение не готово к работе с пользователями)
        /// </summary>
        void Migrate();

        /// <summary>
        /// Запустить приложение (приложение может принимать запросы пользователей)
        /// </summary>
        void Start();
        
        /// <summary>
        /// Остановить приложение (освободить ресурсы и завершиться)
        /// </summary>
        void Stop();
    }
}
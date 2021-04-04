namespace DesignPatternDemos.Adapter
{
    /// <summary>
    /// Контракт для TCP-сервисов
    /// </summary>
    public interface ITcpService
    {
        /// <summary>
        /// Получить результат работы сервиса
        /// </summary>
        string GetResultFromTcp();
    }
}
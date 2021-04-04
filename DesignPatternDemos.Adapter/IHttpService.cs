namespace DesignPatternDemos.Adapter
{
    /// <summary>
    /// Контракт для HTTP-сервисов
    /// </summary>
    public interface IHttpService
    {
        /// <summary>
        /// Получить результат работы сервиса
        /// </summary>
        string GetResultFromHttp();
    }
}
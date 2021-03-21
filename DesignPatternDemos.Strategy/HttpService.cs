namespace DesignPatternDemos.Strategy
{
    /// <summary>
    /// Некий HTTP-сервис, осуществляющий отправку запросов на сторонний сервис.
    /// </summary>
    public class HttpService : IHttpService
    {
        private readonly ILoggingStrategy _loggingStrategy;
        
        public HttpService(ILoggingStrategy loggingStrategy)
        {
            _loggingStrategy = loggingStrategy;
        }
        
        public bool SendData()
        {
            // Некоторая логика по отправке HTTP-запроса
            _loggingStrategy.Log("Data has been sent");
            return true;
        }
    }
}
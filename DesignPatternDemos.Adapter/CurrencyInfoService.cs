namespace DesignPatternDemos.Adapter
{
    /// <summary>
    /// Сервис для получения информации о курсе валют
    /// </summary>
    public class CurrencyInfoService : IHttpService
    {
        public string GetResultFromHttp()
        {
            // Логика получения информации о курсе валют
            return string.Empty;
        }
    }
}
namespace DesignPatternDemos.Adapter
{
    /// <summary>
    /// Сервис получения информации о погоде
    /// </summary>
    public class WeatherInfoService : IHttpService
    {
        public string GetResultFromHttp()
        {
            // Логика получения информации о погоде
            return string.Empty;
        }
    }
}
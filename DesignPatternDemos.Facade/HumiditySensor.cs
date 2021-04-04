namespace DesignPatternDemos.Facade
{
    /// <summary>
    /// Датчик влажности
    /// </summary>
    public class HumiditySensor : ISensor
    {
        public string GetResult()
        {
            // Логика получения результата с датчика
            return string.Empty;
        }
    }
}
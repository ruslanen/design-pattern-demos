namespace DesignPatternDemos.Facade
{
    /// <summary>
    /// Датчик температуры
    /// </summary>
    public class TemperatureSensor : ISensor
    {
        public string GetResult()
        {
            // Логика получения результата с датчика
            return string.Empty;
        }
    }
}
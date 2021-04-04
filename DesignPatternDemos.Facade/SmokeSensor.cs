namespace DesignPatternDemos.Facade
{
    /// <summary>
    /// Датчик дыма
    /// </summary>
    public class SmokeSensor : ISensor
    {
        public string GetResult()
        {
            // Логика получения результата с датчика
            return string.Empty;
        }
    }
}
namespace DesignPatternDemos.Facade
{
    /// <summary>
    /// Датчик звука
    /// </summary>
    public class SoundActivitySensor : ISensor
    {
        public string GetResult()
        {
            // Логика получения результата с датчика
            return string.Empty;
        }
    }
}
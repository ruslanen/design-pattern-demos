namespace DesignPatternDemos.Facade
{
    /// <summary>
    /// Датчик движения
    /// </summary>
    public class MotionActivitySensor : ISensor
    {
        public string GetResult()
        {
            // Логика получения результата с датчика
            return string.Empty;
        }
    }
}
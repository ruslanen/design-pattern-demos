using System.Collections.Generic;

namespace DesignPatternDemos.Facade
{
    /// <summary>
    /// Пример применения паттерна "Фасад"
    /// Напоминает паттерн "Адаптер". Разница в том, что "Фасад" применяется для упрощения,
    /// а адаптер для преобразования интерфейса к другой форме.
    /// Также "Фасад" обеспечивает логическую изолацию клиента от подсистемы, состоящей из нескольких компонентов.
    /// </summary>
    public class SensorResultsFacade
    {
        private readonly TemperatureSensor _temperatureSensor;
        private readonly HumiditySensor _humiditySensor;
        private readonly MotionActivitySensor _motionActivitySensor;
        private readonly SoundActivitySensor _soundActivitySensor;
        private readonly SmokeSensor _smokeSensor;
        
        public SensorResultsFacade(
            TemperatureSensor temperatureSensor,
            HumiditySensor humiditySensor,
            MotionActivitySensor motionActivitySensor,
            SoundActivitySensor soundActivitySensor,
            SmokeSensor smokeSensor)
        {
            _temperatureSensor = temperatureSensor;
            _humiditySensor = humiditySensor;
            _motionActivitySensor = motionActivitySensor;
            _soundActivitySensor = soundActivitySensor;
            _smokeSensor = smokeSensor;
        }

        public List<string> GetResults()
        {
            var results = new List<string>();
            results.Add(_temperatureSensor.GetResult());
            results.Add(_humiditySensor.GetResult());
            results.Add(_motionActivitySensor.GetResult());
            results.Add(_soundActivitySensor.GetResult());
            results.Add(_smokeSensor.GetResult());
            return results;
        }
    }
}
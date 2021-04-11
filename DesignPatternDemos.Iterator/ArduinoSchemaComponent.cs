using System;
using System.Collections.Generic;

namespace DesignPatternDemos.Iterator
{
    /// <summary>
    /// Реализация, имитирующая микроконтроллер Arduino, к которому можно подсоединять различные датчики
    /// </summary>
    public class ArduinoSchemaComponent : IComponent
    {
        private readonly List<SensorComponent> _sensors;

        public ArduinoSchemaComponent()
        {
            _sensors = new List<SensorComponent>();
            AddComponent("Датчик движения", DateTime.Now, 20);
            AddComponent("Датчик звука", DateTime.Now, 25);
            AddComponent("Датчик дыма", DateTime.Now, 10);
        }

        public void AddComponent(string name, DateTime startDate, double consumption)
        {
            var component = new SensorComponent(name, startDate, consumption);
            _sensors.Add(component);
        }
        
        public IIterator CreateIterator()
        {
            return new ArduinoSchemaComponentIterator(_sensors);
        }
    }
}
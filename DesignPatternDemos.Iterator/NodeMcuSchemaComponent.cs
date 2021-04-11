using System;

namespace DesignPatternDemos.Iterator
{
    /// <summary>
    /// Реализация, имитирующая микроконтроллер NodeMCU, к которому можно подсоединять различные датчики
    /// </summary>
    public class NodeMcuSchemaComponent : IComponent
    {
        private const int MaxItems = 3;
        private readonly SensorComponent[] _sensors;
        private int _currentItem = 0;
        
        public NodeMcuSchemaComponent()
        {
            _sensors = new SensorComponent[MaxItems];
            AddComponent("Датчик температуры", DateTime.Now, 15);
            AddComponent("Датчик влажности", DateTime.Now, 20);
            AddComponent("Датчик света", DateTime.Now, 10);
        }

        public void AddComponent(string name, DateTime startDate, double consumption)
        {
            if (_currentItem >= MaxItems)
            {
                Console.WriteLine("Components size is full.");
            }
            else
            {
                var component = new SensorComponent(name, startDate, consumption);
                _sensors[_currentItem] = component;
                _currentItem++;
            }
        }

        public IIterator CreateIterator()
        {
            return new NodeMcuSchemaComponentIterator(_sensors);
        }
    }
}
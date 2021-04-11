using System.Collections.Generic;

namespace DesignPatternDemos.Iterator
{
    public class ArduinoSchemaComponentIterator : IIterator
    {
        private List<SensorComponent> _sensorComponents;
        private int _position = 0;

        public ArduinoSchemaComponentIterator(List<SensorComponent> sensorComponents)
        {
            _sensorComponents = sensorComponents;
        }
        
        ///<inheritdoc/>
        public bool HasNext()
        {
            return _sensorComponents.Count > _position && _sensorComponents[_position] != null;
        }

        ///<inheritdoc/>
        public object Next()
        {
            return _sensorComponents[_position++];
        }
    }
}
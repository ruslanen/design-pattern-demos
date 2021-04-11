namespace DesignPatternDemos.Iterator
{
    public class NodeMcuSchemaComponentIterator : IIterator
    {
        private readonly SensorComponent[] _sensorComponents;
        private int _position = 0;

        public NodeMcuSchemaComponentIterator(SensorComponent[] sensorComponents)
        {
            _sensorComponents = sensorComponents;
        }
        
        ///<inheritdoc/>
        public bool HasNext()
        {
            return _sensorComponents.Length > _position && _sensorComponents[_position] != null;
        }

        ///<inheritdoc/>
        public object Next()
        {
            return _sensorComponents[_position++];
        }
    }
}
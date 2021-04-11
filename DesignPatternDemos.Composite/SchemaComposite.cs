using System.Collections.Generic;
using System.Linq;

namespace DesignPatternDemos.Composite
{
    /// <summary>
    /// Элемент, содержащий дочерние элементы
    /// </summary>
    public class SchemaComposite : SchemaComponent
    {
        private readonly string _name;

        protected List<SchemaComponent> _schemaComponents = new List<SchemaComponent>();

        public override string Name => _name;

        public SchemaComposite(string name)
        {
            _name = name;
        }

        public override void Add(SchemaComponent schemaComponent)
        {
            _schemaComponents.Add(schemaComponent);
        }

        public override void Remove(SchemaComponent schemaComponent)
        {
            _schemaComponents.Remove(schemaComponent);
        }

        public override SchemaComponent GetChild(int index)
        {
            return _schemaComponents.ElementAt(index);
        }
    }
}
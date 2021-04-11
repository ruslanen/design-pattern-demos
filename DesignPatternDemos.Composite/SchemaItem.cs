using System;

namespace DesignPatternDemos.Composite
{
    /// <summary>
    /// Листовой элемент
    /// </summary>
    public class SchemaItem : SchemaComponent
    {
        private readonly string _name;
        private readonly DateTime _startDate;
        private readonly double _consumption;
        
        public override string Name => _name;
        public override DateTime StartDate => _startDate;
        public override double Consumption => _consumption;

        public SchemaItem(string name, DateTime startDate, double consumption)
        {
            _name = name;
            _startDate = startDate;
            _consumption = consumption;
        }
    }
}
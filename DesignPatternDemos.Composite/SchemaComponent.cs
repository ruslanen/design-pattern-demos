using System;

namespace DesignPatternDemos.Composite
{
    /// <summary>
    /// Основа паттерна "Композит". Представляет из себя общий интерфейс для элементов дерева (листов и композитов).
    /// При этом, некоторые члены могут быть не определены в классах-реализациях (например, в композитах не будут
    /// определены StartDate и Consumption, при обращении к ним будет выброшено исключение - это следует учитывать при
    /// написании клиентского кода и, возможно, искать баланс между прозрачностью и безопасностью).
    /// Паттерн позволяет клиенту выполнять однородные операции с композитами и листами.
    /// </summary>
    public abstract class SchemaComponent
    {
        public virtual string Name => throw new NotImplementedException();
        
        public virtual DateTime StartDate => throw new NotImplementedException();

        public virtual double Consumption => throw new NotImplementedException();
        
        public virtual void Add(SchemaComponent schemaComponent)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(SchemaComponent schemaComponent)
        {
            throw new NotImplementedException();
        }

        public virtual SchemaComponent GetChild(int index)
        {
            throw new NotImplementedException();
        }
    }
}
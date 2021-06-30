namespace DesignPatternDemos.Visitor
{
    /// <summary>
    /// Интерфейс посетителя должен сожержать методы для каждого посещаемого элемента.
    /// Важно, чтобы иерархия элементов менялась редко, т.к. при добавлении нового придется
    /// менять всех существующих посетителей. В наборе методов отличаются типы параметров
    /// (они соответсвтуют посещаемому элементу).
    /// Может быть множество различных реализаций посетителя.
    /// </summary>
    public interface IVisitor
    {
        void VisitSimpleCell(SimpleCell simpleCell);

        void VisitCalculatedCell(CalculatedCell calculatedCell);
    }
}
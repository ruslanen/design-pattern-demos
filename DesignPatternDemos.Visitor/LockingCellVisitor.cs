namespace DesignPatternDemos.Visitor
{
    /// <summary>
    /// Реализиция посетителя
    /// </summary>
    public class LockingCellVisitor : IVisitor
    {
        public void VisitSimpleCell(SimpleCell simpleCell)
        {
            // Добавление стиля заблокированной ячейке к обычной ячейке
        }

        public void VisitCalculatedCell(CalculatedCell calculatedCell)
        {
            // Добавление стиля заблокированной ячейке к вычисляемой ячейке
        }
    }
}
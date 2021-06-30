namespace DesignPatternDemos.Visitor
{
    public class CalculatedCell : ICell
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitCalculatedCell(this);
        }
    }
}
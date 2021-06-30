namespace DesignPatternDemos.Visitor
{
    public class SimpleCell : ICell
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitSimpleCell(this);
        }
    }
}
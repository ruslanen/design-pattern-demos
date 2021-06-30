namespace DesignPatternDemos.Visitor
{
    /// <summary>
    /// Элемент который необходимо посетить
    /// </summary>
    public interface ICell
    {
        /// <summary>
        /// Принять посетителя
        /// </summary>
        void Accept(IVisitor visitor);
    }
}
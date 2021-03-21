namespace DesignPatternDemos.Decorator
{
    /// <summary>
    /// Контракт отчета
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// Применить стили к экспортируемому отчету
        /// </summary>
        void ApplyStyles();
    }
}
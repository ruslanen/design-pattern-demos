namespace DesignPatternDemos.Decorator
{
    /// <summary>
    /// Абстрактный класс отчета (собственно, сам декоратор)
    /// </summary>
    public abstract class ReportDecorator : IReport
    {
        /// <summary>
        /// Декорируемый объект отчета
        /// </summary>
        protected IReport DecoratedReport;

        public ReportDecorator(IReport report)
        {
            DecoratedReport = report;
        }

        ///<inheritdoc/>
        public abstract void ApplyStyles();
    }
}
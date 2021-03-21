using System;

namespace DesignPatternDemos.Decorator
{
    /// <summary>
    /// Отчет по закупкам
    /// </summary>
    public class PurchaseReport : ReportDecorator
    {
        public PurchaseReport(IReport report) : base(report)
        {
        }

        public override void ApplyStyles()
        {
            // ...
            // Общая логика применения стилей к отчету по закупкам
            // ...
            Console.WriteLine($"{nameof(PurchaseReport)} common logic");
            
            // Конкретная логика в декорирумых классах
            DecoratedReport.ApplyStyles();
        }
    }
}
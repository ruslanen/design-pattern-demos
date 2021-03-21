using System;
using System.Resources;

namespace DesignPatternDemos.Decorator
{
    /// <summary>
    /// Финансовый отчет
    /// </summary>
    public class FinancialReport : ReportDecorator
    {
        public FinancialReport(IReport report) : base(report)
        {
        }
        
        public override void ApplyStyles()
        {
            // ...
            // Общая логика применения стилей к финансовому отчету
            // ...
            Console.WriteLine($"{nameof(FinancialReport)} common logic");
            
            // Конкретная логика в декорирумых классах
            DecoratedReport.ApplyStyles();
        }
    }
}
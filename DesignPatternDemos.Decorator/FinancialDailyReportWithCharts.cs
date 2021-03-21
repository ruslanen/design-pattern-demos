using System;

namespace DesignPatternDemos.Decorator
{
    /// <summary>
    /// Расширенная функциональность финансового отчета
    /// </summary>
    public class FinancialDailyReportWithCharts : IReport
    {
        public void ApplyStyles()
        {
            ApplyChartStyles();
        }

        /// <summary>
        /// Применить специфичные стили для ежедневого отчета с диаграммами
        /// </summary>
        private void ApplyChartStyles()
        {
            // Логика по применению стилей
            Console.WriteLine($"{nameof(FinancialDailyReportWithCharts)} logic");
        }
    }
}
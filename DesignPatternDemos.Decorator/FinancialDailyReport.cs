using System;

namespace DesignPatternDemos.Decorator
{
    /// <summary>
    /// Расширенная функциональность финансового отчета
    /// </summary>
    public class FinancialDailyReport : IReport
    {
        public void ApplyStyles()
        {
            ApplyCustomStyles();
        }
        
        /// <summary>
        /// Применить кастомные стили для отчета
        /// </summary>
        private void ApplyCustomStyles()
        {
            // Применение кастомных стилей, характерных для ежедневного отчета.
            // Например, границы таблиц, шрифт, жирные заголовки.
            Console.WriteLine($"{nameof(FinancialDailyReport)} logic");
        }
    }
}
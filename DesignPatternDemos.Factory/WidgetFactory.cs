using System;

namespace DesignPatternDemos.Factory
{
    /// <summary>
    /// Класс для создания экземпляров виджетов
    /// Полноценным паттерном не является
    /// </summary>
    public class WidgetFactory
    {
        public BaseWidget CreateWidget(string type)
        {
            switch (type)
            {
                case "pie":
                    return new PieChart();
                case "line":
                    return new LineChart();
                default:
                    throw new ArgumentException("Unreachable code");
            }
        }
    }
}
using System;

namespace DesignPatternDemos.Iterator
{
    /// <summary>
    /// Компонент, подключаемый к микроконтроллеру (датчик)
    /// </summary>
    public class SensorComponent
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Дата включения
        /// </summary>
        public DateTime StartDate { get; set; }
        
        /// <summary>
        /// Энергопотребление (в мАч)
        /// </summary>
        public double Consumption { get; set; }

        public SensorComponent(string name, DateTime startDate, double consumption)
        {
            Name = name;
            StartDate = startDate;
            Consumption = consumption;
        }
    }
}
using System.Collections.Generic;
using DesignPatternDemos.Observer.Models;
using DesignPatternDemos.Observer.Observers;

namespace DesignPatternDemos.Observer.Subjects
{
    /// <summary>
    /// Наблюдаемый субъект показаний датчиков климата
    /// (например, DHT-11 или DHT-22)
    /// </summary>
    public class ClimateObservable : ISensorObservable
    {
        private readonly IList<ISensorObserver> _sensorObservers = new List<ISensorObserver>();
        private ClimateInfo _climateInfo;

        ///<inheritdoc/>
        public void RegisterObserver(ISensorObserver observer)
        {
            _sensorObservers.Add(observer);
        }

        ///<inheritdoc/>
        public void RemoveObserver(ISensorObserver observer)
        {
            _sensorObservers.Remove(observer);
        }

        ///<inheritdoc/>
        public void NotifyObservers()
        {
            foreach (var observer in _sensorObservers)
            {
                observer.UpdateInfo(_climateInfo);
            }
        }

        /// <summary>
        /// Сообщить об изменении данных
        /// </summary>
        public void DataChanged()
        {
            NotifyObservers();
        }

        /// <summary>
        /// Установить обновленное значение датчиков
        /// </summary>
        /// <param name="climateInfo">Информация о климате</param>
        public void SetSensorsData(ClimateInfo climateInfo)
        {
            _climateInfo = climateInfo;
            DataChanged();
        }
    }
}
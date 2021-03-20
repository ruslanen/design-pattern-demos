using System.Collections.Generic;
using DesignPatternDemos.Observer.Models;
using DesignPatternDemos.Observer.Observers;

namespace DesignPatternDemos.Observer.Subjects
{
    /// <summary>
    /// Наблюдаемый субъект показаний датчиков движений
    /// (например, HC-SR501)
    /// </summary>
    public class ActivityObservable : ISensorObservable
    {
        private readonly IList<ISensorObserver> _sensorObservers = new List<ISensorObserver>();
        private ActivityInfo _activityInfo;

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
                observer.UpdateInfo(_activityInfo);
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
        /// <param name="activityInfo">Информация об активности</param>
        public void SetSensorsData(ActivityInfo activityInfo)
        {
            _activityInfo = activityInfo;
            DataChanged();
        }
    }
}
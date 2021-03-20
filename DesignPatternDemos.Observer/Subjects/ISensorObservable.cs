using DesignPatternDemos.Observer.Observers;

namespace DesignPatternDemos.Observer.Subjects
{
    /// <summary>
    /// Наблюдаемый субъект
    /// </summary>
    public interface ISensorObservable
    {
        /// <summary>
        /// Зарегистрировать наблюдателя
        /// </summary>
        /// <param name="observer">Наблюдатель</param>
        void RegisterObserver(ISensorObserver observer);

        /// <summary>
        /// Удалить наблюдателя
        /// </summary>
        /// <param name="observer">Наблюдатель</param>
        void RemoveObserver(ISensorObserver observer);

        /// <summary>
        /// Уведомить наблюдателей
        /// </summary>
        void NotifyObservers();
    }
}
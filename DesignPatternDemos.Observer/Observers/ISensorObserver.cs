namespace DesignPatternDemos.Observer.Observers
{
    /// <summary>
    /// Контракт наблюдателя за показаниями датчиков
    /// </summary>
    public interface ISensorObserver
    {
        /// <summary>
        /// Метод, вызываемый наблюдаемым субъектом для уведомления наблюдателя
        /// </summary>
        /// <remarks>
        /// Тип параметра data объявлен как object во избежание сильной связанности
        /// TODO: Передавать аргументом object является не очень хорошим тоном, но кодовая база удовлетворяет паттерну "Наблюдатель",
        /// поэтому оставлено как есть. Можно улучшить используя другой способ
        /// </remarks>
        /// <param name="data">Данные датчиков</param>
        void UpdateInfo(object data);
    }
}
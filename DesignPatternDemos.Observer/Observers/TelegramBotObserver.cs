using System;
using DesignPatternDemos.Observer.Subjects;

namespace DesignPatternDemos.Observer.Observers
{
    /// <summary>
    /// Наблюдатель за показаниями различных датчиков
    /// Отправляет данные Telegram-боту
    /// </summary>
    public class TelegramBotObserver : ISensorObserver
    {
        public TelegramBotObserver(ISensorObservable sensorObservable)
        {
            sensorObservable.RegisterObserver(this);
        }
        
        /// <summary>
        /// Обновить информацию по показанию датчика и отправить ее Telegram-боту
        /// </summary>
        /// <param name="sensorData"></param>
        public void UpdateInfo(object sensorData)
        {
            // Логика, делегирующая отправку данных показаний датчиков в отдельном модуле
            Console.WriteLine("Sensor data has been sent");
        }
    }
}
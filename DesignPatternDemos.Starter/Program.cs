using System;
using DesignPatternDemos.Observer.Models;
using DesignPatternDemos.Observer.Observers;
using DesignPatternDemos.Observer.Subjects;

namespace DesignPatternDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            var designPatternDemos = new DesignPatternDemos();
            designPatternDemos.DemoObserver();
        }
    }

    class DesignPatternDemos
    {
        /// <summary>
        /// Демо паттерна "Наблюдатель"
        /// </summary>
        public void DemoObserver()
        {
            // Создание субъектов (наблюдаемых объектов)
            var climateObservable = new ClimateObservable();
            var activityObservable = new ActivityObservable();
            
            // Создание наблюдателей
            var consoleWriterClimateObserver = new ConsoleWriterObserver(climateObservable);
            var consoleWriterActivityObserver = new ConsoleWriterObserver(activityObservable);
            var telegramBotClimateObserver = new TelegramBotObserver(climateObservable);
            var telegramBotActivityObserver = new TelegramBotObserver(activityObservable);
            
            // Имитация установки значений наблюдаемым объектам
            // (как будто данные пришли по HTTP с ESP8266)
            climateObservable.SetSensorsData(new ClimateInfo
            {
                Temperature = 24,
                Humidity = 40,
            });
            activityObservable.SetSensorsData(new ActivityInfo
            {
                LastActivity = DateTime.Now,
            });
        }
    }
}
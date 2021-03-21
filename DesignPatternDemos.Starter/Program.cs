using System;
using DesignPatternDemos.Decorator;
using DesignPatternDemos.Observer.Models;
using DesignPatternDemos.Observer.Observers;
using DesignPatternDemos.Observer.Subjects;
using DesignPatternDemos.Strategy;

namespace DesignPatternDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            var designPatternDemos = new DesignPatternDemos();
            designPatternDemos.DemoStrategy();
            designPatternDemos.DemoObserver();
            designPatternDemos.DemoDecorator();
        }
    }

    class DesignPatternDemos
    {
        /// <summary>
        /// Демо паттерна "Наблюдатель".
        /// Паттерн Наблюдатель определяет отношение «один-ко-многим» между объектами таким образом,
        /// что при изменении состояния одного объекта происходит автоматическое оповещение и обновление всех зависимых объектов.
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
        
        /// <summary>
        /// Демо паттерна "Декоратор".
        /// Паттерн Декоратор динамически наделяет объект новыми возможностями и является гибкой
        /// альтернативой субклассированию в области расширения функциональности.
        /// </summary>
        public void DemoDecorator()
        {
            // Здесь происходит расширение класса FinancialReport дополнительной функциональностью в виде FinancialDailyReport 
            var dailyReport = new FinancialReport(new FinancialDailyReport());
            dailyReport.ApplyStyles();
            // Здесь происходит расширение класса FinancialReport дополнительной функциональностью в виде FinancialDailyReportWithCharts 
            var dailyReportWithCharts = new FinancialReport(new FinancialDailyReportWithCharts());
            dailyReportWithCharts.ApplyStyles();

            // Здесь происходит декорирование объекта FinancialDailyReport функциональностью из FinancialReport и PurchaseReport
            IReport newDailyReport = new FinancialDailyReport();
            newDailyReport = new FinancialReport(newDailyReport);
            newDailyReport = new PurchaseReport(newDailyReport);
            newDailyReport.ApplyStyles();
        }
        
        /// <summary>
        /// Демо паттерна "Стратегия".
        /// Паттерн Стратегия определяет семейство алгоритмов, инкапсулирует каждый из них и обеспечивает их взаимозаменяемость.
        /// Он позволяет модифицировать алгоритмы независимо от их использования на стороне клиента.
        /// </summary>
        public void DemoStrategy()
        {
            var consoleLoggingStrategy = new ConsoleLoggingStrategy();
            var fileLoggingStrategy = new FileLoggingStrategy();
            // Смысл применения паттерна заключается в том, что поведение логирования изолируется в отдельный класс для того,
            // чтобы например другие сервисы могли использовать другой вариант логирования
            var httpService1 = new HttpService(consoleLoggingStrategy);
            var httpService2 = new HttpService(fileLoggingStrategy);
            httpService1.SendData();
            httpService2.SendData();
        }
        
        /// <summary>
        /// Демо паттерна "Одиночка"
        /// </summary>
        public void DemoSingleton()
        {
        }
    }
}
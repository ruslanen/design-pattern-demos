using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;
using DesignPatternDemos.Adapter;
using DesignPatternDemos.Command;
using DesignPatternDemos.Decorator;
using DesignPatternDemos.Facade;
using DesignPatternDemos.Factory;
using DesignPatternDemos.FactoryMethod;
using DesignPatternDemos.Observer.Models;
using DesignPatternDemos.Observer.Observers;
using DesignPatternDemos.Observer.Subjects;
using DesignPatternDemos.Singleton;
using DesignPatternDemos.Strategy;

namespace DesignPatternDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            var designPatternDemos = new DesignPatternDemonstration();
            designPatternDemos.DemoStrategy();
            designPatternDemos.DemoObserver();
            designPatternDemos.DemoDecorator();
            designPatternDemos.DemoSingleton();
            designPatternDemos.DemoFactory();
            designPatternDemos.DemoCommand();
            designPatternDemos.DemoAdapter();
            designPatternDemos.DemoFacade();
        }
    }

    class DesignPatternDemonstration
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
        /// Демо паттерна "Одиночка".
        /// Паттерн "Одиночка" гарантирует, что класс имеет только один экземпляр, и предоставляет глобальную точку доступа к этому экземпляру.
        /// </summary>
        public void DemoSingleton()
        {
            var demoXDocument = XDocument.Parse(
                File.ReadAllText("../../../../DesignPatternDemos.Singleton/demo.xml"),
                LoadOptions.PreserveWhitespace | LoadOptions.SetLineInfo);
            var errors = new List<string>();
            demoXDocument.Validate(DemoXmlSerializationWrap.SchemaSet, (sender, validationEventArgs) =>
            {
                errors.Add($"строка {validationEventArgs.Exception.LineNumber}, символ {validationEventArgs.Exception.LinePosition}: ошибка валидации: {validationEventArgs.Message}");
            });

            if (errors.Count > 0)
            {
                Console.WriteLine(string.Join('\n', errors));
            }
            else
            {
                var country = (Country)DemoXmlSerializationWrap.Serializer.Deserialize(demoXDocument.CreateReader());
                Console.WriteLine(country.CountryName);
                Console.WriteLine(country.Population);
            }
        }
        
        /// <summary>
        /// Демо паттернов "Фабрика" (не является полноценным паттерном), "Фабричный метод" и "Абстрактная фабрика".
        /// </summary>
        public void DemoFactory()
        {
            // "Фабрика" (не является полноценным паттерном)
            var dashboard = new Dashboard(new WidgetFactory());
            dashboard.AddWidget("pie");

            // Фабричный метод
            // Паттерн «Фабричный метод» отвечает за создание объектов и инкапсулирует эту операцию в субклассе.
            // Таким образом клиетский код в базовом класссе отделяется от кода создания объекта в классе-наследнике.
            var gamingStore = new GamingComputerStore();
            gamingStore.OrderComputer("budget");

            var officeStore = new OfficeComputerStore();
            officeStore.OrderComputer("top");

            // Абстрактная фабрика
            // Паттерн «Абстрактная фабрика» представляет интерфейс создания семейств взаимосвязанных или взаимозависимых объектов без указания их конкретных классов.
            // На основе абстрактной фабрики создаются одни или более конкретных фабрик, производящих одинаковые объекты, но с разными реализациями.
            // Это означает, что абстрактная фабрика определяет интерфейс для создания семейства объектов.
            var gamingStore1 = new AbstractFactory.GamingComputerStore();
            gamingStore1.OrderComputer("budget");
            var officeStore1 = new AbstractFactory.OfficeComputerStore();
            officeStore1.OrderComputer("top");
        }

        /// <summary>
        /// Паттерн "Команда" инкапсулирует запрос в виде объекта, делая возможной параметризацию клиентских объектов с другими запросами,
        /// организацию очереди или регистрацию запросов, а также поддержку отмены операций.
        /// </summary>
        public void DemoCommand()
        {
            var commandDispatcher = new CommandDispatcher();
            var pageInfoService = new PageInfoService();
            commandDispatcher.SetCommand(0, new HelpCommand());
            commandDispatcher.SetCommand(1, new PageSizeCommand(pageInfoService));
            commandDispatcher.SetCommand(2, new PageHtmlCommand(pageInfoService));
            
            // TODO: Отдельный класс для определения типа команды по аргументам
            commandDispatcher.OnCommandExecute(1, new []{ "https://github.com" });
            commandDispatcher.OnCommandExecute(2, new []{ "https://github.com" });
        }

        /// <summary>
        /// Паттерн "Адаптер" преобразует интерфейс класса к другому интерфейсу, на который рассчитан клиент.
        /// Адаптер обеспечивает совместную работу классов, невозможную в обычных условиях из-за несовместимости интерфейсов.
        /// </summary>
        public void DemoAdapter()
        {
            // Эта строка необходима для загрузки сборки DesignPatternDemos.Adapter в домен
            var loadAssembly = new PopulationInfoTcpService();

            // Будем считать, что код ниже имитирует получение зарегистрированных имплементаций через DI-контейнер
            var services = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(x => x.GetName().Name == "DesignPatternDemos.Adapter")?
                .GetTypes()
                .Where(x => typeof(DesignPatternDemos.Adapter.IHttpService).IsAssignableFrom(x) && !x.IsInterface);

            var results = new List<string>();
            // Инициализация сервисов и получения результата их работы
            foreach (var service in services)
            {
                Adapter.IHttpService serviceInstance;
                // Этот сервис требует зависимости, поэтому экземпляр для него создается через параметризованный конструктор
                if (service == typeof(PopulationInfoTcpServiceAdapter))
                {
                    serviceInstance = (Adapter.IHttpService) Activator.CreateInstance(service, new PopulationInfoTcpService());
                }
                else
                {
                    serviceInstance = (Adapter.IHttpService)Activator.CreateInstance(service);
                }
                
                results.Add(serviceInstance.GetResultFromHttp());
            }
        }

        /// <summary>
        /// Паттерн "Фасад" предоставляет унифицированный интерфейс к группе интерфейсов подсистемы.
        /// "Фасад" определяет высокоуровневый интерфейс, упрощающей работу с подсистемой.
        /// </summary>
        public void DemoFacade()
        {
            // Как правило, клиентский код не создает зависимости для фасада, но учитывая, что это демонстрационный пример,
            // код представлен в упрощенном виде
            var sensorResultsFacade = new SensorResultsFacade(
                new TemperatureSensor(),
                new HumiditySensor(),
                new MotionActivitySensor(),
                new SoundActivitySensor(),
                new SmokeSensor());
            sensorResultsFacade.GetResults();
        }
    }
}
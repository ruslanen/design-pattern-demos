using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;
using DesignPatternDemos.Adapter;
using DesignPatternDemos.Bridge;
using DesignPatternDemos.Builder;
using DesignPatternDemos.ChainOfResponsibility;
using DesignPatternDemos.Command;
using DesignPatternDemos.Composite;
using DesignPatternDemos.Decorator;
using DesignPatternDemos.Facade;
using DesignPatternDemos.Factory;
using DesignPatternDemos.FactoryMethod;
using DesignPatternDemos.Flyweight;
using DesignPatternDemos.Interpreter;
using DesignPatternDemos.Iterator;
using DesignPatternDemos.Mediator;
using DesignPatternDemos.Memento;
using DesignPatternDemos.Observer.Models;
using DesignPatternDemos.Observer.Observers;
using DesignPatternDemos.Observer.Subjects;
using DesignPatternDemos.Prototype;
using DesignPatternDemos.Proxy;
using DesignPatternDemos.Singleton;
using DesignPatternDemos.State;
using DesignPatternDemos.Strategy;
using DesignPatternDemos.TemplateMethod;
using DesignPatternDemos.Visitor;

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
            designPatternDemos.DemoTemplateMethod();
            designPatternDemos.DemoIterator();
            designPatternDemos.DemoComposite();
            designPatternDemos.DemoState();
            designPatternDemos.DemoProxy();
            designPatternDemos.DemoBridge();
            designPatternDemos.DemoBuilder();
            designPatternDemos.DemoChainOfResponsibility();
            designPatternDemos.DemoFlyweight();
            designPatternDemos.DemoInterpreter();
            designPatternDemos.DemoMediator();
            designPatternDemos.DemoMemento();
            designPatternDemos.DemoPrototype();
            designPatternDemos.DemoVisitor();
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
            demoXDocument.Validate(DemoXmlSerializationWrap.SchemaSet,
                (sender, validationEventArgs) =>
                {
                    errors.Add(
                        $"строка {validationEventArgs.Exception.LineNumber}, символ {validationEventArgs.Exception.LinePosition}: ошибка валидации: {validationEventArgs.Message}");
                });

            if (errors.Count > 0)
            {
                Console.WriteLine(string.Join('\n', errors));
            }
            else
            {
                var country = (Country) DemoXmlSerializationWrap.Serializer.Deserialize(demoXDocument.CreateReader());
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
            commandDispatcher.OnCommandExecute(1, new[] {"https://github.com"});
            commandDispatcher.OnCommandExecute(2, new[] {"https://github.com"});
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
                    serviceInstance =
                        (Adapter.IHttpService) Activator.CreateInstance(service, new PopulationInfoTcpService());
                }
                else
                {
                    serviceInstance = (Adapter.IHttpService) Activator.CreateInstance(service);
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

        /// <summary>
        /// Паттерн "Шаблонный метод" задает "скелет" алгоритма в методе, оставляя определение реализации некоторых
        /// шагов субклассам. Субклассы могут переопределять некоторые части алгоритма без изменения его структуры.
        /// Таким образом гарантируется неизменность структуры алгоритма при том, что часть реализации предоставляется субклассами.
        /// </summary>
        public void DemoTemplateMethod()
        {
            // Данный паттерн позволяет классам, реализующим алгоритм, передать выполнение некоторых шагов в субклассы
            var documentBuilder = new PdfDocumentBuilder();
            documentBuilder.Build();
        }

        /// <summary>
        /// Паттерн "Итератор" предоставляет механизм последовательного перебора элементов коллекции без раскрытия ее
        /// внутреннего представления. Кроме того, перебор элементов выполняется объектом итератора, а не самой коллекцией.
        /// Это упрощает интерфейс и реализацию коллекции, а также способствует более логичному распределению обязанностей.
        /// </summary>
        public void DemoIterator()
        {
            IComponent arduinoSchemaComponent = new ArduinoSchemaComponent();
            IComponent nodeMcuSchemaComponent = new NodeMcuSchemaComponent();

            var arduinoIterator = arduinoSchemaComponent.CreateIterator();
            var nodeMcuIterator = nodeMcuSchemaComponent.CreateIterator();

            ShowSensorInfos(arduinoIterator);
            ShowSensorInfos(nodeMcuIterator);

            void ShowSensorInfos(IIterator iterator)
            {
                while (iterator.HasNext())
                {
                    var item = (SensorComponent) iterator.Next();
                    Console.WriteLine(item.Name);
                }
            }
        }

        /// <summary>
        /// Паттерн "Компоновщик" объединяет объекты в древовидные структуры для предоставления иерархий "часть/целое".
        /// Компоновщик позволяет клиенту выполнять однородные операции с отдельными объектами и их совокупоностями.
        /// </summary>
        public void DemoComposite()
        {
            var root = new SchemaComposite("Arduino Uno");
            var child1 = new SchemaComposite("Arduino Nano");
            child1.Add(new SchemaItem("Датчик температуры", DateTime.Now, 10));
            child1.Add(new SchemaItem("Датчик влажности", DateTime.Now, 15));
            root.Add(child1);
            root.Add(new SchemaItem("Датчик звука", DateTime.Now, 20));
            // TODO: Обход по дереву
        }

        /// <summary>
        /// Паттерн "Состояние" управляет изменением поведения объекта при изменении его внутреннего состояния.
        /// Внешне это выглядит так, словно объект меняет свой класс.
        /// Паттерн внешне очень похож на паттерн "Стратегия", различия в том, что паттерн "Состояние" имеет
        /// детерменированное изменение своего состояния в зависимости от вызывающих методов (четкие переходы состояния).
        /// Эти парттерны решают разные задачи. "Стратегия" обычно определяет в классе контекста поведение алгоритма.
        /// При использовании паттерна "Состояния" клиент не должен напрямую менять состояние (только через методы).
        /// Переходами между состояниями могут управлять классы состояний и контексты (IApplicationState и Application).
        /// Использование паттерна увеличивает количество классов, но упрощает сопровождение
        /// (меньше изменений в будещем, более гибкая и расширяемая архитектура).
        /// </summary>
        public void DemoState()
        {
            var application = new Application();
            application.Initialize();
            application.Migrate();
            application.Start();
            application.Stop();
        }

        /// <summary>
        /// Паттерн "Заместитель" представляет суррогатный объект, управляющий доступом к другому объекту.
        /// Отличие "Заместителя" от "Декоратора" в том, что первый управляет доступом, а второй расширяет поведение объекта.
        ///
        /// Клиентский объект работает так, словно он вызывает методы удаленного объекта. Но в действительности он вызывает
        /// методы объекта-заместителя, существующего в локальной куче, который берет на себя все низкоуровневые подробности сетевых взаимодействий.
        /// 
        /// Виды паттерна:
        /// - удаленный заместитель (управляет взаимодействием клиента с удаленным объектом);
        /// - виртуальный заместитель (управляет доступом к объекту, создание которого сопряжено с большими затратами);
        /// - защитный заместитель (управляет доступом к методам объекта в зависимости от привилегий вызывающей стороны);
        /// - фильтрующий заместитель (управляет доступом к группам сетевых ресурсов, защищая их от "недобросовестных" клиентов);
        /// - умная ссылка (обеспечивает выполнение дополнительных действий при обращении к объекту (например изменение ссылок счетчика));
        /// - кэширующий заместитель (обеспечивает временное хранение результатов высокозатратных операций.
        /// Также может обеспечивать совместный доступ к результатам для предотвращения лишних вычислений или пересылки данных по сети);
        /// - синхронизирующий заместитель (предоставляет безопасный доступ к объекту из нескольких программных потоков);
        /// - упрощающий заместитель (скрывает сложность и управляет доступом к сложному набору классов. Иногда по очевидным соображениям называется фасадным заместителем.
        /// Упрощающий заместитель отличается от паттерна "Фасад" тем, что первый управляет доступом, а второй только предоставляет альтернативный интерфейс);
        /// - заместитель отложенного копирования (задерживает фактическое копирование объекта до момента выполнения операции с копией (разновидность виртуального заместителя)).
        /// </summary>
        public void DemoProxy()
        {
            // Пример применения паттерна "удаленный заместитель"
            IDiagnosticManager diagnosticManager = new DiagnosticManager();
            diagnosticManager.GetSummary("localhost");
        }

        /// <summary>
        /// Паттерн "Мост" позволяет изменять реализацию и абстракцию, для чего они размещаются в двух разных иерархиях классов.
        /// Мост — это структурный паттерн, он разделяет бизнес-логику или большой класс на несколько отдельных иерархий, которые потом можно развивать отдельно друг от друга.
        /// Он необходим для избежания порождения большого количества классов.
        /// Различие с паттерном "Стратегия" заключается в том, что "Стратегия" делает акцент на унифицированном использовании альтернативных алгоритмов,
        /// а "Мост" занимается именно разделением абстракции от реализации.
        /// </summary>
        public void DemoBridge()
        {
            var tv = new Tv();
            var remoteControl = new Remote(tv);
            remoteControl.TogglePower();
            remoteControl.ChannelUp();

            var advancedRemoteControl = new AdvancedRemote(tv);
            advancedRemoteControl.TogglePower();
            advancedRemoteControl.Mute();
        }

        /// <summary>
        /// Шаблон "Строитель" инкапсулирует конструирование объекта и позволяет разделить его на этапы.
        /// Строитель дает возможность использовать один и тот же код строительства для получения разных представлений объектов.
        /// Строитель обладает следующими преимуществами:
        /// - возможность поэтапного конструирования объекта с переменным набором этапов (в отличие от одноэтапных фабрик);
        /// - сокрытие внутреннего представления объекта;
        /// - инкапсуляция процесса создания сложного объекта;
        /// - реализации объектов могут свободно изменяться, т.к. клиент имеет дело только с абстрактным интерфейсом;
        /// </summary>
        public void DemoBuilder()
        {
            var director = new HouseConstructDirector();
            var houseBuilder = new StandardHouseBuilder();
            director.BuildStandardHouse(houseBuilder, true);
            var house = houseBuilder.GetResult();
        }

        /// <summary>
        /// Паттерн "Цепочка обязанностей" используется когда необходимо представить нескольким объектам возможность обработать запрос.
        /// Например, имеется непрерывный поток сообщений к приложению, которые можно категоризировать (разбивать на группы) и обрабатывать каждую группу
        /// определенным образом. Также к примеру можно отнести механизм Middleware в ASP .NET.
        /// Преимущества паттерна:
        /// - логическая изоляция отправителя запроса от получателей;
        /// - объект упрощается, так как ему не нужно знать ни структуру цепочки, ни хранить прямые ссылки на ее элементы;
        /// - возможность динамического добавления или удаления обязанностей посредством изменения элементов цепочки или их порядка.
        /// Использование паттерна может усложнять отслеживание запросов и отладку.
        /// </summary>
        public void DemoChainOfResponsibility()
        {
            var authHandler = new AuthHandler
            {
                NextHandler = new BalanceHandler
                {
                    NextHandler = new SummaryHandler(),
                }
            };
            authHandler.HandleMessage(new CommandItem
            {
                Credentials = "123",
                CommandText = "summary",
            });
        }

        /// <summary>
        /// Паттерн "Приспособленец" ("Легковес") используется в том случае, когда класс имеет множество экземпляров, которыми можно управлять одинаково.
        /// Паттерн используется для сокращения количества экземпляров в памяти во время выполнения (экономия RAM), а также для
        /// централизованного хранения состояния многих "виртуальных" объектов.
        /// Реализация:
        /// 1. Следует разделить поля класса, который станет легковесом на две части:
        /// - внутреннее состояние (значения, которые являются одинаковыми для большинства полей)
        /// - внешнее состояние (контекст): значения полей уникальны для каждого объекта.
        /// 2. Оставить поля внутреннего состояния в классе, убедиться, что их значения неизменны (эти поля должны задаваться только через конструктор).
        /// 3. Превратить поля внешнего состояния в параметры методов, где эти поля использовать, затем удалить их из класса.
        /// 4. Создать фабрику, которая будет кэшировать и повторно отдавать уже созданные объекты.
        /// Клиент должен запрашивать из этой фабрики легковеса с определенным внутренним состоянием, а не создавать его напрямую.
        /// 5. Клиент должен хранить или вычислять значения внешнего состояния (контекст) и передавать его в методы объекта легковеса.
        /// Эффективность использования паттерна зависит от того, как и где он используется. Применять следует тогда, когда в приложении:
        /// - большое количество объектов;
        /// - высокие расходы RAM;
        /// - часть состояния объектов можно вынести за пределы класса;
        /// - большие группы объектов можно заменить небольшим количеством разделяемых объектов (внешнее состояние вынесено).
        /// Объекты-легковесы должны быть неизменяемыми.
        /// </summary>
        public void DemoFlyweight()
        {
            var forest = new Forest();
            forest.PlantTree(10, 20, "Long conifer", "Green", "Standard");
            forest.PlantTree(20, 30, "Long conifer", "Green", "Standard");
        }

        /// <summary>
        /// Паттерн "Интерпретатор" определяет представление грамматики для заданного языка и интерпретатор предложений этого языка.
        /// Применяется для часто повторяющийхся операций. Представляет правила грамматики в виде классов, соответственно язык можно легко изменять или расширять.
        /// Используется для реализации простых языков (когда простота важнее эффективности). При большом количестве правил реализация становится громоздкой и неуклюжей.
        /// В таких случаях воспользоваться парсером/компилятором.
        /// </summary>
        public void DemoInterpreter()
        {
            Context context = new Context();
            context.SetVariable("x", 10);
            context.SetVariable("y", 20);
            context.SetVariable("z", 15);
            
            IExpression expression = new SubtractExpression(
                new AddExpression(
                    new NumberExpression("x"), new NumberExpression("y")
                ),
                new NumberExpression("z")
            );

            var result = expression.Interpret(context);
            Console.WriteLine(result);
        }

        /// <summary>
        /// Паттерн "Посредник" используется для централизации сложных взаимодействий и управляющих операций между объектами.
        /// Связанность множества классов друг с другом уменьшается за счет перемещения логики этих связей в один класс-посредник.
        /// Чаще всего используется для связи нескольких графических компонентов.
        /// Яркий пример из жизни - координация пилотов диспетчером.
        /// Применяется в случае, когда сложно менять некоторые классы из-за того, что они имеют множество хаотичных связей с другими классами.
        /// Когда нельзя повторно использовать класс, так как он зависит от множества других классов.
        /// Когда приходится создавать множества подклассов, чтобы использовать одни и те же компоненты в разных контекстах.
        /// Посредник может сильно раздуться и стать сложным в поддержке.
        /// </summary>
        public void DemoMediator()
        {
            var mediator = new CentralUnitMediator();
            var alarmDevice = new AlarmDevice(mediator);
            var coffeeMachineDevice = new CoffeeMachineDevice(mediator);
            var grillDevice = new GrillDevice(mediator);
            mediator.AlarmDevice = alarmDevice;
            mediator.CoffeeMachineDevice = coffeeMachineDevice;
            mediator.GrillDevice = grillDevice;
            
            alarmDevice.Send("It's 6:00AM, make cappuccino.");
            coffeeMachineDevice.Send("Cappuccino done, make toast.");
            grillDevice.Send("Toast done. Work completed.");
        }

        /// <summary>
        /// Паттерн "Хранитель" ("Снимок") используется для релации возврата к одному из предыдущих состояний
        /// (к примеру, при нажатии пользователем "Отмена"). Важно заметить, что паттерн позволяет
        /// выносить внутреннее состояние объекта за его пределы без последующего нарушения принципа инкапсуляции.
        /// Преимущества хранителя в том, что:
        /// - хранение состояния отдельно от ключевого объекта улучшает связность системы;
        /// - происходит инкапсуляция данных ключевого объекта;
        /// - простая реализация восстановления;
        /// Иногда для сохранения состояния можно воспользоваться сериализацией. Но операция сохранения/восстановления
        /// сама по себе может быть долгой операцией.
        /// </summary>
        public void DemoMemento()
        {
            var game = new Game();
            game.GetDamaged(10);
            game.LevelUp(1);
            game.TakeMoney(100);
            var gameHistory = new GameHistory(game);
            gameHistory.Save();
            gameHistory.Undo();
        }

        /// <summary>
        /// Паттерн "Прототип" используется в тех случаях, когда создание экземпляра класса требует больших затрат ресурсов
        /// или занимает много времени. Является порождающим паттерном, который позволяет копировать объекты любой
        /// сложности без привязки к их конкретным классам. Реализован в BCL через интерфейс ICloneable.
        /// Легко распознать прототип по наличию методов Clone или Copy.
        /// Преимущества прототипа в том, что:
        /// - сложности реализации копирования скрыты от клиента;
        /// - у клиента появляется возможность генерировать объекты, тип которых неизвестен клиенту;
        /// - иногда копирование эффективнее, чем создание нового объекта.
        /// </summary>
        public void DemoPrototype()
        {
            var werewolfMonster = new WerewolfMonster(10, 40, 20);
            var vampireMonster = new VampireMonster(4, 30);
            var copyWerewolfMonster = werewolfMonster.Clone();
        }

        /// <summary>
        /// Паттерн "Посетитель" используется для расширения возможностей комбинации объектов в том случае,
        /// если инкапсуляция не существенна. Иными словами это поведенческий паттерн, который позволяет добавить
        /// новую операцию для целой иерархии классов, не изменяя при этом код этих классов.
        /// В ситуации, когда полиморфизим запрещен (нельзя добавлять новое поведение в базовом классе и
        /// переопределять в наследниках) может помочь "Посетитель". В соответствии с ним новое поведение будет
        /// размещено в отдельном классе.
        /// Отсюда и недостаток паттерна: нарушение инкапсуляции структуры и усложнение возможных изменений.
        /// </summary>
        public void DemoVisitor()
        {
            var cells = new List<ICell>
            {
                new SimpleCell(),
                new CalculatedCell(),
            };
            var visitor = new LockingCellVisitor();
            foreach (var cell in cells)
            {
                cell.Accept(visitor);
            }
        }
    }
}
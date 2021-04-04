namespace DesignPatternDemos.Adapter
{
    /// <summary>
    /// Реализация паттерна "Адаптер"
    /// Напоминает применение паттерна "Декоратор", но отличия в том,
    /// что "Декоратор" не изменяет интерфейс, но добавляет новые обязанности,
    /// а "Адаптер" преобразует один интерфейс к другому
    /// </summary>
    public class PopulationInfoTcpServiceAdapter : IHttpService
    {
        private readonly PopulationInfoTcpService _populationInfoTcpService;

        public PopulationInfoTcpServiceAdapter(PopulationInfoTcpService populationInfoTcpService)
        {
            _populationInfoTcpService = populationInfoTcpService;
        }

        public string GetResultFromHttp()
        {
            return _populationInfoTcpService.GetResultFromTcp();
        }
    }
}
namespace DesignPatternDemos.Proxy
{
    /// <summary>
    /// Пример реализации паттерна "Удаленный заместитель"
    /// Текущий класс управляет доступом к классу LocalDiagnosticManager,
    /// который возвращает суммарную информацию о локальном компьютере
    /// </summary>
    public class DiagnosticManager : IDiagnosticManager
    {
        private readonly IDiagnosticManager _localDiagnosticManager = new LocalDiagnosticManager();

        public DiagnosticInfo GetSummary(string address)
        {
            if (address == "localhost")
            {
                return _localDiagnosticManager.GetSummary(address);
            }

            // Код по обращению к диагностическому сервису на другом компьютере,
            // который возвращает соответствующий результат
            return new DiagnosticInfo();
        }
    }
}
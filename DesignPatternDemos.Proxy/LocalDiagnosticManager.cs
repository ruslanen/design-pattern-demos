namespace DesignPatternDemos.Proxy
{
    public class LocalDiagnosticManager : IDiagnosticManager
    {
        public DiagnosticInfo GetSummary(string address)
        {
            // Код по обращению к диагностическому сервису на компьютере,
            // с которого запущено приложение
            return new DiagnosticInfo();
        }
    }
}
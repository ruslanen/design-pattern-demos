namespace DesignPatternDemos.Adapter
{
    /// <summary>
    /// Сервис для получения информации о населении
    /// </summary>
    public class PopulationInfoTcpService : ITcpService
    {
        public string GetResultFromTcp()
        {
            // Логика получения результата работы сервиса через TCP
            return string.Empty;
        }
    }
}
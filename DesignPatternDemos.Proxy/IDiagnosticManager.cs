namespace DesignPatternDemos.Proxy
{
    /// <summary>
    /// Представляет службу для получения диагностической информации о компьютере
    /// </summary>
    public interface IDiagnosticManager
    {
        /// <summary>
        /// Возвращает суммарную информацию о состоянии основных компонентов компьютера
        /// (оперативная память, процессор, физическая память)
        /// </summary>
        /// <returns>Суммарная диагностическая информация</returns>
        public DiagnosticInfo GetSummary(string address);
    }
}
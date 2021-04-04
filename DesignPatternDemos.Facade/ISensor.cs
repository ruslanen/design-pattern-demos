namespace DesignPatternDemos.Facade
{
    /// <summary>
    /// Контракт для датчика
    /// </summary>
    public interface ISensor
    {
        /// <summary>
        /// Получить информацию с датчика
        /// </summary>
        string GetResult();
    }
}
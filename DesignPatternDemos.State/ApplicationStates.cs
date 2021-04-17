namespace DesignPatternDemos.State
{
    /// <summary>
    /// Перечисление статусов приложения
    /// (добавлено для наглядности)
    /// </summary>
    public enum ApplicationStates
    {
        Stopped,
        Initializing,
        Migrating,
        Running,
    }
}
namespace DesignPatternDemos.Command
{
    /// <summary>
    /// Контракт для всех команд
    /// </summary>
    public interface ICommand
    {
        void Execute(string[] arguments);
    }
}
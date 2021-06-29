namespace DesignPatternDemos.Prototype
{
    /// <summary>
    /// Прототип. Описывает операции копирования.
    /// В большинстве случаев это только метод Clone.
    /// </summary>
    public interface IMonster
    {
        IMonster Clone();
    }
}
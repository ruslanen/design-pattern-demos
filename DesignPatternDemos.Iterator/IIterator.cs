namespace DesignPatternDemos.Iterator
{
    /// <summary>
    /// Контракт для паттерна "Итератор".
    /// В качестве примера здесь рассматривается собственный интерфейс,
    /// хотя можно было также использовать встроенный интерфейс из BCL - IEnumerator.
    /// </summary>
    public interface IIterator
    {
        /// <summary>
        /// Возвращает признак наличия следующего элемента в итерируемой коллекции
        /// </summary>
        bool HasNext();

        /// <summary>
        /// Возвращает следующий элемент коллекции
        /// </summary>
        object Next();
    }
}
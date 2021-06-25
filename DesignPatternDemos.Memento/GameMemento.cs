namespace DesignPatternDemos.Memento
{
    /// <summary>
    /// Memento (снимок) - это простой объект, содержащий состояние создателя.
    /// Надежнее проектировать снимок в неизменяемом состоянии, передавая данные через конструктор.
    /// </summary>
    public class GameMemento
    {
        public int CurrentLevel { get; private set; }
        
        public int Health { get; private set; }
        
        public double Money { get; private set; }

        public GameMemento(int currentLevel, int health, double money)
        {
            CurrentLevel = currentLevel;
            Health = health;
            Money = money;
        }
    }
}
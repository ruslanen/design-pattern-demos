namespace DesignPatternDemos.Memento
{
    /// <summary>
    /// Originator (создатель) может производить снимки своего состояния, а также
    /// воспроизводить предыдущие состояния.
    /// </summary>
    public class Game
    {
        private int _currentLevel = 0;
        private int _health = 100;
        private double _money = 0;

        public void GetDamaged(int value)
        {
            _health -= value;
        }

        public void TakeMoney(double value)
        {
            _money += value;
        }
        
        public void LevelUp(int value)
        {
            _currentLevel += value;
        }

        public GameMemento SaveCurrentState()
        {
            return new GameMemento(_currentLevel, _health, _money);
        }

        public void RestoreState(GameMemento gameMemento)
        {
            _currentLevel = gameMemento.CurrentLevel;
            _health = gameMemento.Health;
            _money = gameMemento.Money;
        }
    }
}
namespace DesignPatternDemos.Prototype
{
    public class WerewolfMonster : IMonster
    {
        private readonly int _strength;
        private readonly int _health;
        private readonly int _speed;
        
        public WerewolfMonster(int strength, int health, int speed)
        {
            _strength = strength;
            _health = health;
            _speed = speed;
        }
        
        public IMonster Clone()
        {
            return new WerewolfMonster(_strength, _health, _speed);
        }
    }
}
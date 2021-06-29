namespace DesignPatternDemos.Prototype
{
    public class VampireMonster : IMonster
    {
        private readonly int _strength;
        private readonly int _health;

        public VampireMonster(int strength, int health)
        {
            _strength = strength;
            _health = health;
        }
        
        public IMonster Clone()
        {
            // Данный код можно заменить на:
            // return this.MemberwiseClone() as IFigure;
            // так как MemberwiseClone работает со значимыми типами
            // (если были бы ссылочные поля - было бы неполное копирование).
            // Для полного копирования справедливо выносить метод DeepClone и копировать все поля класса
            // (включая возможную иерархию у ссылочных полей).
            // Также справедливо в случае ссылочных полей использовать сериализацию/десериализацию для осуществления копирования.
            // Для использования возможности сериализации придется добавлять к классам атрибут [Serializable].
            return new VampireMonster(_strength, _health);
        }
    }
}
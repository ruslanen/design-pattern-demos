namespace DesignPatternDemos.Flyweight
{
    /// <summary>
    /// Является клиентом "Легковеса", а также контекстным объектом, из которого был выделен легковес TreeType.
    /// Может быть тысячи подобных объектов в программе.
    /// </summary>
    public class Tree
    {
        private readonly int _x;

        private readonly int _y;

        private readonly TreeType _treeType;

        public Tree(int x, int y, TreeType treeType)
        {
            _x = x;
            _y = y;
            _treeType = treeType;
        }

        public void Draw()
        {
            _treeType.Draw(_x, _y);
        }
    }
}
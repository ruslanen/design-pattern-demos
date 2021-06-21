namespace DesignPatternDemos.Flyweight
{
    /// <summary>
    /// Легковес, содержащий чаасть полей, которые описывают деревья.
    /// Поля не уникальны для каждого объекта дерева в отличие от координат.
    /// Множество деревьев могут иметь одинаковую текстуру.
    /// </summary>
    public class TreeType
    {
        public string name;

        public string color;

        public string texture;

        public TreeType(string name, string color, string texture)
        {
            this.name = name;
            this.color = color;
            this.texture = texture;
        }

        public void Draw(int x, int y)
        {
            // Логика отрисовки дерева
        }
    }
}
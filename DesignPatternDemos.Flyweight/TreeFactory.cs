using System.Collections.Generic;
using System.Linq;

namespace DesignPatternDemos.Flyweight
{
    /// <summary>
    /// Фабрика определяет, когда необходимо создавать новый легковес, а когда можно взять существующий
    /// </summary>
    public class TreeFactory
    {
        private static List<TreeType> TreeTypes;

        public static TreeType GetTreeType(string name, string color, string texture)
        {
            var type = TreeTypes.FirstOrDefault(x => x.name == name); // Поиск по остальным полям опущен
            if (type == null)
            {
                type = new TreeType(name, color, texture);
            }

            return type;
        }
    }
}
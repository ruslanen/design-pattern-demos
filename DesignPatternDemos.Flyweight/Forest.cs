using System.Collections.Generic;

namespace DesignPatternDemos.Flyweight
{
    /// <summary>
    /// Является клиентом "Легковеса"
    /// </summary>
    public class Forest
    {
        private List<Tree> Trees = new List<Tree>();

        public void PlantTree(int x, int y, string name, string color, string texture)
        {
            var type = TreeFactory.GetTreeType(name, color, texture);
            var tree = new Tree(x, y, type);
            Trees.Add(tree);
        }

        public void Draw()
        {
            foreach (var tree in Trees)
            {
                tree.Draw();
            }
        }
    }
}
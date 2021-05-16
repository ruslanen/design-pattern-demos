namespace DesignPatternDemos.Builder
{
    public class StandardHouseBuilder : IHouseBuilder
    {
        public void BuildWalls()
        {
            // Построение стен дома
        }

        public void BuildWindows()
        {
            // Построение окон дома
        }

        public void BuildGarage()
        {
            // Построение гаража у дома
        }

        public void BuildFacade()
        {
            // Построение фасада дома
        }

        public void BuildFence()
        {
            // Построение забора дома
        }

        public House GetResult()
        {
            return new House();
        }
    }
}
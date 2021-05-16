namespace DesignPatternDemos.Builder
{
    /// <summary>
    /// Содержит шаги построения продукта, которые должны быть у всех имплементаций строителей
    /// </summary>
    public interface IHouseBuilder
    {
        void BuildWalls();
        
        void BuildWindows();

        void BuildGarage();

        void BuildFacade();

        void BuildFence();
    }
}
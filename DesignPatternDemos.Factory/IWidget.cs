namespace DesignPatternDemos.Factory
{
    public abstract class BaseWidget
    {
        public abstract void AddLegend();

        public void Render()
        {
            // Базовая логика отрисовки виджета
        }
    }
}
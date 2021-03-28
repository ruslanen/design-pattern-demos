using System.Collections.Generic;

namespace DesignPatternDemos.Factory
{
    public class Dashboard
    {
        private readonly WidgetFactory _widgetFactory;

        public List<BaseWidget> Widgets { get; } = new List<BaseWidget>();

        public Dashboard(WidgetFactory widgetFactory)
        {
            _widgetFactory = widgetFactory;
        }

        public void AddWidget(string type)
        {
            BaseWidget widget = _widgetFactory.CreateWidget(type);
            widget.AddLegend();
            widget.Render();
            Widgets.Add(widget);
        }
    }
}
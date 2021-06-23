namespace DesignPatternDemos.ChainOfResponsibility
{
    public class SummaryHandler : IHandler
    {
        public IHandler NextHandler { get; set; }
        
        public void HandleMessage(CommandItem message)
        {
            if (message.CommandText.Contains("summary"))
            {
                // Расчет и выдача суммарной информации
            }
            
            NextHandler?.HandleMessage(message);
        }
    }
}
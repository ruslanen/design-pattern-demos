namespace DesignPatternDemos.ChainOfResponsibility
{
    public class BalanceHandler : IHandler
    {
        public IHandler NextHandler { get; set; }
        
        public void HandleMessage(CommandItem message)
        {
            if (message.CommandText.Contains("balance"))
            {
                // Выдача информации о текущем балансе
            }
            
            NextHandler.HandleMessage(message);
        }
    }
}
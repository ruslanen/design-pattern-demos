using System;

namespace DesignPatternDemos.ChainOfResponsibility
{
    public class AuthHandler : IHandler
    {
        public IHandler NextHandler { get; set; }
        
        public void HandleMessage(CommandItem message)
        {
            // Проверка строки полномочий на возможность выполнения команды
            if (message.Credentials != "123")
            {
                throw new Exception("Access denied");
            }
            
            NextHandler.HandleMessage(message);
        }
    }
}
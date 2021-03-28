using System;

namespace DesignPatternDemos.Command
{
    public class HelpCommand : ICommand
    {
        public void Execute(string[] arguments)
        {
            Console.WriteLine(@"Список доступных команд:
--h        - помощь
--ps <URL> - получить размер страницы (в байтах)
--s <URL>  - получить HTML страницы");
        }
    }
}
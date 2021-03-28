using System;

namespace DesignPatternDemos.Command
{
    public class PageSizeCommand : ICommand
    {
        private readonly PageInfoService _pageInfoService;
        
        public PageSizeCommand(PageInfoService pageInfoService)
        {
            _pageInfoService = pageInfoService;
        }
        
        public void Execute(string[] arguments)
        {
            var size = _pageInfoService.GetPageSize(arguments[0]);
            Console.WriteLine(size);
        }
    }
}
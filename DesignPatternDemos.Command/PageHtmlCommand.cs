using System;

namespace DesignPatternDemos.Command
{
    public class PageHtmlCommand : ICommand
    {
        private readonly PageInfoService _pageInfoService;
        
        public PageHtmlCommand(PageInfoService pageInfoService)
        {
            _pageInfoService = pageInfoService;
        }
        
        public void Execute(string[] arguments)
        {
            var html = _pageInfoService.GetPageHtml(arguments[0]);
            Console.WriteLine(html);
        }
    }
}
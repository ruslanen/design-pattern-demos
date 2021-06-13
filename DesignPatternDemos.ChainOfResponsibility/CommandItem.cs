using System;

namespace DesignPatternDemos.ChainOfResponsibility
{
    public class CommandItem
    {
        public string CommandText { get; set; } 
        
        public string Credentials { get; set; }
    }
}
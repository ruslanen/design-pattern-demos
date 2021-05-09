namespace DesignPatternDemos.Proxy
{
    public class DiagnosticInfo
    {
        public Ram Ram { get; set; }
        
        public Cpu Cpu { get; set; }
        
        public Memory Memory { get; set; }
    }

    public class Ram
    {
        public double Total { get; set; }
        
        public double Free { get; set; }
        
        public double Load { get; set; }
    }

    public class Cpu
    {
        public int Cores { get; set; }
        
        public double Load { get; set; }
    }

    public class Memory
    {
        public double Total { get; set; }
        
        public double Free { get; set; }
    }
}
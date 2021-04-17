using System;

namespace DesignPatternDemos.State
{
    public class StopState : IApplicationState
    {
        private readonly Application _application;
        
        public StopState(Application application)
        {
            _application = application;
        }
        
        public void Initialize()
        {
            Console.WriteLine("Application already initialized");
        }

        public void Start()
        {
            Console.WriteLine("Application already started");
        }

        public void Migrate()
        {
            Console.WriteLine("Application already migrated");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping application..");
            // Environment.Exit(1);
        }
    }
}
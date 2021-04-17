using System;

namespace DesignPatternDemos.State
{
    public class StartState : IApplicationState
    {
        private readonly Application _application;
        
        public StartState(Application application)
        {
            _application = application;
        }
        
        public void Initialize()
        {
            Console.WriteLine("Application already initialized");
        }

        public void Start()
        {
            Console.WriteLine("Application starting..");
        }

        public void Migrate()
        {
            Console.WriteLine("Can't migrate application from started (running) state");
        }

        public void Stop()
        {
            _application.SetState(_application.StopState);
        }
    }
}
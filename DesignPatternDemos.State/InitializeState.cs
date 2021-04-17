using System;

namespace DesignPatternDemos.State
{
    public class InitializeState : IApplicationState
    {
        private readonly Application _application;
        
        public InitializeState(Application application)
        {
            _application = application;
        }
        
        public void Initialize()
        {
            Console.WriteLine("Application initialized");
            _application.SetState(_application.MigrateState);
        }

        public void Start()
        {
            Console.WriteLine("Please wait, application initializing..");
        }

        public void Migrate()
        {
            Console.WriteLine("Can't migrate application while initializing hasn't done..");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping application available only from started (running) state");
        }
    }
}
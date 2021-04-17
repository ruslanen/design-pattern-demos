using System;

namespace DesignPatternDemos.State
{
    public class MigrateState : IApplicationState
    {
        private readonly Application _application;
        
        public MigrateState(Application application)
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
            Console.WriteLine("Performing migrations..");
            _application.SetState(_application.StartState);
        }

        public void Stop()
        {
            Console.WriteLine("Stopping application available only from started (running) state");
        }
    }
}
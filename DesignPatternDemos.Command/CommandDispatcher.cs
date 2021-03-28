namespace DesignPatternDemos.Command
{
    public class CommandDispatcher
    {
        private readonly ICommand[] _commands;

        public CommandDispatcher()
        {
            _commands = new ICommand[3];
        }

        public void SetCommand(int slot, ICommand command)
        {
            _commands[slot] = command;
        }

        public void OnCommandExecute(int slot, string[] arguments)
        {
            _commands[slot].Execute(arguments);
        }
    }
}
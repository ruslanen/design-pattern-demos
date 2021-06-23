namespace DesignPatternDemos.Interpreter
{
    /// <summary>
    /// Терминальное выражение
    /// (Объект, присутствующий в словах языка, соответствующего грамматике, и имеющий конкретное, неизменяемое значение (обобщение понятия «буквы»)).
    /// </summary>
    public class NumberExpression : IExpression
    {
        private readonly string _name;
        
        public NumberExpression(string variableName)
        {
            _name = variableName;
        }
        
        public int Interpret(Context context)
        {
            return context.GetVariable(_name);
        }
    }
}
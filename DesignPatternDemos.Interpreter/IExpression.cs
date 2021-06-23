namespace DesignPatternDemos.Interpreter
{
    public interface IExpression
    {
        int Interpret(Context context);
    }
}
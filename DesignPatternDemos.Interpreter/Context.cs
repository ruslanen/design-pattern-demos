using System;
using System.Collections.Generic;

namespace DesignPatternDemos.Interpreter
{
    /// <summary>
    /// Содержит общую для интерпретатора информацию.
    /// Может использоваться объектами терминальных и нетерминальных выражений для сохранения состояния операций и последующего доступа к сохраненному состоянию.
    /// </summary>
    public class Context
    {
        private readonly Dictionary<string, int> _variables = new Dictionary<string, int>();
        
        public int GetVariable(string name)
        {
            return _variables[name];
        }

        public void SetVariable(string name, int value)
        {
            if (_variables.ContainsKey(name))
            {
                _variables[name] = value;
            }
            else
            {
                _variables.Add(name, value);
            }
        }
    }
}
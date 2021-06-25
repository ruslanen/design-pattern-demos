using System;
using System.Collections.Generic;

namespace DesignPatternDemos.Memento
{
    /// <summary>
    /// Caretaker (опекун) должен знать когда делать снимок и когда его восстанавливать.
    /// Может хранить множество предыдущих состояние и брать последнее для восстановления.
    /// </summary>
    public class GameHistory
    {
        private Game _originatorGame;
        
        public Stack<GameMemento> HistorySnapshots { get; private set; } = new Stack<GameMemento>();

        public GameHistory(Game originatorGame)
        {
            _originatorGame = originatorGame;
        }
        
        public void Save()
        {
            var currentState = _originatorGame.SaveCurrentState();
            HistorySnapshots.Push(currentState);
        }

        public void Undo()
        {
            if (HistorySnapshots.Count > 0)
            {
                var lastGame = HistorySnapshots.Pop();
                _originatorGame.RestoreState(lastGame);
            }
            else
            {
                throw new Exception("Game history is empty");
            }
        }
    }
}
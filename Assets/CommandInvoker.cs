using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    private Stack<ICommand> commandHistory = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        commandHistory.Push(command);
    }

    public void Undo()
    {
        if (commandHistory.Count > 0)
        {
            ICommand command = commandHistory.Pop();
            command.Undo();
        }
        else
        {
            Debug.Log("No commands to undo");
        }
    }

    public bool CanUndo()
    {
        return commandHistory.Count > 0;
    }

    public void ClearHistory()
    {
        commandHistory.Clear();
    }
}

using System.Collections.Generic;

/// <summary>
/// Associated with multiple commands
/// </summary>
public class Invoker
{
    private Stack<ICommand> _commandList;

    public Invoker()
    {
        _commandList = new Stack<ICommand>();
    }

    /// <summary>
    /// Executes a command and adds it to a stack
    /// </summary>
    /// <param name="newCommand"></param>
    public void AddCommand(ICommand newCommand)
    {
        newCommand.Do();
        _commandList.Push(newCommand);
    }

    public void UndoCommand()
    {
        if (_commandList.Count <= 0) return;
        var lastCommand = _commandList.Pop();
        lastCommand.Undo();
    }
}
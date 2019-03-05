using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    class CommandManager
    {
        //2 stacks om alle commands die zijn uitgevoerd te bewaren om zo redo en undo te kunnen doen.
        private Stack<ICommand> undoCommand = new Stack<ICommand>();
        private Stack<ICommand> redoCommand = new Stack<ICommand>();

        
        public void ExecuteCommand(ICommand command, EventArgs e)
        {
            command.Execute(e);
            if(command is IUndoableCommand)
            {
                undoCommand.Push(command);
            }
        }

        public void Undo(EventArgs e)
        {
            if(undoCommand.Count != 0)
            {
                IUndoableCommand temp = (IUndoableCommand)undoCommand.Peek();

                redoCommand.Push(temp);

                temp.Undo(e);
                undoCommand.Pop();
            }
        }

        public void Redo(EventArgs e)
        {
            if (redoCommand.Count != 0)
            {
                IUndoableCommand temp = (IUndoableCommand)redoCommand.Peek();

                undoCommand.Push(temp);

                temp.Execute(e);
                redoCommand.Pop();
            }
        }
    }
}

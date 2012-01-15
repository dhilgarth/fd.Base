using System;
using System.Windows.Input;

namespace fd.Base.Mvvm
{
    /// <summary>
    ///   A simple implementation of <see cref="ICommand" /> .
    /// </summary>
    public class SimpleCommand : ICommand
    {
        #region Variables

        private readonly Func<bool> _canExecute;
        private readonly Action _execute;

        #endregion

        /// <summary>
        ///   Initializes a new instance of the <see cref="SimpleCommand" /> class.
        /// </summary>
        /// <param name="execute"> The action to execute when the command is executed. </param>
        public SimpleCommand(Action execute)
            : this(execute, () => true)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SimpleCommand" /> class.
        /// </summary>
        /// <param name="execute"> The action to execute when the command is executed. </param>
        /// <param name="canExecute"> A function that is executed when the commands <see cref="CanExecute" /> is executed. </param>
        public SimpleCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            if (canExecute == null)
                throw new ArgumentNullException("canExecute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #region ICommand Members

        /// <summary>
        ///   Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public virtual event EventHandler CanExecuteChanged;

        /// <summary>
        ///   Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter"> Data used by the command. If the command does not require data to be passed, this object can be set to null. </param>
        /// <returns> true if this command can be executed; otherwise, false. </returns>
        public virtual bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        /// <summary>
        ///   Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter"> Data used by the command. If the command does not require data to be passed, this object can be set to null. </param>
        public virtual void Execute(object parameter)
        {
            _execute();
        }

        #endregion

        /// <summary>
        ///   Raises the <see cref="CanExecuteChanged" /> event.
        /// </summary>
        public virtual void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}

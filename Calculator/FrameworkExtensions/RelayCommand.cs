// =====================
// The "Roma Widget Set"
// =====================

/*
 * Created by Mono Develop 2.4.1.
 * User: PloetzS
 * Date: October 2014
 * --------------------------------
 * Author: Steffen Ploetz
 * eMail:  Steffen.Ploetz@cityweb.de
 * 
 * In case of problems with .NEt see: .NET Reference Source, http://referencesource-beta.microsoft.com/
 * 
 */

// //////////////////////////////////////////////////////////////////////
//
// Copyright (C) 2014 Steffen Ploetz
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// This copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// //////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Input;

namespace Xrw.Utils
{
    /// <summary>Code from http://msdn.microsoft.com/en-us/magazine/dd419663.aspx
    /// A command whose sole purpose is to relay its functionality to other objects by invoking
    /// delegates. The default return value for the CanExecute method is 'true'.</summary>
    /// <remarks>
    /// Typical use case:
    /// =================
    /// 1: Define the execute action.
    /// -----------------------------
    /// private void My_Action(object o)
    /// {   ...     }
    /// 2: Define the can execute action.
    /// ---------------------------------
    /// private void My_CanAction(object o)
    /// {   ...     }
    /// 1: Create the command.
    /// ----------------------
    /// RelayCommand My_Command = new RelayCommand(My_Action, My_CanAction);
    /// </remarks>
    public class RelayCommand : ICommand
    {
        // ###############################################################################
        // ### F I E L D S
        // ###############################################################################

        #region Fields

        /// <summary>The delegate to execute the commad.</summary>
        readonly Action<object> _execute;

        /// <summary>The delegate to check whether execution can be done.</summary>
        readonly Predicate<object> _canExecute;

        #endregion Fields

        // ###############################################################################
        // ### C O N S T R U C T I O N   A N D   I N I T I A L I Z A T I O N
        // ###############################################################################

        #region Constructors

        /// <summary>Create a new RelayCommand instance, that can always execute.</summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
        }

        /// <summary>Create a new RelayCommand instance, that can always execute and always check whether execution can be done.</summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion Constructors

        // ###############################################################################
        // ### M E T H O D S
        // ###############################################################################

        #region ICommand Members

        /// <summary>Defines the method that determines whether the command can execute in its current state.</summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed,
        /// this object can be set to null.<see cref="System.Object"/></param>
        /// <returns>True if this command can be executed; otherwise, false.<see cref="System.Boolean"/></returns>
        // [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        /// <summary> Occurs when changes occur that affect whether the command should execute.</summary>
        public event EventHandler CanExecuteChanged
        {
            add { System.Windows.Input.CommandManager.RequerySuggested += value; }
            remove { System.Windows.Input.CommandManager.RequerySuggested -= value; }
        }

        /// <summary>Defines the method to be called when the command is invoked.</summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed,
        /// this object can be set to null.<see cref="System.Object"/></param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion // ICommand Members
    }

}
﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DelegateCommand.cs" company="Freiwillige Feuerwehr Krems/Donau">
//     Freiwillige Feuerwehr Krems/Donau
//     Austraße 33
//     A-3500 Krems/Donau
//     Austria
// 
//     Tel.:   +43 (0)2732 85522
//     Fax.:   +43 (0)2732 85522 40
//     E-mail: office@feuerwehr-krems.at
// 
//     This software is furnished under a license and may be
//     used  and copied only in accordance with the terms of
//     such  license  and  with  the  inclusion of the above
//     copyright  notice.  This software or any other copies
//     thereof   may  not  be  provided  or  otherwise  made
//     available  to  any  other  person.  No  title  to and
//     ownership of the software is hereby transferred.
// 
//     The information in this software is subject to change
//     without  notice  and  should  not  be  construed as a
//     commitment by Freiwillige Feuerwehr Krems/Donau.
// 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace At.FF.Krems.FullscreenBrowser
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Simplistic delegate command for the demo.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>The can execute changed.</summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>Gets or sets the command action.</summary>
        public Action CommandAction { get; set; }

        /// <summary>Gets or sets the can execute function.</summary>
        public Func<bool> CanExecuteFunc { get; set; }

        /// <summary>The execute.</summary>
        /// <param name="parameter">The parameter.</param>
        public void Execute(object parameter)
        {
            this.CommandAction();
        }

        /// <summary>The can execute.</summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool CanExecute(object parameter)
        {
            return this.CanExecuteFunc == null || this.CanExecuteFunc();
        }
    }
}
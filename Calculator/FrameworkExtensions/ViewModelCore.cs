// =====================
// The "Roma Widget Set"
// =====================

/*
 * Created by Mono Develop 2.4.1.
 * User: PloetzS
 * Date: September 2014
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
using System.ComponentModel;

namespace Calculator.FrameworkExtensions
{
    /// <summary>Realize the binding and communication between a view and a model.</summary>
    public class ViewModelCore<ViewType> : INotifyPropertyChanged
        where ViewType : IView
    {

        // ###############################################################################
        // ### C O N S T A N T S
        // ###############################################################################

        #region Constants

        /// <summary> The class name constant. </summary>
        public const string CLASS_NAME = "ViewModelCore";

        #endregion

        // ###############################################################################
        // ### A T T R I B U T E S
        // ###############################################################################

        #region Attributes

        /// <summary>The connected view.</summary>
        private ViewType _view;

        #endregion

        // ###############################################################################
        // ### E V E N T S
        // ###############################################################################

        #region INotifyPropertyChanged event definitions

        /// <summary>Register PropertyChanged event handler.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        // ###############################################################################
        // ### C O N S T R U C T I O N   A N D   I N I T I A L I Z A T I O N
        // ###############################################################################

        #region Construction

        /// <summary>Default constructor.</summary>
        /// <param name="view">The connected view.<see cref="ViewType"/></param>
        public ViewModelCore(ViewType view)
        {
            _view = view;
            if (_view as IView != null)
                _view.DataContext = this;
        }

        #endregion

        // ###############################################################################
        // ### P R O P E R T I E S
        // ###############################################################################

        #region Properties

        /// <summary>Get the connected view.</summary>
        public ViewType View
        {
            get { return _view; }
        }

        #endregion

        // ###############################################################################
        // ### M E T H O D S
        // ###############################################################################

        #region Methods

        /// <summary>Raise the PropertyChanged event.</summary>
        /// <param name="propertyName">The name of the property, that changed.<see cref="System.String"/></param>
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }

}


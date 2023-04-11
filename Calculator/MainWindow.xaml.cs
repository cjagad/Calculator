﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Calculator
{
    /// <summary>The main window of the application. This class must be derived from XrwXAML.Window.
    /// It must be a partial class. The second part of the class will be autogenerated and named '*.generated.cs'.</summary>
    public partial class MainWindow : Window, FrameworkExtensions.IView
    {

        /// <summary>Provide the possible actions, that are to apply next.</summary>
        private enum SecondArgumentAction
        {
            /// <summary>No specific action is to apply.</summary>
            None,

            /// <summary>Add a second argument to the last value.</summary>
            Add,

            /// <summary>Subtract a second argument from the last value.</summary>
            Substract,

            /// <summary>Clear the current entry.</summary>
            Clear
        }

        /// <summary>Store a self-reference, that enables other classes to access the main view.</summary>
        private static MainWindow _instance = null;

        /// <summary>Define the currently selected action.</summary>
        private SecondArgumentAction _operator = SecondArgumentAction.None;

        /// <summary>The last value.</summary>
        private string _value = "";

        /// <summary>The default constructor.</summary>
        public MainWindow()
        {
            _instance = this;
            InitializeComponent();
        }

        /// <summary>Get the self-reference, that enables other classes to access the main view.</summary>
        public static MainWindow Instance
        { get { return _instance; } }


        /// <summary>Process the "EditDeleteLast" button click event.</summary>
		/// <param name="sender">The event source.<see cref="System.Object"/></param>
		/// <param name="e">The event data.<see cref="RoutedEventArgs"/></param>
        private void EditDeleteLast_Click(object sender, RoutedEventArgs e)
        {
            Entry.Text = Entry.Text.Substring(0, Entry.Text.Length - 1);

            if (String.IsNullOrEmpty(Entry.Text))
                Entry.Text = "0";
        }

        /// <summary>Process the "EditClearAll" button click event.</summary>
        /// <param name="sender">The event source.<see cref="System.Object"/></param>
        /// <param name="e">The event data.<see cref="RoutedEventArgs"/></param>
        private void EditClearAll_Click(object sender, RoutedEventArgs e)
        {
            _operator = SecondArgumentAction.None;
            Entry.Text = "0";
            Info.Text = "";
            _value = "";
        }


        /// <summary>Process the "NumberZero" button click event.</summary>
        /// <param name="sender">The event source.<see cref="System.Object"/></param>
        /// <param name="e">The event data.<see cref="RoutedEventArgs"/></param>
        private void NumberZero_Click(object sender, RoutedEventArgs e)
        { NumberZero_Action(sender); }

        /// <summary>The action for "NumberZero" button click event.</summary>
        /// <param name="o">A parameter to use for any purpose.</param>
        public void NumberZero_Action(object o)
        {
            if (_operator == SecondArgumentAction.Clear)
            {
                Entry.Text = "0";
                _operator = SecondArgumentAction.None;
            }

            if (Entry.Text == "0")
                Entry.Text = "0";
            else
                Entry.Text += "0";
        }

        /// <summary>Process the "NumberOne" button click event.</summary>
        /// <param name="sender">The event source.<see cref="System.Object"/></param>
        /// <param name="e">The event data.<see cref="RoutedEventArgs"/></param>
        private void NumberOne_Click(object sender, RoutedEventArgs e)
        { NumberOne_Action(sender); }

        /// <summary>The action for "NumberOne" button click event.</summary>
        /// <param name="o">A parameter to use for any purpose.</param>
        public void NumberOne_Action(object o)
        {
            if (_operator == SecondArgumentAction.Clear)
            {
                Entry.Text = "0";
                _operator = SecondArgumentAction.None;
            }

            if (Entry.Text == "0")
                Entry.Text = "1";
            else
                Entry.Text += "1";
        }


        /// <summary>Process the "CalculateSubtract" button click event.</summary>
        /// <param name="sender">The event source.<see cref="System.Object"/></param>
        /// <param name="e">The event data.<see cref="RoutedEventArgs"/></param>
        private void CalculateSubtract_Click(object sender, RoutedEventArgs e)
        { CalculateSubtract_Action(sender); }

        /// <summary>The action for "CalculateSubtract" button click event.</summary>
        /// <param name="o">A parameter to use for any purpose.</param>
        public void CalculateSubtract_Action(object o)
        {
            if (_operator != SecondArgumentAction.Clear &&
                _operator != SecondArgumentAction.None)
                CalculateResult_Action(o);

            _operator = SecondArgumentAction.Substract;
            _value = Entry.Text;
            Entry.Text = "";

            Info.Text = _value.ToString() + " -";
        }

        /// <summary>Process the "CalculateAdd" button click event.</summary>
        /// <param name="sender">The event source.<see cref="System.Object"/></param>
        /// <param name="e">The event data.<see cref="RoutedEventArgs"/></param>
        private void CalculateAdd_Click(object sender, RoutedEventArgs e)
        { CalculateAdd_Action(sender); }

        /// <summary>The action for "CalculateAdd" button click event.</summary>
        /// <param name="o">A parameter to use for any purpose.</param>
        public void CalculateAdd_Action(object o)
        {
            if (_operator != SecondArgumentAction.Clear &&
                _operator != SecondArgumentAction.None)
                CalculateResult_Action(o);

            _operator = SecondArgumentAction.Add;
            _value = Entry.Text;
            Entry.Text = "";

            Info.Text = _value.ToString() + " +";
        }

        /// <summary>Process the "CalculateResult" button click event.</summary>
        /// <param name="sender">The event source.<see cref="System.Object"/></param>
        /// <param name="e">The event data.<see cref="RoutedEventArgs"/></param>
        private void CalculateResult_Click(object sender, RoutedEventArgs e)
        { CalculateResult_Action(sender); }

        /// <summary>The action for "CalculateResult" button click event.</summary>
        /// <param name="o">A parameter to use for any purpose.</param>
        public void CalculateResult_Action(object o)
        {
            if (!string.IsNullOrEmpty(_value) && !string.IsNullOrEmpty(Entry.Text))
            {
                int result = 0;
                string dTemp = Convert.ToString(Convert.ToInt32(Entry.Text, 2));
                _value = Convert.ToString(Convert.ToInt32(_value, 2));
                switch (_operator)
                {
                    case SecondArgumentAction.Add:
                        result = Convert.ToInt32(_value) + Convert.ToInt32(dTemp);
                        _operator = SecondArgumentAction.Clear;
                        break;
                    case SecondArgumentAction.Substract:
                        result = Convert.ToInt32(_value) - Convert.ToInt32(dTemp);
                        _operator = SecondArgumentAction.Clear;
                        break;
                }

                Entry.Text = Convert.ToString(result, 2);
                if (_operator == SecondArgumentAction.Clear)
                    Info.Text = "";
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-1]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
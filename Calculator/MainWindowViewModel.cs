using System;
using Xrw.Utils;
using Calculator.FrameworkExtensions;

namespace Calculator
{
    class MainWindowViewModel : ViewModelCore<MainWindow>
    {
        /// <summary>The currently entered value.</summary>
        private string _currentValue = "0";

        public RelayCommand NumberZero { get; private set; }
        public RelayCommand NumberOne { get; private set; }

        public RelayCommand CalculateSubtract { get; private set; }
        public RelayCommand CalculateAdd { get; private set; }
        public RelayCommand CalculateResult { get; private set; }

		/// <summary>Initializing constructor.</summary>
        public MainWindowViewModel()
            : base(MainWindow.Instance)
        {
            if (View == null)
                throw new NullReferenceException("MainWindowViewModel::ctr(): The 'View' property must not be null! Subsequent functionality depends on it.");
        
            NumberZero = new RelayCommand(View.NumberZero_Action);
            NumberOne = new RelayCommand(View.NumberOne_Action);

            CalculateSubtract = new RelayCommand(View.CalculateSubtract_Action);
            CalculateAdd = new RelayCommand(View.CalculateAdd_Action);
            CalculateResult = new RelayCommand(View.CalculateResult_Action);
        }

        /// <summary>Get or set the currently entered value.</summary>
        public string CurrentValue
        {
            get
            {
                return _currentValue;
            }
            set
            {   if (_currentValue == value)
                    return;
                
                _currentValue = value;
                RaisePropertyChanged("CurrentValue");
            }
        }


    }
}

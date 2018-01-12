using GalaSoft.MvvmLight.Command;
using LinesClaculatorBL;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows;

namespace LinesCalculator
{
    class FileCalculatorViewModel : INotifyPropertyChanged
    {
        public FileCalculatorViewModel()
        {
            m_fileCalculatorModel = new FileCalculatorModel();
            LoadFileCommand = new RelayCommand(LoadFile);
            CalculateCommand = new RelayCommand(Calculate);
        }

        private void LoadFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
                Path = ofd.FileName;
        }

        private async void Calculate()
        {
            try
            {
                var numberOfLines = await m_fileCalculatorModel.CalculateLines(Path);
            Result = PREFIX + numberOfLines;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Property for the Command. (RelayCommand is a helper class that wraps ICommand).
        public RelayCommand LoadFileCommand { get; set; }
        public RelayCommand CalculateCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private const string PREFIX = @"Total Number Of Lines: ";
        private FileCalculatorModel m_fileCalculatorModel;
        private string m_result;
        public string Result
        {
            get { return m_result; }
            set
            {
                m_result = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Result"));
            }
        }
        private string m_path;
        public string Path
        {
            get { return m_path; }
            set
            {
                m_path = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Path"));
            }
        }
    }
}

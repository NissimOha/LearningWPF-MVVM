using GalaSoft.MvvmLight.Command;
using LinesClaculatorBL;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Configuration;

namespace LinesCalculator.FolderCalculator
{
    class FolderCalculatorViewModel : INotifyPropertyChanged
    {
        public FolderCalculatorViewModel()
        {
            m_fileCalculatorModel = new FolderCalculatorModel();
            LoadFileCommand = new RelayCommand(LoadFile);
            CalculateCommand = new RelayCommand(Calculate);
            CheckChangeCommand = new RelayCommand(CheckChange);
            SelectedItemChangedCommand = new RelayCommand<object>(SelectedItemChanged);
            Formats = new ObservableCollection<string>();
            //Check if not in DesignMode
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                ReadFormatFromConfig();
        }

        private void ReadFormatFromConfig()
        {
            var formats = ConfigurationManager.AppSettings["FormatAllowed"].Split(',');
            foreach(var format in formats)
            {
                Formats.Add(format);
            }
        }

        private void LoadFile()
        {
            var cofd = new CommonOpenFileDialog();
            cofd.IsFolderPicker = true;
            CommonFileDialogResult result = cofd.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
                Path = cofd.FileName;
        }

        private async void Calculate()
        {
            try
            {
                var numberOfLines = await m_fileCalculatorModel.CalculateLines(Path, CheckedFormats, m_includeSubDirectories);
                Result = PREFIXRESULT + numberOfLines;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CheckChange()
        {
            m_includeSubDirectories = !m_includeSubDirectories;
        }

        private void SelectedItemChanged(object p_ob)
        {
            CheckedFormats = new List<string>();

            foreach(var format in p_ob as ObservableCollection<object>)
            {
                CheckedFormats.Add(PREFIXFORMAT + format.ToString());
            }
        }

        // Property for the Command. (RelayCommand is a helper class that wraps ICommand).
        public RelayCommand LoadFileCommand { get; set; }
        public RelayCommand CalculateCommand { get; set; }
        public RelayCommand CheckChangeCommand { get; set; }
        public RelayCommand<object> SelectedItemChangedCommand { get; set; }

        //Fields
        private const string PREFIXFORMAT = @"*.";
        private const string PREFIXRESULT = @"Total Number Of Lines: ";
        private FolderCalculatorModel m_fileCalculatorModel;
        private bool m_includeSubDirectories = false;
        public List<string> CheckedFormats { get; set; }
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
        private ObservableCollection<string> m_formats;
        public ObservableCollection<string> Formats
        {
            get { return m_formats; }
            set
            {
                m_formats = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Formats"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

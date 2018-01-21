using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using PhoneBook.Handlers;
using PhoneBookBL;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows;

namespace PhoneBook.ViewModel
{
    class AdditionViewModel : INotifyPropertyChanged
    {
        public AdditionViewModel()
        {
            SaveRecordCommand = new RelayCommand<Record>(saveRecord);
            CancleRecordCommand = new RelayCommand<object>(cancleRecord);
            ImportImageCommand = new RelayCommand(ImportImage);
            //Check if not in DesignMode
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                Image = ConfigurationManager.AppSettings["Import"];
        }

        private void saveRecord(Record p_record)
        {
            if(SaveRecordHendler.SaveRecord != null)
            {
                SaveRecordHendler.SaveRecord.Invoke(this, new SaveRecordEventArgs(p_record));
            }
        }

        private void cancleRecord(object p_ob)
        {
            Window window = p_ob as Window;
            if(window != null)
                window.Close();
        }

        private void ImportImage()
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = ofd.ShowDialog();
            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                Image = ofd.FileName;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand ImportImageCommand { get; set; }
        public RelayCommand<Record> SaveRecordCommand { get; set; }
        public RelayCommand<object> CancleRecordCommand { get; set; }
        private string m_id;
        public string Id
        {
            get { return m_id; }
            set
            {
                m_id = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Id"));
            }
        }
        private string m_image;
        public string Image
        {
            get { return m_image; }
            set
            {
                m_image = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Image"));
            }
        }
    }
}

using GalaSoft.MvvmLight.Command;
using PhoneBook.Handlers;
using PhoneBook.View;
using PhoneBookBL;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Windows;

namespace PhoneBook.ViewModel
{
    class RecordViewModel : INotifyPropertyChanged
    {
        public RecordViewModel()
        {
            AddRecordCommand = new RelayCommand(AddRecord);
            BeckUpRecordCommand = new RelayCommand(BeckUpRecord);
            DeleteRecordCommand = new RelayCommand<object>(DeleteItems);
            SaveRecordHendler.SaveRecord += onSaveRecord;
            m_recordRepository = new RecordRepository();
            //Check if not in DesignMode
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                Records = m_recordRepository.Retrive();
        }

        private async void onSaveRecord(object p_sender, SaveRecordEventArgs p_e)
        {
            if (p_e.Record.Image == ConfigurationManager.AppSettings["Import"])
                p_e.Record.Image = ConfigurationManager.AppSettings["NoImage"];
            p_e.Record.Id = RecordRepository.Length++.ToString();
            Records.Add(p_e.Record);
            Records = await m_recordRepository.SortRecords(Records);
        }

        private void AddRecord()
        {
            new AdditionView().ShowDialog();
        }

        private async void BeckUpRecord()
        {
            await m_recordRepository.BeckUpToDB(m_records);
        }

        private async void DeleteItems(object p_ob)
        {
            Records = await m_recordRepository.DeleteRecords(p_ob as ObservableCollection<object>, Records);
        }

        // Property for the Command. (RelayCommand is a helper class that wraps ICommand).
        public RelayCommand AddRecordCommand { get; set; }
        public RelayCommand BeckUpRecordCommand { get; set; }
        public RelayCommand<object> DeleteRecordCommand { get; set; }

        private RecordRepository m_recordRepository;
        private ObservableCollection<Record> m_records;
        public ObservableCollection<Record> Records
        {
            get { return m_records; }
            set
            {
                m_records = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Records"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

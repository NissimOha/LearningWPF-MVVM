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
            var result = MessageBox.Show(SAVE_MSG, string.Empty, MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                await m_recordRepository.BeckUpToDB(m_records);
                MessageBox.Show(SAVED_MSG, string.Empty, MessageBoxButton.OK);
            }
        }

        private async void DeleteItems(object p_ob)
        {
            if ((p_ob as ObservableCollection<object>).Count == 0) return;
            var result = MessageBox.Show(DELETE_MSG, string.Empty, MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Records = await m_recordRepository.DeleteRecords(p_ob as ObservableCollection<object>, Records);
                MessageBox.Show(DELETED_MSG, string.Empty, MessageBoxButton.OK);
            }
        }

        // Property for the Command. (RelayCommand is a helper class that wraps ICommand).
        public RelayCommand AddRecordCommand { get; set; }
        public RelayCommand BeckUpRecordCommand { get; set; }
        public RelayCommand<object> DeleteRecordCommand { get; set; }

        private const string SAVE_MSG = "?האם אתה בטוח שברצונך לשמור את השינויים";
        private const string DELETE_MSG = "?האם אתה בטוח שברצונך למחוק את אנשי הקשר המסומנים";
        private const string SAVED_MSG = "נשמר";
        private const string DELETED_MSG = "נמחק";

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

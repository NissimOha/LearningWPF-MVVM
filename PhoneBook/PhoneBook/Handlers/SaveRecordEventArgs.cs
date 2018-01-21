using PhoneBookBL;
using System;

namespace PhoneBook.Handlers
{
    public class SaveRecordEventArgs : EventArgs
    {
        public SaveRecordEventArgs(Record p_record)
        {
            Record = p_record;
        }

        public Record Record { get; private set; }
    }

    public static class SaveRecordHendler
    {
        public static EventHandler<SaveRecordEventArgs> SaveRecord;
    }
}

using GalaSoft.MvvmLight.Command;
using LoginProject.Model;
using System.ComponentModel;
using System.Configuration;
using System.Windows;

namespace LoginProject.ViewModel
{
    class ForgotPasswardViewModel : INotifyPropertyChanged
    {
        public ForgotPasswardViewModel()
        {
            RestorePasswordCommand = new RelayCommand(RestorePassword);
            m_userControl = new UserControl();
            //Check if not in DesignMode
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                initilaize();
        }

        private void initilaize()
        {
            Logo = ConfigurationManager.AppSettings["Logo"];
        }

        private async void RestorePassword()
        {
            Result = await m_userControl.RestorePassword(Id, UserName);
        }

        public RelayCommand RestorePasswordCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private UserControl m_userControl;
        private string m_logo;
        public string Logo
        {
            get { return m_logo; }
            set
            {
                m_logo = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Logo"));
            }
        }
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
        private string m_userName;
        public string UserName
        {
            get { return m_userName; }
            set
            {
                m_userName = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
            }
        }
    }
}

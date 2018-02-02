using GalaSoft.MvvmLight.Command;
using LoginProject.Model;
using LoginProjectBL;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Windows;

namespace LoginProject.ViewModel
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        public SignUpViewModel()
        {
            CloseCommand = new RelayCommand<object>(close);
            RegisterCommand = new RelayCommand<User>(register);
            m_userControl = new UserControl();
            IsEnable = true;

            //Check if not in DesignMode
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                initilaize();
        }

        private void initilaize()
        {
            Logo = ConfigurationManager.AppSettings["Logo"];
            var color = ConfigurationManager.AppSettings["IndicateAllRigthColor"];
            ValidationIndicate = new ObservableCollection<string>
            {
                color,color,color,color,color,color,color,color
            };
            ToolTipIndication = m_userControl.GetToolTipIndication(ValidationIndicate.Count);
        }

        private void close(object p_ob)
        {
            Window window = p_ob as Window;
            if (window != null)
                window.Close();
        }

        private async void register(User p_user)
        {
            ValidationIndicate = await m_userControl.UserValidate(p_user);
            var isValid = await m_userControl.Validate(ValidationIndicate);
            if (isValid)
            {
                IsEnable = false;
                await m_userControl.AddUser(p_user);
                MessageBox.Show(UserControl.REGISTER_SUCCESSED, UserControl.REGISTER_SUCCESSED_CAPTION, MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show(UserControl.REGISTER_ERROR, UserControl.REGISTER_ERROR_CAPTION, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public RelayCommand<object> CloseCommand { get; set; }
        public RelayCommand<User> RegisterCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private UserControl m_userControl;
        private bool m_isEnable;
        public bool IsEnable
        {
            get { return m_isEnable; }
            set
            {
                m_isEnable = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsEnable"));
            }
        }
        private ObservableCollection<string> m_toolTipIndication;
        public ObservableCollection<string> ToolTipIndication
        {
            get { return m_toolTipIndication; }
            set
            {
                m_toolTipIndication = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ToolTipIndication"));
            }
        }
        private ObservableCollection<string> m_validationIndicate;
        public ObservableCollection<string> ValidationIndicate
        {
            get { return m_validationIndicate; }
            set
            {
                m_validationIndicate = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ValidationIndicate"));
            }
        }
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
    }
}

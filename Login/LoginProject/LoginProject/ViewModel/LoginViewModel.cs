using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using GalaSoft.MvvmLight.Command;
using LoginProjectBL;
using LoginProject.Model;
using System.Windows;
using LoginProject.View;
using System.ComponentModel;

namespace LoginProject.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
            m_accountControl = new AccountControl();
            LoginCommand = new RelayCommand(login);
            SignUpCommand = new RelayCommand(signUp);
            ForgotPasswordCommand = new RelayCommand(forgotPassword);

            //Check if not in DesignMode
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                initilaize();
        }

        private async void initilaize()
        {
            Logo = ConfigurationManager.AppSettings["Logo"];
            var rememberMe = await m_accountControl.GetRememberMeAccount();
            IsRememberMe = true;
            UserName = rememberMe.UserName;
            Password = rememberMe.Password;
        }

        private async void login()
        {
            var account = new Account(UserName, Password);
            var isValid = await m_accountControl.LoginValidate(account);

            if (isValid)
            {
                if(IsRememberMe)
                    await m_accountControl.SetRememberMe(account);
                MessageBox.Show("התחבר בהצלחה", "ברכות", MessageBoxButton.OK);
            }
            else
                MessageBox.Show(AccountControl.LOGIN_ERROR, AccountControl.LOGIN_ERROR_CAPTION, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void signUp()
        {
            new SignUpView().ShowDialog();
        }

        private void forgotPassword()
        {
            new ForgotPasswardView().ShowDialog();
        }

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand SignUpCommand { get; set; }
        public RelayCommand ForgotPasswordCommand { get; set; }
        public RelayCommand RememberMeCommand { get; set; }

        private AccountControl m_accountControl;
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
        private bool m_isRememberMe;
        public bool IsRememberMe
        {
            get { return m_isRememberMe; }
            set
            {
                m_isRememberMe = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsRememberMe"));
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
        private string m_password;
        public string Password
        {
            get { return m_password; }
            set
            {
                m_password = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

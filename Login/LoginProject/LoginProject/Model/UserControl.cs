using LoginProjectBL;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Configuration;
using System.Text.RegularExpressions;

namespace LoginProject.Model
{
    internal class UserControl
    {
        private UserRepository m_userRepository;
        private string m_indicateErrorColor;
        private string m_indicateAllRigthColor;
        public static string REGISTER_ERROR;
        public static string REGISTER_ERROR_CAPTION;
        public static string REGISTER_SUCCESSED;
        public static string REGISTER_SUCCESSED_CAPTION;
        private const int MIN_LETTERS = 1;
        private const int MIN_LETTERS_USER_NAME = 5;
        private const int MIN_LETTERS_PASSWORD = 6;
        private const int PHONE_LENGTH = 10;
        private const int ID_LENGTH = 9;

        public UserControl()
        {
            m_userRepository = new UserRepository();
            REGISTER_ERROR = ConfigurationManager.AppSettings["REGISTER_ERROR"];
            REGISTER_ERROR_CAPTION = ConfigurationManager.AppSettings["REGISTER_ERROR_CAPTION"];
            REGISTER_SUCCESSED = ConfigurationManager.AppSettings["REGISTER_SUCCESSED"];
            REGISTER_SUCCESSED_CAPTION = ConfigurationManager.AppSettings["REGISTER_SUCCESSED_CAPTION"];
            m_indicateErrorColor = ConfigurationManager.AppSettings["IndicateErrorColor"];
            m_indicateAllRigthColor = ConfigurationManager.AppSettings["IndicateAllRigthColor"];
        }

        public async Task<bool> Validate(ObservableCollection<string> p_indicates)
        {
            return await Task.Run(() =>
            {
                foreach(var indicate in p_indicates)
                {
                    if (indicate == m_indicateErrorColor)
                        return false;
                }
                return true;
            });
        }

        public async Task<ObservableCollection<string>> UserValidate(User p_user)
        {
            return await Task.Run(async() =>
            {
                var colorIndicate = new ObservableCollection<string>();
                var isIdExist = await m_userRepository.CheckIfExist(p_user.Id);
                var isValid = !isIdExist;

                //validate UserId
                colorIndicate.Add(((p_user.Id.Length == ID_LENGTH) && isValid && p_user.Id != null) ? m_indicateAllRigthColor : m_indicateErrorColor);
                //validate FirstName + LastName
                colorIndicate.Add((Regex.IsMatch(p_user.FirstName, @"^[a-zA-Z]+$") && 
                    p_user.FirstName.Length > MIN_LETTERS && p_user.FirstName != null) ? m_indicateAllRigthColor : m_indicateErrorColor);
                colorIndicate.Add((Regex.IsMatch(p_user.LastName, @"^[a-zA-Z]+$") &&
                    p_user.LastName.Length > MIN_LETTERS && p_user.LastName != null) ? m_indicateAllRigthColor : m_indicateErrorColor);
                //validate Address
                colorIndicate.Add((Regex.IsMatch(p_user.Address, @"[a-zA-Z0-9\s]") &&
                    p_user.Address.Length > MIN_LETTERS && p_user.Address != null) ? m_indicateAllRigthColor : m_indicateErrorColor);
                //validate PhoneNumber
                colorIndicate.Add((Regex.IsMatch(p_user.PhoneNumber, @"^[0-9]+$") &&
                    p_user.PhoneNumber.Length == PHONE_LENGTH && p_user.PhoneNumber != null) ? m_indicateAllRigthColor : m_indicateErrorColor);
                //validate Email
                colorIndicate.Add((Regex.IsMatch(p_user.Email, @"^[a-zA-Z0-9_@.]+$") && p_user.Email != null) ?
                    m_indicateAllRigthColor : m_indicateErrorColor);
                //validate UserName
                colorIndicate.Add((Regex.IsMatch(p_user.Account.UserName, @"^[a-zA-Z0-9_]+$") &&
                    p_user.Account.UserName.Length >= MIN_LETTERS_USER_NAME) && p_user.Account.UserName != null ? m_indicateAllRigthColor : m_indicateErrorColor);
                //validate Password
                colorIndicate.Add((Regex.IsMatch(p_user.Account.Password, @"^[a-zA-Z0-9_]+$") &&
                    p_user.Account.Password.Length >= MIN_LETTERS_PASSWORD) && p_user.Account.Password != null ? m_indicateAllRigthColor : m_indicateErrorColor);
                return colorIndicate;
            });
        }

        public ObservableCollection<string> GetToolTipIndication(int p_size)
        {
            var toolTip = new ObservableCollection<string>();

            for(int i=0; i< p_size; i++)
            {
                var configStr = "ToolTip_" + i;
                toolTip.Add(ConfigurationManager.AppSettings[configStr]);
            }

            return toolTip;
        }

        public async Task AddUser(User p_user)
        {
            await Task.Run(() =>
            {
                m_userRepository.BackUp(p_user);
            });
        }

        public async Task<string> RestorePassword(string p_id, string p_un)
        {
            return await m_userRepository.RestorePassword(p_id, p_un);
        }
    }
}

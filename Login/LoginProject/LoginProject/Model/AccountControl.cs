using LoginProjectBL;
using System.Configuration;
using System.Threading.Tasks;

namespace LoginProject.Model
{
    internal class AccountControl
    {
        private AccountRepository m_accountRepository;
        public static string LOGIN_ERROR;
        public static string LOGIN_ERROR_CAPTION;

        public AccountControl()
        {
            m_accountRepository = new AccountRepository();
            LOGIN_ERROR = ConfigurationManager.AppSettings["LOGIN_ERROR"];
            LOGIN_ERROR_CAPTION = ConfigurationManager.AppSettings["LOGIN_ERROR_CAPTION"];
        }

        public async Task<Account> GetRememberMeAccount()
        {
            return await m_accountRepository.GetRememberMeAccount();
        }

        public async Task SetRememberMe(Account p_account)
        {
            await m_accountRepository.SetRememberMeAccount(p_account);
        }

        public async Task<bool> LoginValidate(Account p_account)
        {
            return await Task.Run(async () =>
            {
                return await m_accountRepository.CheckIfExist(p_account);
            });
        }
    }
}

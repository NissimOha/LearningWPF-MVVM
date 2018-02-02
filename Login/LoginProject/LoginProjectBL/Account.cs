namespace LoginProjectBL
{
    public class Account
    {
        public Account(string p_userName, string p_password)
        {
            UserName = p_userName;
            Password = p_password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

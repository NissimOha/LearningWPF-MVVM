namespace LoginProjectBL
{
    public class User
    {
        public User(string p_id, string p_fn, string p_ln, string p_address, string p_pn, string p_email, 
                                                                                string p_un, string p_pass)
        {
            Id = p_id;
            FirstName = p_fn;
            LastName = p_ln;
            Address = p_address;
            PhoneNumber = p_pn;
            Email = p_email;
            Account = new Account(p_un, p_pass);
        }

        public User(string p_id, string p_un, string p_pass)
        {
            Id = p_id;
            Account = new Account(p_un, p_pass);
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Account Account { get; set; }
    }
}

namespace PhoneBookBL
{
    public class Record
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        
        public Record(string p_id, string p_fName, string p_lName, string p_phoneNumber, string p_address, string p_image)
        {
            Id = p_id;
            FirstName = p_fName;
            LastName = p_lName;
            PhoneNumber = p_phoneNumber;
            Address = p_address;
            Image = p_image;
        }

        public Record() { }
    }
}

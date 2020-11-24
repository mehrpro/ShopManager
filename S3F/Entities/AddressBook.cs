using System.Collections.Generic;


namespace SPS.Entities
{
    public class AddressBook
    {
        public AddressBook()
        {
            Sellers = new HashSet<Seller>();
        }
        public int AddressBookId { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string MobileNumber1 { get; set; }
        public string MobileNumber2 { get; set; }
        public string FaxNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string EmailAddress { get; set; }
        public string WebSiteaAddress { get; set; }
        public string Description { get; set; }
        public string TelegramID { get; set; }
        public string InstagrameID { get; set; }




        public virtual ICollection<Seller> Sellers { get; set; }
    }
}
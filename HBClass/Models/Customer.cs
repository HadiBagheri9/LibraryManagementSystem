
namespace HB.Models
{
    public class Customer : IPerson
    {
        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public string GetBasicInfo()
        {
            string finalInfo;
            finalInfo = FirstName + " " + LastName +
                "\nTell : " + PhoneNumber +
                "\nAddress : " + Address;

            return finalInfo;
        }
    }
}


namespace HB.Models
{
    public interface IPerson
    {
        uint Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }

        string GetBasicInfo();
    }
}

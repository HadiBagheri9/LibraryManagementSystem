
namespace HB.Models
{
    public class Employee : IPerson
    {
        public uint Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Department Department { get; set; }
        public decimal BaseSalary { get; set; }

        public string GetBasicInfo()
        {
            string finalInfo;
            finalInfo = FirstName + " " + LastName +
                "\nTell : " + PhoneNumber +
                "\nAddress : " + Address +
                "\nDepartment : " + Department +
                "\nBase Salary : " + BaseSalary;

            return finalInfo;
        }
    }
    
    public enum Department
    {
        Production,
        Sales,
        Advertisement,
        Management
    }
}


namespace HB.Models
{
    public class Product : IProduct
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public short AvailableCount { get; set; }

        public string GetBasicInfo()
        {
            string info;
            info = Name +
                "\nAuthor : " + Author +
                "\nPrice : " + Price +
                "$\nAvailable Count : " + AvailableCount;

            return info;
        }
    }
}


namespace HB.Models
{
    public interface IProduct
    {
        uint Id { get; set; }
        string Name { get; set; }
        string Author { get; set; }
        decimal Price { get; set; }

        string GetBasicInfo();
    }
}

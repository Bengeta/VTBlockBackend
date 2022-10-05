using VTBlockBackend.Enums;

namespace VTBlockBackend.Responses;

public class MarketItemResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public MarketItemCategory Category { get; set; }
    public string ImageUrl { get; set; }
}
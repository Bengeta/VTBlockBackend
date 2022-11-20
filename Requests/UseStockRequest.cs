namespace VTBlockBackend.Requests;

public class UseStockRequest
{
    public int StockId { get; set; }
    public int Quantity { get; set; }
    public int WalletId { get; set; }
}
namespace VTBlockBackend.Requests;

public class StockRequest
{
    public string StockCode { get; set; }
    public string StockName { get; set; }
    public string StockType { get; set; }
    public string StockExchange { get; set; }
    public string StockCurrency { get; set; }
    public string StockCountry { get; set; }
}
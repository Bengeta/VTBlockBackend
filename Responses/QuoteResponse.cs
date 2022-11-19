namespace VTBlockBackend.Responses;

public class QuoteResponse
{
    public string date { get; set; }
    public Rates rates { get; set; }
    public bool success { get; set; }
    public string timestamp { get; set; }
        
}

public class Rates
{
    public double USD { get; set; }
    public double EUR { get; set; }
    public double RUB { get; set; }
}
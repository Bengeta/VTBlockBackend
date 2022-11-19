namespace VTBlockBackend.Requests;

public class PaymentRequest
{
    public int Amount { get; set; }
    public int IdFrom { get; set; }
    public int IdTo { get; set; }
}
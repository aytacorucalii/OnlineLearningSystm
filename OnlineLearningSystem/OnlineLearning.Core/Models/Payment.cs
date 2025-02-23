using OnlineLearning.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnlineLearning.Core.Models;
public class Payment
{
	public int Id { get; set; }

	[Range(0.01, double.MaxValue, ErrorMessage = "Məbləğ sıfırdan böyük olmalıdır.")]
	public decimal Amount { get; set; }
    public string Currency { get; set; }
    public string SuccessUrl { get; set; }
    public string CancelUrl { get; set; }
    public string SessionUrl { get; set; }
    public DateTime PaymentDate { get; set; }
	public PaymentStatus Status { get; set; }  // Ödənişin statusu
	public bool IsSuccessful { get; set; }     // Ödənişin nəticəsi
}

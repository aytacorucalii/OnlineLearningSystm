using OnlineLearning.Core.Enums;
using OnlineLearning.Core.Models.Base;

namespace OnlineLearning.Core.Models;

public class PaymentResult: BaseEntity
{
    public PaymentStatus Status { get; set; }
    public string? ErrorMessage { get; set; }  // Hər hansı bir səhv mesajı əlavə edə bilərik
}


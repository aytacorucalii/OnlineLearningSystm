using OnlineLearning.BL.DTOs;

namespace OnlineLearning.BL.Services.Abstractions;

public interface IPaymentService
{
	Task<List<PaymentDTO>> GetAllPaymentsAsync();
	Task<PaymentDTO> GetPaymentByIdAsync(int id);
	Task<PaymentDTO> CreatePaymentAsync(PaymentDTO paymentDto);
	Task UpdatePaymentStatusAsync(int id, bool status);
	Task<bool> DeletePaymentAsync(int id);
}

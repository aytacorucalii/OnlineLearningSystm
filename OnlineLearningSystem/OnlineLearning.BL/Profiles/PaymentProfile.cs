using AutoMapper;
using OnlineLearning.BL.DTOs;
using OnlineLearning.Core.Enums;
using OnlineLearning.Core.Models;

public class PaymentProfile : Profile
{
	public PaymentProfile()
	{
		// Enum'dan string'e dönüşüm (Payment -> PaymentDTO)
		CreateMap<Payment, PaymentDTO>()
			.ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

		// String'den Enum'a dönüşüm (PaymentDTO -> Payment)
		CreateMap<PaymentDTO, Payment>()
			.ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<PaymentStatus>(src.Status.ToString())));
	}
}

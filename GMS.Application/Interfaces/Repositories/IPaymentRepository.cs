using GMS.Domain.Entities;

namespace GMS.Application.Interfaces.Repositories;

public interface IPaymentRepository : IGenericRepository<Payment>
{
    Task<IEnumerable<Payment>> GetPaymentsByServiceOrderAsync(Guid serviceOrderId);
    Task<decimal> GetTotalPaidAmountAsync(Guid serviceOrderId);
}

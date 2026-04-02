using GMS.Application.Interfaces.Repositories;
using GMS.Domain.Entities;
using GMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GMS.Infrastructure.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Payment>> GetPaymentsByServiceOrderAsync(Guid serviceOrderId)
            => await _dbSet
                .Where(x => x.ServiceOrderId == serviceOrderId)
                .ToListAsync();

        public async Task<decimal> GetTotalPaidAmountAsync(Guid serviceOrderId)
            => await _dbSet
                .Where(x => x.ServiceOrderId == serviceOrderId)
                .SumAsync(x => x.Amount);
    }
}
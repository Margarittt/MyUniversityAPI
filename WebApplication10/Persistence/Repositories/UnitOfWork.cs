using System.Threading.Tasks;
using WebApplication10.Domain.Repositories;
using WebApplication10.Persistence.Context;

namespace WebApplication10.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
        {
            private readonly AppDbContext context;

            public UnitOfWork(AppDbContext context)
            {
                this.context = context;
            }

            public async Task CompleteAsync()
            {
                await context.SaveChangesAsync();
            }
        }
}

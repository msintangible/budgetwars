using Budget_wars.Database;
using Budget_wars.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Budget_wars.Servies.User.Queries
{
    public  static class GetExpenseUsers
    {
        public record Query(): IRequest<List<ExpenseUser>> {
            
        }

        public class Handler : IRequestHandler<Query, List<ExpenseUser>>
        {
            private readonly ApplicationDbContext _context;

            public Handler(ApplicationDbContext context) {
                _context = context;
            }
            public async Task<List<ExpenseUser>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _context.Set<ExpenseUser>().ToListAsync();

                return users;
            }
        }
    }
}

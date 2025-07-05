using Budget_wars.Database;
using Budget_wars.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Budget_wars.Servies.User.Queries
{
    public static  class GetByIdExpenseUser
    {
        public record Query(int id): IRequest<ExpenseUser>;


        public class Handler : IRequestHandler<Query, ExpenseUser>
        {

            private readonly ApplicationDbContext _context;
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }

            public Task<ExpenseUser> Handle(Query request, CancellationToken cancellationToken)
            {
                var entity = _context.Set<ExpenseUser>().FirstOrDefaultAsync( x => x.Id == request.id);
                
                 if (entity == null) {
                    return null;
                }
                return entity;


            }
        }
    }
}

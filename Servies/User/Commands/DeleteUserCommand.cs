using Budget_wars.Database;
using Budget_wars.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Budget_wars.Servies.User.Commands.DeleteUserCommand;

namespace Budget_wars.Servies.User.Commands
{
    public static class DeleteUserCommand
    {
        public record Command(int id) : IRequest<Response>;
    }

    public abstract record Response { 

        public  record Success : Response;

        public static Success MkSuccess() => new();

        public record NotFound : Response;

        public static NotFound MKNotFound() => new();

        public record UnknowError : Response;

        public static UnknowError mkUnknowError() => new();

    }


    public class Handler : IRequestHandler<Command, Response>

    {
        private readonly ApplicationDbContext _dbContext;

        public Handler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Set<ExpenseUser>().FirstOrDefaultAsync(x => x.Id == request.id);

            if (user == null) {
                return Response.MKNotFound();
            }

             _dbContext.Set<ExpenseUser>().Remove(user);
            await _dbContext.SaveChangesAsync();

            return Response.MkSuccess();

            
        }
    }
}

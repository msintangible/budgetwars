

using System.Reflection.Metadata;
using Budget_wars.Database;
using Budget_wars.Models;
using MediatR;
namespace Budget_wars.Servies.User.Commands

  
{
    public  static class CreateUser
    {

        //creating a user i need name 
        public record Command : IRequest<Response> {

            public string Name { get; set; }
            public string Email { get; set; }

            public string Password { get; set; }

        }

        public abstract record Response {
            
            public record Success(ExpenseUser usermodel) : Response;

            public static Success MkSuccess(ExpenseUser user) => new(user);

            public record UnkownError() : Response;

            public static UnkownError MkUnkownError() => new();

            public record  UnprocessEntity () : Response;

            public static UnprocessEntity MkUnprocessEntity() => new(); 

        }


        public class Handler : IRequestHandler<Command, Response>
        {
            public readonly ApplicationDbContext dbContext;

            public Handler(ApplicationDbContext _dbContext) { 
                dbContext = _dbContext;
            }


           public  async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = new ExpenseUser
                {
                    Name = request.Name,
                    Email = request.Email,
                    Password = request.Password,
                };
               await dbContext.Set<ExpenseUser>().AddAsync(entity);
                await dbContext.SaveChangesAsync();

                return Response.MkSuccess(entity);
            }
        }
    }
}

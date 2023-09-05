using DevFreela.Core.Entities;
using DevFreela.infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateUSer
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        public readonly DevFreelaDbContext _dbContext;

        public CreateUserCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.FullName, request.Email, request.BirthDate);
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}

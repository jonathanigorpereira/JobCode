using JobCode.Application.Models;
using JobCode.Core.Repositories;
using JobCode.Core.Services;
using MediatR;
using System.Diagnostics;

namespace JobCode.Application.Commands.InsertUser
{
    public class InsertUserHandler(IUserRepository repository, IEncryptionService encryptionService) : IRequestHandler<InsertUserCommand, Result<int>>
    {
        private readonly IUserRepository _repository = repository;
        private readonly IEncryptionService _encryptionService = encryptionService;

        public async Task<Result<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return Result<int>.Failure("Não foram fornecidos dados para registrar o usuário.");



            var passwordHash = _encryptionService.EncryptingHash(request.Password);
            request.SetPassword(passwordHash);

            var user = request.ToEntity();

            user.SetAddress(request.Address);
   
            bool exists = await _repository.ExistUserAsync(user, cancellationToken);

            if (exists)
                return Result<int>.Failure("Usuário já cadastrado.");

            var result = await _repository.AddAsync(user, cancellationToken);

            return Result<int>.Success(result,"Usuário cadastrado com sucesso!");
        }
    }
}

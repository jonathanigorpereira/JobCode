using AutoMapper;
using JobCode.Application.Result;
using JobCode.Core.Entities;
using JobCode.Core.Enums;
using JobCode.Core.Repositories;
using JobCode.Core.Services;
using MediatR;

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

            var userT = request.ToEntity();

            userT.SetAddress(request.Address);

            var result = await _repository.AddAsync(userT, cancellationToken);

            return Result<int>.Success(result);
        }
    }
}

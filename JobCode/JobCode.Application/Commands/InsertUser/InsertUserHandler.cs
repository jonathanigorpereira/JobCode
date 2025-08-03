using JobCode.Application.Models;
using JobCode.Core.Repositories;
using JobCode.Core.Services;
using FluentValidation;
using MediatR;

namespace JobCode.Application.Commands.InsertUser
{
    public class InsertUserHandler(IUserRepository repository, IEncryptionService encryptionService, IValidator<UserModel> validator) : IRequestHandler<InsertUserCommand, Result<int>>
    {
        private readonly IUserRepository _repository = repository;
        private readonly IEncryptionService _encryptionService = encryptionService;
        private readonly IValidator<UserModel> _validator = validator;

        public async Task<Result<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return Result<int>.Failure("Não foram fornecidos dados para registrar o usuário.");

            // Convert command to model for validation
            var userModel = new UserModel(
                request.FirstName,
                request.LastName,
                request.BirthDate,
                request.Email,
                request.Password,
                request.UserType,
                request.Active,
                request.Address != null ? new AddressModel(
                    request.Address.PostalCode,
                    request.Address.Avenue,
                    request.Address.Street,
                    request.Address.District,
                    request.Address.LocalNumber,
                    "", // Complement as string (there's a mismatch between entity and model)
                    request.Address.City,
                    request.Address.State,
                    request.Address.Country
                ) : null
            );

            // Validate the user model
            var validationResult = await _validator.ValidateAsync(userModel, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return Result<int>.Failure($"Dados inválidos: {errors}");
            }

            var passwordHash = _encryptionService.EncryptingHash(request.Password);
            request.SetPassword(passwordHash);

            var user = request.ToEntity();
            
            if (request.Address != null)
            {
                user.SetAddress(request.Address);
            }
   
            bool exists = await _repository.ExistUserAsync(user, cancellationToken);

            if (exists)
                return Result<int>.Failure("Usuário já cadastrado.");

            var result = await _repository.AddAsync(user, cancellationToken);

            return Result<int>.Success(result,"Usuário cadastrado com sucesso!");
        }
    }
}

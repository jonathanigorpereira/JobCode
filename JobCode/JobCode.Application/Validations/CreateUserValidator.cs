using FluentValidation;
using JobCode.Application.Models;
using JobCode.Core.Enums;

namespace JobCode.Application.Validations;

public class CreateUserValidator : AbstractValidator<UserModel>
{
    public CreateUserValidator()
    {
        RuleFor(u => u.FirstName)
            .NotEmpty()
                .WithMessage("O nome é obrigatório")
            .Matches(@"^[A-ZÀ-Ú][a-zA-Zà-úÀ-Ú]*$")
                .WithMessage("O nome deve começar com letra maiúscula e conter apenas letras")
            .MaximumLength(50)
                .WithMessage("O nome deve conter no máximo 50 caracteres");

        RuleFor(u => u.LastName)
            .NotEmpty()
                .WithMessage("O sobrenome é obrigatório")
             .Matches(@"^[A-ZÀ-Ú][a-zA-Zà-úÀ-Ú]*$")
                    .WithMessage("O sobrenome deve começar com letra maiúscula e conter apenas letras")
            .MaximumLength(80)
                .WithMessage("O sobrenome deve conter no máximo 80 caracteres");

        RuleFor(u => u.Email)
           .EmailAddress()
               .WithMessage("E-mail inválido");

        RuleFor(u => u.Password)
            .NotEmpty()
                .WithMessage("A senha é obrigatória")
            .MinimumLength(8)
                .WithMessage("A senha deve conter no mínimo 8 caracteres")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                .WithMessage("A senha deve conter pelo menos uma letra minúscula, uma maiúscula, um número e um caractere especial");

        RuleFor(U => U.Address)
            .NotNull()
                .WithMessage("O endereço é obrigatório")
            .When(u => u.UserType == UserType.Candidate);

        RuleFor(u => u.Address)
          .SetValidator(new AddressValidator()!)
          .When(u => u.UserType == UserType.Candidate && u.Address != null);
    }

}


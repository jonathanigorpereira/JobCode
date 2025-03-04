using FluentValidation;
using FluentValidation.AspNetCore;
using JobCode.Application.Models;

namespace JobCode.Application.Validations;

public class AddressValidator : AbstractValidator<AddressModel>
{
    public AddressValidator()
    {
        RuleFor(a => a.PostalCode)
            .Matches(@"^[0-9]{8}$")
                .When(a => !string.IsNullOrEmpty(a.PostalCode))
                    .WithMessage("O CEP deve conter apenas números")
            .Length(8)
                .WithMessage("O CEP deve conter 8 caracteres");

        RuleFor(a => a.Avenue)
            .MaximumLength(100)
                .WithMessage("A avenida deve conter no máximo 100 caracteres");

        RuleFor(a => a.Country)
            .MaximumLength(100)
                .WithMessage("O país deve conter no máximo 100 caracteres");

        RuleFor(a => a.District)
            .MaximumLength(80)
                .WithMessage("O bairro deve conter no máximo 80 caracteres");

        RuleFor(a => a.Street)
            .MaximumLength(100)
                .WithMessage("A rua deve conter no máximo 100 caracteres");

        RuleFor(a => a.LocalNumber)
            .LessThanOrEqualTo(9999)
                .WithMessage("O número local deve ser menor ou igual a 9999");

        RuleFor(a => a.Complement)
           .Length(10)
                .WithMessage("O complemento deve conter no máximo 10 caracteres");

        RuleFor(a => a.City)
          .MaximumLength(100)
              .WithMessage("A cidade deve conter no máximo 100 caracteres");

        RuleFor(a => a.State)
            .Length(2)
                .WithMessage("O estado deve conter 2 caracteres");
    }
}


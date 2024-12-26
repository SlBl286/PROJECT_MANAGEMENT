using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using PM.Application.Authentication.Commands.Register;

namespace PM.Application.Authentication.Commands.Register;

public class RegisterCommandValidatior : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidatior()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Password).MinimumLength(8);

    }
}
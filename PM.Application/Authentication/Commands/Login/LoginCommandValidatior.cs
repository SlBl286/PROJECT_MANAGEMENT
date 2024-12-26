
using FluentValidation;

namespace PM.Application.Authentication.Commands.Login;

public class LoginCommandValidatior : AbstractValidator<LoginCommand>
{
    public LoginCommandValidatior()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage("Tên người dùng không được bỏ trống");
        RuleFor(x => x.Password).NotEmpty();
    }
}

using FluentValidation;

namespace PM.Application.Authentication.Commands.Refresh;

public class RefreshQueryValidatior : AbstractValidator<RefreshCommand>
{
    public RefreshQueryValidatior()
    {
    }
}
using Mapster;
using PM.Application.Authentication.Commands.Login;
using PM.Application.Authentication.Commands.Refresh;
using PM.Application.Authentication.Commands.Register;
using PM.Application.Authentication.Common;
using PM.Presentation.Authentication;

namespace PM.WebApi.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginCommand>();
        config.NewConfig<RefreshRequest, RefreshCommand>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest.RefreshToken, src => src.User.RefreshToken.Value);
    }
}

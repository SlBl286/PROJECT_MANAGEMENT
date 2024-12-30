using Mapster;
using PM.Application.Users.Common;
using PM.Application.Users.Queries.GetUser;
using PM.Application.Users.Queries.GetUsers;
using PM.Presentation.User;

namespace PM.WebApi.Mapping;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Guid, GetUserQuery>()
            .Map(dest => dest.Id, src => src);
        config.NewConfig<Guid, GetUsersQuery>()
       .Map(dest => dest.Id, src => src);
        config.NewConfig<UserResult, UserResponse>()
                .Map(dest => dest, src => src.User)
                .Map(dest => dest.Id, src => src.User.Id.Value);
        config.NewConfig<UsersResult, UsersResponse>()
    .Map(dest => dest, src => src)
    .Map(dest => dest.Users, src => src.Users);
    }
}

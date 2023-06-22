using FSH.WebApi.Application.BaseService;
using FSH.WebApi.Application.Identity.Users;
using FSH.WebApi.Domain.Identity;

namespace FSH.WebApi.Host.Controllers.Identity;

public class UsersCrudController: CrudController<UserDetailsDto, CreateUserRequest, UpdateUserRequest, ApplicationUser>
{
    public UsersCrudController(IBaseService<UserDetailsDto, CreateUserRequest, UpdateUserRequest, ApplicationUser> _baseService) : base(_baseService)
    {
    }
}
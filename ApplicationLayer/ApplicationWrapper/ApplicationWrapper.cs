using InfrastructureLayer;

namespace ApplicationLayer;

public sealed class ApplicationWrapper : IApplicationWrapper
{
    private readonly IRepositoryWrapper _repository;
    private readonly Lazy<IUserService> _userService;

    public ApplicationWrapper(IRepositoryWrapper repository)
    {
        _repository = repository;
        _userService = new(() => new UserService(_repository));
    }
    public IUserService userService => _userService.Value;
}

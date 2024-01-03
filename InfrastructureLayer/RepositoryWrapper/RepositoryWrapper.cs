using InfrastructureLayer;

namespace InfrastructureLayer;

public sealed class RepositoryWrapper : IRepositoryWrapper
{
    private readonly RepositoryContext _context;
    private readonly Lazy<IUserRepo> _userRepo;

    public RepositoryWrapper(RepositoryContext context)
    {
        _context = context;
        _userRepo = new(() => new UserRepo(_context));
    }
    public IUserRepo userRepo => _userRepo.Value;
}

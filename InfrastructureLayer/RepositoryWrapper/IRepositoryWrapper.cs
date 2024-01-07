using InfrastructureLayer;

namespace InfrastructureLayer;

public interface IRepositoryWrapper
{
    IUserRepo userRepo { get; }
    Task<int> SaveAsync();

}

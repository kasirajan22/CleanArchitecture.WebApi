using InfrastructureLayer;

namespace ApplicationLayer;

public interface IRepositoryWrapper
{
    IUserRepo userRepo { get; }

}

using DomainLayer;
using InfrastructureLayer;
using PresentationLayer;

namespace ApplicationLayer;

public class UserService : ApplicationBase, IUserService
{
    public UserService(IRepositoryWrapper repository) : base(repository)
    {
        
    }
    public async Task<Response> SignUpAsync(SignUpRequestDto requestDto, Header header)
    {
        return new Response();
    }
}

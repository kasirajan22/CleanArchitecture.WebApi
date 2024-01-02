using DomainLayer;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer;

public class UserRepo : RepositoryBase<User>, IUserRepo
{
    public UserRepo(RepositoryContext context) : base(context) { }
   public async Task<User?> GetAsync(Guid? id = null, string? userName = "")
    {
        return await FindByCondition(u => u.Id.Equals(id) ||
        u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync();
    }
    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await FindByCondition(u => u.Id.Equals(id)).FirstOrDefaultAsync();
    }
}

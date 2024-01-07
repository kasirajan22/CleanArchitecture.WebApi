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
        var user = await _repository.userRepo.GetAsync(userName: requestDto.UserName);
        if (user is null)
        {
            int lastUserID = await _repository.userRepo.GetLatestUserIdAsync();
            string newUserID = lastUserID == 0 ? "1001" : (lastUserID + 1).ToString();

            var newUser = new User
            {
                NameIdentifier = "EMP" + newUserID.ToString(),
                UserName = requestDto.UserName,
                FirstName = requestDto.FirstName,
                LastName = requestDto.LastName,
                Password = SecurityManager.HashPassword(requestDto.Password),
            };
            _repository.userRepo.Create(newUser);
            await _repository.SaveAsync();
            return Response.Success("User added sucessfully!");
        }
        else
        {
            return Response.Failure("User already exist.");
        }
    }
}

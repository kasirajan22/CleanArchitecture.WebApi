using PresentationLayer;

namespace ApplicationLayer;

public interface IUserService
{
    Task<Response> SignUpAsync(SignUpRequestDto requestDto, Header header);
}

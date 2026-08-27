namespace ServiceImplementation;
public class AuthenticationService(UserManager<ApplicationUser> userManager, IMapper mapper) 
    : IAuthenticationService
{
    public async Task<UserDto> LoginAsync(LoginDto loginDto)
    {
        var User = await userManager.FindByEmailAsync(loginDto.Email) ??
            throw new UserNotFoundException(loginDto.Email);
        var IsPasswordValid = await userManager.CheckPasswordAsync(User, loginDto.Password);
        if (IsPasswordValid)
            return new UserDto
            {
                DisplayName = User.DisplayName,
                Email = loginDto.Email,
                Token = await CreateTokenAsync(User)
            }; 
        else
            throw new UnauthorizedException();
    }   

    public async Task<UserDto> Register(RegisterDto registerDto)
    {
        var User = new ApplicationUser()
        {
            DisplayName = registerDto.DisplayName,
            Email = registerDto.Email,
            PhoneNumber = registerDto.PhoneNumber,
            UserName = registerDto.UserName,
        };
        IdentityResult? identityResult = await userManager.CreateAsync(User,registerDto.Password);
        if (identityResult.Succeeded)
        {
            return new UserDto()
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                Token = await CreateTokenAsync(User)
            };
        }
        var errors = identityResult.Errors.Select(e => e.Description).ToList();
        throw new BadRequestException(errors);
    }

    private static async Task<string> CreateTokenAsync(ApplicationUser user)
    {
        return "Created Token";
    }
}

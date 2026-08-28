using Microsoft.EntityFrameworkCore;
namespace ServiceImplementation;
public class AuthenticationService(
    UserManager<ApplicationUser> userManager,
    IConfiguration configuration,
    IMapper mapper) : IAuthenticationService
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
        IdentityResult? identityResult = await userManager.CreateAsync(User, registerDto.Password);
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

    public async Task<bool> CheckEmailAsync(string Email)
    {
        var user =await userManager.FindByEmailAsync(Email);        
        return user is not null;
    }

    public async Task<UserDto> GetCurrentUserAsync(string Email)
    {
        var user = await userManager
            .FindByEmailAsync(Email) ?? throw new UserNotFoundException(Email);
        return new UserDto()
        {
            DisplayName = user.DisplayName,
            Email = user.Email,
            Token = await CreateTokenAsync(user)
        };
    }

    public async Task<AddressDto> GetCurrentUserAddressAsync(string Email)
    {
        var user = await userManager.Users
            .Include(u=>u.Address)
            .FirstOrDefaultAsync(U=>U.Email==Email) ?? throw new UserNotFoundException(Email);
        return mapper.Map<Address, AddressDto>(user.Address) 
            ?? throw new AddressNotFoundException(user.UserName);
    } 

    public async Task<AddressDto> UpdateCurrentUserAddressAsync(AddressDto UpdatedAddress, string Email)
    {
        var user = await userManager.Users
           .Include(u => u.Address)
           .FirstOrDefaultAsync(U => U.Email == Email) ?? throw new UserNotFoundException(Email);
        if (user.Address is null) 
        {
            user.Address = mapper.Map<AddressDto,Address>(UpdatedAddress);
        }
        user.Address.FirstName = UpdatedAddress.FirstName;
        user.Address.LastName = UpdatedAddress.LastName;
        user.Address.Street = UpdatedAddress.Street;
        user.Address.City = UpdatedAddress.City;
        user.Address.Country = UpdatedAddress.Country;

        await userManager.UpdateAsync(user);
        return mapper.Map<AddressDto>(user.Address);
    }

    private async Task<string> CreateTokenAsync(ApplicationUser user)
    {
        var Claims = new List<Claim>()
        {
            new (ClaimTypes.Email, user.Email!),
            new (ClaimTypes.Name, user.UserName!),
            new (ClaimTypes.NameIdentifier, user.Id!)            
        };
        var Roles = await userManager.GetRolesAsync(user);
        foreach (var role in Roles)
        {
            Claims.Add(new(ClaimTypes.Role, role!));
        }

        var SecretKey = configuration.GetSection("JWTOptions")["SecretKey"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        var credintial = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
        var Token = new JwtSecurityToken
            (
            issuer : configuration.GetSection("JWTOptions")["Issuer"],
            audience : configuration["JWTOptions:Audience"],
            claims : Claims,
            expires : DateTime.UtcNow.AddHours(1),
            signingCredentials: credintial
            );
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken( Token );
    }
}

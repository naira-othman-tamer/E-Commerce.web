namespace Domain.Exceptions;
public sealed class UnauthorizedException(string Message = " Invalid Email or Password") 
    : Exception (Message)
{
}

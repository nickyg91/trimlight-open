namespace Trimlight.Integration.Authentication;

public interface ITrimlightTokenService
{
    string GetToken(long timestamp);
}
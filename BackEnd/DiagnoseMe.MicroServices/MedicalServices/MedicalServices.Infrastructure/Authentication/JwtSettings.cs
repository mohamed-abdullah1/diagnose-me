namespace MedicalServices.Infrastructure.Authentication;

public class JwtSettings
{
    public string Key { get; init; } = null!;
    public string Issuer { get; init; } = null!;
    public string Audience { get;  init;} = null!;
    public int ExpiryHours { get ; init;} 
}
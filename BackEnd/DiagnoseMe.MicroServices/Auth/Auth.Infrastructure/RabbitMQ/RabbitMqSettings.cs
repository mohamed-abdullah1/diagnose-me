namespace Auth.Infrastructure.RabbitMQ;

public class RabbitMqSettings
{
    public string Host { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; }    = null!;
    public string VirtualHost { get; set; } = null!;
    public int Port { get; set; }   
}
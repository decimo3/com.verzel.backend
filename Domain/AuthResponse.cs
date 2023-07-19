namespace Teste.Domain;
public class AuthResponse : Entity
{
  public string User { get; set; }
  public string Token { get; set; }
  public string Role { get; set; }
  public AuthResponse() {}
  public AuthResponse(string usuario, string token, string role)
  {
    this.User = usuario;
    this.Token = token;
    this.Role = role;
  }
}
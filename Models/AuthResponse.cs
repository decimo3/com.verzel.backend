namespace backend.Models;
public class AuthResponse
{
  public string usuario { get; set; }
  public string token { get; set; }
  public Role role { get; set; }
  public AuthResponse(string usuario, string token, Role role)
  {
    this.usuario = usuario;
    this.token = token;
    this.role = role;
  }
}
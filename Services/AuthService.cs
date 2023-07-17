namespace backend.Services;
using backend.Models;
public class AuthService
{
  private readonly DatabaseContext dbContext;
  private readonly string segredo = System.Environment.GetEnvironmentVariable("SECRET_KEY")!;
  public AuthService(DatabaseContext dbContext)
  {
    this.dbContext = dbContext;
  }
  private string generateJwtToken(User user)
  {
    var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
    var key = System.Text.Encoding.ASCII.GetBytes(segredo);
    var symmetricKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key);
    var clainUser = new System.Security.Claims.Claim("usuario", user.usuario);
    var clainRole = new System.Security.Claims.Claim("role", user.role.ToString());
    var claims = new[] { clainUser, clainRole };
    var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
    {
      Subject = new System.Security.Claims.ClaimsIdentity(claims),
      Expires = DateTime.UtcNow.AddDays(7),
      SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(symmetricKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }
  public AuthResponse? Authenticate(User user)
  {
    try
    {
      var _user = (from u in dbContext.User where (u.usuario == user.usuario && u.palavra == user.palavra) select u).Single();
      var token = generateJwtToken(_user);
      return new AuthResponse(_user.usuario!, token, _user.role);
    }
    catch
    {
      return null;
    }
  }
}
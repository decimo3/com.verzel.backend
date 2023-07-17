namespace backend.Services;
using backend.Models;
public class AuthMiddleware
{
  private readonly RequestDelegate request;
  
  private readonly string segredo = System.Environment.GetEnvironmentVariable("SECRET_KEY")!;
  public AuthMiddleware(RequestDelegate request)
  {
    this.request = request;
  }


  private void attachUserToContext(HttpContext context, string token)
  {
    try
    {
      var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
      var key = System.Text.Encoding.ASCII.GetBytes(segredo);
      tokenHandler.ValidateToken(token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false,
          ClockSkew = TimeSpan.Zero
        }, out Microsoft.IdentityModel.Tokens.SecurityToken validatedToken);
        var jwtToken = (System.IdentityModel.Tokens.Jwt.JwtSecurityToken)validatedToken;
        var userId = jwtToken.Claims.First(x => x.Type == "usuario").Value;
        if(Enum.TryParse(jwtToken.Claims.First(x => x.Type == "role").Value, out Models.Role r)) 
          throw new IndexOutOfRangeException("The reported role is not in the list");
        context.Items["User"] = new AuthResponse(userId, jwtToken.ToString(), r);
    }
    catch
    {
      return;
    }
  }
  public async Task Invoke(HttpContext context)
  {
    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
    if (token != null) attachUserToContext(context, token);
    await request(context);
  }

}
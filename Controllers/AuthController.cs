using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.Models;
namespace backend.Controllers;
[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
  private readonly DatabaseContext dbContext;
  private readonly AuthService auth;
  public AuthController(DatabaseContext _dbContext, AuthService _auth)
  {
    dbContext = _dbContext;
    auth = _auth;
  }
  [HttpPost]
  public ActionResult<AuthResponse> Post(User user)
  {
    try
    {
      var _user = dbContext.User.Find(user.usuario);
      if (_user is null) return Forbid();
      var liberacao = auth.Authenticate(_user);
      if(liberacao is null) return Forbid();
      return liberacao;
    }
    catch (Exception erro)
    {
      return Problem(erro.Message);
    }
  }
}
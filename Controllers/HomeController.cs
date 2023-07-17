using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.Models;
namespace backend.Controllers;
[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
  private readonly DatabaseContext dbContext;
  public HomeController(DatabaseContext _dbContext)
  {
    dbContext = _dbContext;
  }
  [HttpGet]
  public ActionResult<IEnumerable<Carro>> Get()
  {
    if(dbContext.Carro == null) return NotFound();
    return (from f in dbContext.Carro orderby f.Valor descending select f).ToList();
  }
  [HttpGet("{id}")]
  [AdministratorAuthorize]
  public ActionResult<Carro> Get(int id)
  {
    var carro = dbContext.Carro.Find(id);
    if(carro == null) return NotFound();
    return carro;
  }
  [HttpPost]
  public ActionResult Post([Bind("Nome,Marca,Foto")] Carro carro)
  {
    if(!ModelState.IsValid) return BadRequest();
    try
    {
      dbContext.Carro.Add(carro);
      dbContext.SaveChanges();
      return Created(carro.Id.ToString(), carro);
    }
    catch (Exception erro)
    {
      return Problem(erro.Message);
    }
  }
  [HttpPut("{id}")]
  public ActionResult Put(int id, [Bind("Nome,Marca,Foto")] Carro carro)
  {
    if(!ModelState.IsValid) return BadRequest();
    try
    {
      var _carro = dbContext.Carro.Find(id);
      if(_carro is null) return NotFound();
      _carro.Nome = carro.Nome;
      _carro.Marca = carro.Marca;
      _carro.Foto = carro.Foto;
      _carro.Valor = carro.Valor;
      dbContext.SaveChanges();
      return Ok();
    }
    catch (Exception erro)
    {
      return Problem(erro.Message);
    }
  }
  [HttpDelete("{id}")]
  public ActionResult Delete(int id)
  {
    try
    {
      var carro = dbContext.Carro.Find(id);
      if(carro == null) return NotFound();
      dbContext.Carro.Remove(carro);
      dbContext.SaveChanges();
      return NoContent();
    }
    catch (Exception erro)
    {
      return Problem(erro.Message);
    }
  }
}

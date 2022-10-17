using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.api.net.Datas;
using RAS.Bootcamp.api.net.Datas.Entities;

namespace RAS.Bootcamp.api.net.Controllers;

[ApiController]
[Route("[controller]")]
public class PenjualController : ControllerBase
{
    private readonly TarajuMartContext _DbContext;
    public PenjualController(TarajuMartContext DbContext){
        _DbContext = DbContext;
    }

    [HttpGet]
    public IActionResult product(){
        var pnjl = _DbContext.Penjuals.ToList();
        return Ok(pnjl);
    }

    [HttpPost]
    public IActionResult Create(RequestPenjual request)
    {
        var penjual = new Penjual()
        {
            IdUser = request.IdUser,
            NamaToko = request.NamaToko,
            Alamat = request.Alamat,
        };

        _DbContext.Penjuals.Add(penjual);
        _DbContext.SaveChanges();
        return Created("",penjual);

    } 

    [HttpGet("{id}")]
    public IActionResult Details(int id)
    {
        var pnjl = _DbContext.Penjuals.FirstOrDefault(x => x.IdPenjual == id);
        return Ok(pnjl);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, RequestPenjual request)
    {
        var penjual = _DbContext.Penjuals.FirstOrDefault(y => y.IdPenjual == id);
        if(penjual == null)
        {
            return NotFound();
        }
        {
            penjual.IdUser = request.IdUser;
            penjual.NamaToko = request.NamaToko;
            penjual.Alamat = request.Alamat;
            _DbContext.SaveChanges();
            return Ok(penjual);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult delete(int id)
    {
        var penjual = _DbContext.Penjuals.FirstOrDefault(y => y.IdPenjual == id);
        _DbContext.Penjuals.Remove(penjual);
        _DbContext.SaveChanges();
        return Ok(penjual);
    }

}
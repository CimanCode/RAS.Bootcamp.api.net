using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.api.net.Datas;
using RAS.Bootcamp.api.net.Datas.Entities;

namespace RAS.Bootcamp.api.net.Controllers;

[ApiController]
[Route("[controller]")]
public class PembeliController : ControllerBase
{
    private readonly TarajuMartContext _DbContext;
    public PembeliController(TarajuMartContext DbContext){
        _DbContext = DbContext;
    }

    [HttpGet]
    public IActionResult Pembeli(){
        var pmbl = _DbContext.Pembelies.ToList();
        return Ok(pmbl);
    }

    [HttpPost]
    public IActionResult create(RequestPembeli request)
    {
    var pembelis = new Pembely()
    {
        IdUser = request.IdUser,
        Nama = request.Nama,
        NoHandPhone = request.NoHandPhone,
        Alamat = request.Alamat,
    };

    _DbContext.Pembelies.Add(pembelis);
    _DbContext.SaveChanges();
    return Ok(pembelis);

    }

    [HttpGet("{id}")]

    public IActionResult details(int id)
    {
        var pembelis = _DbContext.Pembelies.FirstOrDefault(j => j.IdPembeli == id);
        return Ok(pembelis);
    }

    [HttpPut("{id}")]
    public IActionResult update(int id, RequestPembeli request)
    {
        var pembelis = _DbContext.Pembelies.FirstOrDefault(j => j.IdPembeli == id);

            if(pembelis == null)
            {
                return NotFound();
            }
            {
                pembelis.IdUser = request.IdUser;
                pembelis.Nama = request.Nama;
                pembelis.NoHandPhone = request.NoHandPhone;
                pembelis.Alamat = request.Alamat;
                _DbContext.SaveChanges();
                return Ok(pembelis);
            }
    }

    [HttpDelete("{id}")]
    public IActionResult delete(int id)
    {
        var pembelis = _DbContext.Pembelies.FirstOrDefault(j => j.IdPembeli == id);
        _DbContext.Pembelies.Remove(pembelis);
        _DbContext.SaveChanges();
        return Ok(pembelis);
    }
    


}
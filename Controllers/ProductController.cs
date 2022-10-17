using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.api.net.Datas;
using RAS.Bootcamp.api.net.Datas.Entities;

namespace RAS.Bootcamp.api.net.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly TarajuMartContext _DbContext;
    public ProductController(TarajuMartContext DbContext){
        _DbContext = DbContext;
    }

    [HttpGet]
    public IActionResult product(){
        var products = _DbContext.Barangs.ToList();
        return Ok(products);
    }

    [HttpPost]

    public IActionResult Create(RequestBarang request)
    {
        var barangs = new Barang()
        {
            Code = request.Code,
            Nama = request.Nama,
            Description = request.Description,
            Harga = request.Harga,
            Stok = request.Stok,
            IdPenjual = request.IdPenjual,
            
        };

        _DbContext.Barangs.Add(barangs);
        _DbContext.SaveChanges();
        return Created("",barangs);

    }

    [HttpGet("{id}")]
    public IActionResult Review(int id)
    {
        var product = _DbContext.Barangs.FirstOrDefault(x => x.IdBarang == id);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, RequestBarang request)
    {
        var barang = _DbContext.Barangs.FirstOrDefault(x => x.IdBarang == id);
        if (barang == null)
        {
            return NotFound();
        }
        {
            barang.Code = request.Code;
            barang.Nama = request.Nama;
            barang.Description = request.Description;
            barang.Harga = request.Harga;
            barang.Stok = request.Stok;
            barang.IdPenjual = request.IdPenjual;
            _DbContext.SaveChanges();
            return Ok(barang);
        };
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _DbContext.Barangs.FirstOrDefault(x => x.IdBarang == id);
        _DbContext.Barangs.Remove(product);
        _DbContext.SaveChanges();
        return Ok(product);
    }
}
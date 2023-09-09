using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;


        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]

        public async Task Get()
        {
         //await   _productWriteRepository.AddRangeAsync(new()
         //   {
         //       new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 100,CreatedDate =DateTime.UtcNow ,Stock = 10 },
         //       new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 200,CreatedDate =DateTime.UtcNow ,Stock = 10 },
         //       new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 300, CreatedDate =DateTime.UtcNow,Stock = 10 },
         //       new() { Id = Guid.NewGuid(), Name = "Product 4", Price = 400, CreatedDate =DateTime.UtcNow,Stock = 10 },
         //       new() { Id = Guid.NewGuid(), Name = "Product 5", Price = 500,CreatedDate =DateTime.UtcNow ,Stock = 10 }
         //   });
         // await  _productWriteRepository.SaveAsync();
            Product p=  await _productReadRepository.GetByIdAsync("816fe2aa-c76d-4a33-89ee-5dafa81a3c60");
            p.Name = "Ahmet";
            p.Price = 12;
            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> Get(string id)
        {
           Product product=  await _productReadRepository.GetByIdAsync(id);
           return Ok(product);
        }
    }
}

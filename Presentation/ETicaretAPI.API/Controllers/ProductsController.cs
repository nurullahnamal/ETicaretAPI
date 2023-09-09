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
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ICustomerWriteRepository  _customerWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        [HttpGet]

        public async Task Get()
        {

            //    var customerId = Guid.NewGuid();
            //    await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Selam" });
            //    await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla", Address = "ankara",CustomerId = customerId});
            //    await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla", Address = "ankara2" , CustomerId = customerId });

            //    await _orderWriteRepository.SaveAsync();



         Order order= await _orderReadRepository.GetByIdAsync("a65529e7-f901-4be3-a650-4072a2094e8b");
         order.Address = "istanbul";
         await _orderWriteRepository.SaveAsync();

        }
    }
}

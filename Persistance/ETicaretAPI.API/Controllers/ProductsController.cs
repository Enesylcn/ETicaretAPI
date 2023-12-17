using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductController(IProductReadRepository productReadRepostory, IProductWriteRepository productWriteRepostory)
        {
            _productReadRepository = productReadRepostory;
            _productWriteRepository = productWriteRepostory;
        }

        [HttpGet]
        public async void Get()
        {
           await _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name = "Product 1", Price= 100, CratedDate = DateTime.UtcNow, Stock= 10},
                new() { Id = Guid.NewGuid(), Name = "Product 2", Price= 200, CratedDate = DateTime.UtcNow, Stock= 20},
                new() { Id = Guid.NewGuid(), Name = "Product 3", Price= 300, CratedDate = DateTime.UtcNow, Stock= 30}
            });
           var count =  await _productWriteRepository.SaveAsync();
        }

    }

}

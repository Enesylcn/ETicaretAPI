﻿using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductController(
            IProductReadRepository productReadRepostory,
            IProductWriteRepository productWriteRepostory)
        {
            _productReadRepository = productReadRepostory;
            _productWriteRepository = productWriteRepostory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Ok(_productReadRepository.GetAll(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(_productReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Stock = model.Stock,
                Price = model.Price
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);

        }

        [HttpPut]

        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id, false);
            product.Name = model.Name;
            product.Stock = model.Stock;
            product.Price = model.Price;
            await _productWriteRepository.SaveAsync();
            return Ok();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string Id)
        {
            await _productWriteRepository.RemoveAsync(Id);
            await _productWriteRepository.SaveAsync();

            return Ok();
        }


    }

}

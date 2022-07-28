﻿using Microsoft.AspNetCore.Mvc;
using Producer.API.Models;
using Producer.API.RabbitMq;
using Producer.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Producer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IRabitMQProducer _rabitMQProducer;

        public ProductController(IProductService productService , IRabitMQProducer rabitMQProducer)
        {
            _productService = productService;
            _rabitMQProducer = rabitMQProducer;
        }

        [HttpGet("productlist")]
        public IEnumerable<Product> ProductList()
        {
            var productList = _productService.GetProductList();
            return productList;
        }

        [HttpGet("getproductbyid")]
        public Product GetProductById(int Id)
        {
            return _productService.GetProductById(Id);
        }

        [HttpPost("addproduct")]
        public Product AddProduct(Product product)
        {
            var productData = _productService.AddProduct(product);
            //send the inserted product data to the queue and consumer will listening this data from queue
            _rabitMQProducer.SendProductMessage(productData);
            return productData;
        }

        [HttpPut("updateproduct")]
        public Product UpdateProduct(Product product)
        {
            return _productService.UpdateProduct(product);
        }

        [HttpDelete("deleteproduct")]
        public bool DeleteProduct(int Id)
        {
            return _productService.DeleteProduct(Id);
        }
    }
}

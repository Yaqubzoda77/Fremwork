using Domain.Dtos;
using Domain.Entities;
using Infrustructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController:ControllerBase
{
    
    private readonly ProductServices _productService;

    public ProductController(ProductServices productService)
    {
        _productService = productService;
    }

    [HttpGet("GET")]
    public List<ProductDto> GetProdcuts()
    {
        return _productService.GetProducts();
    }
    [HttpGet("GetProductByName")]
    public List<ProductDto> GetProductByName(string name)
    {
        return _productService.GetProductByName(name);
    }
    [HttpGet("GETBYID")]
    public Product GetProductID(int id)
    {
        return _productService.GetProductID(id);
    }
    [HttpPost("ADD")]
    public bool AddProduct(ProductDto product)
    {
        _productService.AddProduct(product);
        return true;
    }
    [HttpPut("UpdateCustomer")]
    public bool UpdateProduct(ProductDto product)
    {
        _productService.UpdateProduct(product);
        return true;
    }
    [HttpDelete("Delete")]
    public void DeleteProduct(int id)
    {
        _productService.DeleteProduct(id);
    }
}
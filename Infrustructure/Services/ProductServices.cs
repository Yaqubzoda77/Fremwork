using Domain.Dtos;
using Domain.Entities;
using Infrustructure.Data;

namespace Infrustructure.Services;

public class ProductServices
{
    
    private readonly DataContext _context;
    public ProductServices(DataContext context)
    {
        _context = context;         
    }
    public List<ProductDto> GetProducts()
    {
        return _context.Products.Select(x=>new ProductDto(x.Id,x.Name,x.Price)).ToList();

    }
    public List<ProductDto> GetProductByName(string name)
    {
        return _context.Products. Where(x => x.Name.ToLower().Contains(name.ToLower())).
            Select(x => new ProductDto(x.Id, x.Name,x.Price)).ToList();
    }
    public Product GetProductID(int id)
    {
        return _context.Products.FirstOrDefault(x => x.Id == id);
    }
   
    public int AddProduct (ProductDto product)
    {
        var v = new Product()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,

        };
        _context.Products.Add(v);
        var result = _context.SaveChanges();
        return result;
    }
    public void UpdateProduct(ProductDto product)
    {
        var updated = new Product(product.Id, product.Name, product.Price);
        _context.Products.Update(updated);
        _context.SaveChanges();
    }
    public int DeleteProduct(int id) 
    {
        var product = _context.Products.Find(id);
        _context.Products.Remove(product);
        return _context.SaveChanges();
    }
}
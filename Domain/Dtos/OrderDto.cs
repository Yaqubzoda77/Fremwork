using Domain.Entities;

namespace Domain.Dtos;

public class OrderDto
{
    public OrderDto()
    {
    
    }
    public int Id { get; set; }
    public DateTime OrderPlaced { get; set; }
    public DateTime OrderFulfilled { get; set; }
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string FullName { get; set; }
    
    public Product Products {get; set;}


}
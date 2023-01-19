using Domain.Dtos;
using Domain.Entities;
using Infrustructure.Data;

namespace Infrustructure.Services;

public class OrderService
{
    private readonly DataContext _context;
    public OrderService(DataContext context)
    {
        _context = context;
    }
    public List<OrderDto> GetOrders()
    {
        return _context.Orders.Select(x => new OrderDto()
        {
            Id = x.Id,
            CustomerId = x.CustomerId,
            FullName = string.Concat(x.Customer.FirstName, " ", x.Customer.LastName),
        }).ToList();
    }
    public Order GetOrderId(int id)
    {
        return _context.Orders.FirstOrDefault(x => x.Id == id);
    }
   
  
    public int AddOrder (OrderDto order)
    {
        var o = new Order()
        {
            Id = order.Id,
            Name = order.Name,
            CustomerId = order.CustomerId,

        };
        _context.Orders.Add(o);
        var result = _context.SaveChanges();
        return result;
    }

    public int DeleteOrder(int id) 
    {
        var order = _context.Orders.Find(id);
        _context.Orders.Remove(order);
        return _context.SaveChanges();
    }
}
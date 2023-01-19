using Domain.Dtos;
using Domain.Entities;
using Infrustructure.Data;

namespace Infrustructure.Services;

public class CustomerService
{
    private readonly DataContext _context;

    public CustomerService(DataContext context)
    {
        _context = context;
    }
    
    //Select * from books
    public List<CustomerDto> GetCustomers()
    {
        return _context.Customers.Select(x=> new CustomerDto(x.Id,x.FirstName,x.LastName,x.Address,x.Phone,x.Email)).ToList();
    }
    //insert 
 

    public int AddCustomer(CustomerDto customer)
    {
        var t = new Customer()
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Address = customer.Address,
            Phone = customer.Phone,
            Email = customer.Email,

        };
        _context.Customers.Add(t);
        var result = _context.SaveChanges();
        return result;
    }
    //update
  
    public void UpdateCustomer(CustomerDto customer)
    {
        var v = new Customer()
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Address = customer.Address,
            Phone = customer.Phone,
            Email = customer.Email,

        };
        var updated = new Customer(customer.Id, customer.FirstName, customer.LastName, customer.Address, customer.Phone, customer.Email);
        _context.Customers.Update(updated);
        _context.SaveChanges();
    }



    public int Delete(int id)
    {
        var customer = _context.Customers.Find(id);
        _context.Customers.Remove(customer);
        return _context.SaveChanges(); 
    }   
    public List<CustomerDto> GetCustomerByName(string name)
    {
        return _context.Customers.
            Where(x => x.FirstName.ToLower().Contains(name.ToLower())).
            Select(x => new CustomerDto(x.Id,x.FirstName,x.LastName,x.Address,x.Phone,x.Email)).ToList();
    }
}
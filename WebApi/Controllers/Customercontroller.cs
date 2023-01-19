using Domain.Dtos;
using Domain.Entities;
using Infrustructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController :ControllerBase
{
    private CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("Get")]
    public List<CustomerDto> GetCustomers()
    {
        return _customerService.GetCustomers();
    }

  

    [HttpPost("Add")]
    public void Insert([FromBody] CustomerDto customer) => _customerService.AddCustomer(customer);

    [HttpPut("Update")]
    public void Update([FromBody] CustomerDto customer) => _customerService.UpdateCustomer(customer);

    [HttpDelete("delete{id}")]
    public void delete(int id)
    {
        _customerService.Delete(id);
    }
    
}
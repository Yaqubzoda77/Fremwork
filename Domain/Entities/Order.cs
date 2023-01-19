namespace Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public TimeSpan OrderPlaced { get; set; }
    public TimeSpan OrderFulfilled { get; set; }
    public int CustomerId { get; set; }
    public List<OrderDetail> OrderDetails { get; set; } = new();
    public Customer? Customer { get; set; }
    public string Name { get; set; }
    public string FullName { get; set; }

    public Order()
    {
        
    }
    public Order(int id, TimeSpan orderplaced, TimeSpan orderfulfilled, int customerid ,string fullName)
    {
        Id = id;
        OrderPlaced = orderplaced;
        OrderFulfilled = orderfulfilled;
        CustomerId = customerid;
        FullName = fullName;
    }
    

}
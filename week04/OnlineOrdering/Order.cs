using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public Customer GetCustomer() => _customer;
    public void SetCustomer(Customer customer) => _customer = customer;
    public List<Product> GetProducts() => _products;
    public void SetProducts(List<Product> products) => _products = products;
    public void AddProduct(Product product) => _products.Add(product);

    public decimal GetTotalCost()
    {
        decimal productTotal = _products.Sum(product => product.GetTotalCost());
        decimal shipping = _customer.LivesInUSA() ? 5m : 35m;
        return productTotal + shipping;
    }

    public string GetPackingLabel()
    {
        var label = new StringBuilder("Packing Label\n");
        foreach (Product product in _products)
            label.AppendLine($"{product.GetName()} (ID: {product.GetProductId()})");
        return label.ToString().TrimEnd();
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label\n{_customer.GetName()}\n{_customer.GetAddress().GetAddress()}";
    }
}

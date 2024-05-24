using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Users")]
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}


public class ProductCategory
{
    [Key]
    public string Code { get; set; }

    [Required]
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; } = [];
}

public class ProductBrand
{
    [Key]
    public string Code { get; set; }

    [Required]
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
}

[Table("Products")]
public class Product
{
    [Key]
    public string Code { get; set; }

    [Required]
    public string Name { get; set; }

    [ForeignKey("ProductCategory")]
    public string CategoryCode { get; set; }
    public ProductCategory ProductCategory { get; set; }

    [ForeignKey("ProductBrand")]
    public string BrandCode { get; set; }
    public ProductBrand ProductBrand { get; set; }

    public string ImagePath { get; set; }
    public decimal SaleRate { get; set; }
    public decimal CostRate { get; set; }
}

public class CustomerCategory
{
    [Key]
    public string Code { get; set; }

    [Required]
    public string Name { get; set; }

    public ICollection<Customer> Customers { get; set; } = [];
}

public class CustomerArea
{
    [Key]
    public string Code { get; set; }

    [Required]
    public string Name { get; set; }

    public ICollection<Customer> Customers { get; set; }
}

[Table("Customers")]
public class Customer
{
    [Key]
    public string Code { get; set; }

    [Required]
    public string Name { get; set; }

    public string Address { get; set; }

    [ForeignKey("CustomerArea")]
    public string AreaCode { get; set; }
    public CustomerArea CustomerArea { get; set; }

    [ForeignKey("CustomerCategory")]
    public string CategoryCode { get; set; }
    public CustomerCategory CustomerCategory { get; set; }
}

[Table("Sales")]
public class Sale
{
    [Key]
    public string InvoiceCode { get; set; }

    public DateTime Date { get; set; }

    [ForeignKey("Customer")]
    public string CustomerCode { get; set; }
    public Customer Customer { get; set; }

    public string Address { get; set; }
    public decimal Total { get; set; }

    public ICollection<SaleDetails> SalesDetails { get; set; } = [];
}

[Table("SalesDetails")]
public class SaleDetails
{
    [Key, Column(Order = 0)]
    [ForeignKey("Sales")]
    public string InvoiceCode { get; set; }

    [Key, Column(Order = 1)]
    public int Sno { get; set; }

    public DateTime Date { get; set; }

    public string StockCode { get; set; }
    public string StockType { get; set; }
    public int Qty { get; set; }
    public decimal Amount { get; set; }
    public decimal Discount { get; set; }

    public Sale Sale { get; set; }
}

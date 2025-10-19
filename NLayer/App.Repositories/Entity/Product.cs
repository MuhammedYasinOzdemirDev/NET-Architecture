namespace App.Repositories.Entity;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = default!; // null deger alinmicak belirtiliyor
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
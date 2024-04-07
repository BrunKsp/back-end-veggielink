namespace VeggieLink.Aplication.Dtos.Products;

public class ChangeProductDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime PlantingDate { get; set; }
    public DateTime HarverstDate { get; set; }
    public int Status { get; set; }
}
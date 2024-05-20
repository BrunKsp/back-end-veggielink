namespace aplication.Dtos.Products;

public class CreateProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PlantingDate { get; set; }
    public string Thumb { get; set; }
}
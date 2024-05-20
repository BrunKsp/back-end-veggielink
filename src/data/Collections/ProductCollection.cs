namespace data.domain.Collections;

public class ProductCollection
{
    public string Id { get; set; }
    public int Status { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Thumb { get; set; }
    public DateTime PlantingDate { get; set; }
    public DateTime HarverstDate { get; set; }
    public string CategoryId { get; set; }
}
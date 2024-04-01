namespace Catalog.API.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<string> Category { get; set; } = new();
        public string ImageFile { get; set; } = default!;
        public decimal Price { get; set; }
    }
}

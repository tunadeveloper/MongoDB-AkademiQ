namespace MongoDB_AkademiQ.DTOs.ProductDTOs
{
    public class UpdateProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsPopular { get; set; }
        public string CategoryId { get; set; }
    }
}

namespace NFT_Gallery.Models
{
    public class NFT
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public List<NFTProject>? NFTProjects { get; set; }
    }
}

namespace NFT_Gallery.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string WebsiteURL { get; set; }
        public string MarketplaceURL { get; set; }
        public List<NFTProject>? NFTProjects { get; set; }
    }
}

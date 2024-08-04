namespace NFT_Gallery.Models
{
    public class NFTProject
    {
        public int NFTId { get; set; }
        public NFT NFT { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}

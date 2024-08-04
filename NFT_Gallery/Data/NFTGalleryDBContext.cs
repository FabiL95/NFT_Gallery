using Microsoft.EntityFrameworkCore;
using NFT_Gallery.Models;

namespace NFT_Gallery.Data
{
    public class NFTGalleryDBContext : DbContext
    {
        public NFTGalleryDBContext(DbContextOptions< NFTGalleryDBContext> options ) : base( options ) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // here we are setting up a composite PK for the NFTProject Entity. 
            // we ensure that each combination of NFT and a NFT Project can only appear once in the NFTProject Table
            modelBuilder.Entity<NFTProject>().HasKey(n => new
            {
                n.NFTId,
                n.ProjectId
            });
            // each NFT can have multiple NFTProjects (List NFTProject Property) but one NFTProject can only have one NFT
            modelBuilder.Entity<NFTProject>().HasOne(n => n.NFT).WithMany(n => n.NFTProjects).HasForeignKey(n => n.NFTId);
            // same with the Projects. each Project can have multiple NFTProjects (List NFT Project Property) but one NFT Project can only have one NFT
            modelBuilder.Entity<NFTProject>().HasOne(n => n.Project).WithMany(n => n.NFTProjects).HasForeignKey(n => n.ProjectId);
            // we are adding data to the tables in the database when we create it
            modelBuilder.Entity<NFT>().HasData(
                new NFT { Id = 1, Name = "Stoned Ape #", Price = 2, ImageURL = "SAC1.png" }
                );
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Name = "Stoned Ape Crew", Description = "Blablabla", WebsiteURL = "https://www.stonedapecrew.com/", MarketplaceURL = "https://www.tensor.trade/trade/stoned_ape_crew" }
                );
            modelBuilder.Entity<NFTProject>().HasData(
                new NFTProject { NFTId = 1, ProjectId = 1 }
                );


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<NFT> NFTs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<NFTProject> NFTProjects { get; set; }

    }
}

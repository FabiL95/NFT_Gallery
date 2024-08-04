using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NFT_Gallery.Data;

namespace NFT_Gallery.Controllers
{
    public class NFTController : Controller
    {
        private readonly NFTGalleryDBContext _dbContext;

        public NFTController(NFTGalleryDBContext context)
        {
            _dbContext = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var nfts = from n in _dbContext.NFTs select n;

            if (!string.IsNullOrEmpty(searchString))
            {
                nfts = nfts.Where(n => n.Name.Contains(searchString));
                return View(await nfts.ToListAsync());
            }

            return View(await nfts.ToListAsync());
        }
    }
}

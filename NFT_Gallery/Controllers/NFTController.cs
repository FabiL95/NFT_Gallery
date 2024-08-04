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
            //get all nfts from db
            var nfts = from n in _dbContext.NFTs select n;

            //check is searchstring is null or empty. if no, add only nfts to the list, which have the searchstring in their name.
            if (!string.IsNullOrEmpty(searchString))
            {
                nfts = nfts.Where(n => n.Name.Contains(searchString));
                return View(await nfts.ToListAsync());
            }
            // if searchstring is empty, return all nfts
            return View(await nfts.ToListAsync());
        }

        public async Task<IActionResult> Details (int? id)
        {
            // we add the first nft, which has a matching id to the id we get from the index viewpage. if no match we return null.
            var nft = await _dbContext.NFTs.Include(n => n.NFTProjects).ThenInclude(n => n.Project).FirstOrDefaultAsync(x => x.Id == id);

            if (nft == null)
            {
                return NotFound();
            }

            return View(nft);
        }
    }
}

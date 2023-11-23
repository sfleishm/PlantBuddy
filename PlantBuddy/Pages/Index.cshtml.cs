using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlantBuddy.Models;

namespace PlantBuddy.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PlantBuddy.Data.PlantBuddyContext _context;
        private readonly ILogger<IndexModel> _logger;

        public List<string> PlantImages { get; set; } = new List<string>();

        public IndexModel(ILogger<IndexModel> logger, Data.PlantBuddyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            PlantImages = _context.PlantPictures.Select(x => PlantPicture.ConvertImage(x.Picture)).ToList();
        }
    }
}
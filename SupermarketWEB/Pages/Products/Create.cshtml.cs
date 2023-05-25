using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly SupermarketContext _context;

        public CreateModel(SupermarketContext context)
        {
            _context = context;
        }
        public List<Category> CategoryLis { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            CategoryLis = await _context.Categories.ToListAsync();
            return Page();
        }

        [BindProperty]

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Products == null || Product == null)
            {
                //return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Ventas
{
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;

        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int ProductoId { get; set; }

        public Product Producto { get; set; }
        public Category Categoria { get; set; }
        public PayMode ModoPago { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Producto = await _context.Products.FindAsync(id);

            if (Producto == null)
            {
                return NotFound();
            }

            Categoria = await _context.Categories.FindAsync(Producto.CategoryId);

            if (Categoria == null)
            {
                return NotFound();
            }

            ModoPago = await _context.PayModes.FirstOrDefaultAsync();

            if (ModoPago == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPostComprar()
        {
            // Implementa aquí la lógica para realizar la compra del producto
            // Utiliza los valores de ProductoId, Producto, Categoria y ModoPago

            return RedirectToPage("./Index", new { id = ProductoId });
        }
    }
}

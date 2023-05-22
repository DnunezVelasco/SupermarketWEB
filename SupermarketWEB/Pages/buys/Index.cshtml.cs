using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SupermarketWEB.Data;
using SupermarketWEB.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace SupermarketWEB.Pages.Buys
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;

        public Product Product { get; set; }
        public string ErrorMessage { get; set; }

        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                ErrorMessage = "Debe proporcionar un nombre de producto válido.";
                return Page();
            }
            Console.WriteLine("Nombre buscado: " + nombre);
            Product = await _context.Products.FirstOrDefaultAsync(p => p.Name == nombre);

            if (Product == null)
            {


                ErrorMessage = "No se encontró ningún producto con el nombre proporcionado.";
            }

            return Page();
        }



    }
}
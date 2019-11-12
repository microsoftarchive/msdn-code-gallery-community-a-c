using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesExample.Repository;

namespace RazorPagesExample.Pages.Product
{
    public class AddModel : PageModel
    {
        IProductRepository _productRepository;
        public AddModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [BindProperty]
        public Entity.Product product { get; set; }

        [TempData]
        public string Message { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var count = _productRepository.Add(product);
                if (count > 0)
                {
                    Message = "New Product Added Successfully !";
                    return RedirectToPage("/Product/Index");
                }                
            }

            return Page();
        }
    }
}
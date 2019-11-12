using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesExample.Repository;

namespace RazorPagesExample.Pages.Product
{
    public class EditModel : PageModel
    {
        IProductRepository _productRepository;
        public EditModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [BindProperty]
        public Entity.Product product { get; set; }

        public void OnGet(int id)
        {
            product = _productRepository.GetProduct(id);            
        }

        public IActionResult OnPost()
        {
            var data = product;

            if (ModelState.IsValid)
            {
                var count = _productRepository.EditProduct(data);
                if (count > 0)
                {
                    return RedirectToPage("/Product/Index");
                }
            }

            return Page();
        }
    }
}
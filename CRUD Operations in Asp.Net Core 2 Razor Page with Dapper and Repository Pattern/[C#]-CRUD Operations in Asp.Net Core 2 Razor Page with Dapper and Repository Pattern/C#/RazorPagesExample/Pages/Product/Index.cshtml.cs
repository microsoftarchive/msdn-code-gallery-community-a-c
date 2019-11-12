using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesExample.Repository;
using System.Collections.Generic;


namespace RazorPagesExample.Pages.Product
{
    public class IndexModel : PageModel
    {
        IProductRepository _productRepository;
        public IndexModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [BindProperty]
        public List<Entity.Product> productList { get; set; }

        [BindProperty]
        public Entity.Product product { get; set; }

        [TempData]
        public string Message { get; set; }
        public void OnGet()
        {
            productList = _productRepository.GetList();
        }

        public IActionResult OnPostDelete(int id)
        {
            if (id > 0)
            {
                var count = _productRepository.DeleteProdcut(id);
                if (count > 0)
                {
                    Message = "Product Deleted Successfully !";
                    return RedirectToPage("/Product/Index");
                }
            }

            return Page();

        }
    }
}

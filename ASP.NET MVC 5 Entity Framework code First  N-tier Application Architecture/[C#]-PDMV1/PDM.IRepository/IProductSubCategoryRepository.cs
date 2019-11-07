using PDM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.IRepository
{
    public interface IProductSubCategoryRepository
    {
        int CreateProductSubCategory(ProductSubCategory item, int ProductCategoryID);
    }
}

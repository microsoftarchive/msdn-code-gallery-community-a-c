using PDM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDM.IRepository
{
    public interface IProductRepository
    {
        int Create(Product product, int productModelID, int productCategoryID, int productSubCategoryID);

        int Edit(Product product, int productModelID, int productSubCategoryID);
    }
}

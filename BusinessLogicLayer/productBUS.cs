using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class productBUS
    {
        productDAL productDAL = new productDAL();   
        public List<productModel> get_product_home(int? pageIndex, int? pageSize, out int totalItem)
        {
            return productDAL.get_product_home(pageIndex,pageSize,out totalItem);
        }
    }
}

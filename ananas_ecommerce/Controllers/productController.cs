using BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ananas_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        productBUS productBUS = new productBUS();  
        
        
        [HttpPost]
        
        public IActionResult get()
        {
            int totalItem = 0;
            List < productModel > result = productBUS.get_product_home(1, 10, out totalItem);
            return result != null ? Ok(result) : NotFound();
        }

        
    }
}

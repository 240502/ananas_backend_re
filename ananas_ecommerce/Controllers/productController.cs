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


        [Route("get_home_product")]
        [HttpPost]
        public IActionResult get_product_home([FromBody] Dictionary<string,object> formData )
        {
            int? pageIndex = null;
            int? pageSize = null;
            int totalItem = 0;
            string? errStr = null;
            if(formData.Keys.Contains("pageIndex") && !string.IsNullOrEmpty(formData["pageIndex"].ToString()))
            {
                pageIndex = int.Parse(formData["pageIndex"].ToString());
            }

            if (formData.Keys.Contains("pageSize") && !string.IsNullOrEmpty(formData["pageSize"].ToString()))
            {
                pageSize = int.Parse(formData["pageSize"].ToString());
            }

            List < productModel > result = productBUS.get_product_home(pageIndex, pageSize, out totalItem, out errStr);
            if(!string.IsNullOrEmpty(errStr))
            {
                return BadRequest(errStr);
            }
            return result != null ? Ok(new {pageIndex = pageIndex, pageSize = pageSize, totalItem = totalItem, data = result}) : NotFound();
        }

        
    }
}

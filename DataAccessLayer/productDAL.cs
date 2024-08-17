using DataAccessLayer.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class productDAL
    {
        DataHelper helper = new DataHelper();
        public List<productModel> handleListProduct(List<productModel> list)
        {
            List<productModel> result = new List<productModel> (list);
            if (list == null || list.Count == 0)
                result =  null;
            for (int i = 0; i < result.Count; i++)
            {
                if (i < result.Count - 1)
                {
                    if (result[i].id == result[i + 1].id)
                    {
                        result[i].product_items.AddRange(result[i + 1].product_items);
                        result.Remove(result[i + 1]);
                    }
                   
                }
                else
                {
                    if (result[i].id == result[i - 1].id)
                    {
                        result[i-1].product_items.AddRange(result[i].product_items);
                        result.Remove(result[i]);
                    }
                }
            }
            
            return result;

        }

        public List<productModel> get_product_home(int? pageIndex, int? pageSize,out int totalItem)
        {
            List <productModel> list = new List<productModel> ();
            totalItem = 0;
            string errStr = "";
            try
            {
                DataTable tb = helper.ExcuteReaderReturnDataTable(out errStr,"pro_get_product_home","@pageIndex","@pageSize",pageIndex,pageSize);
                if(!string.IsNullOrEmpty(errStr)) { 
                    throw new Exception(errStr);
                }
                totalItem = int.Parse(tb.Rows[0]["RecordCount"].ToString());
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    productModel product = new productModel();
                    product.product_items = new List<product_itemModel>();
                    product_itemModel product_item = new product_itemModel();
                    
                    product.id = int.Parse(tb.Rows[i]["product_id"].ToString());
                    product.category_id = int.Parse(tb.Rows[i]["category_id"].ToString());
                    product.name = tb.Rows[i]["name"].ToString();
                    product_item.id = int.Parse(tb.Rows[i]["product_item_id"].ToString());
                    product.product_items.Add(product_item);
                    list.Add(product);
                }

                list = handleListProduct(list);


            }
            catch (Exception ex)
            {
                list = null;
            }
            return list;
        }
    }
}

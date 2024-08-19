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

        public List<productModel> get_product_home(int? pageIndex, int? pageSize,out int totalItem, out string? errStr)
        {
            List <productModel> list = new List<productModel> ();
            totalItem = 0;
            errStr = "";
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
                    product.category_id = tb.Rows[i]["category_id"] != DBNull.Value ? int.Parse(tb.Rows[i]["category_id"].ToString()) : null;
                    product.name = tb.Rows[i]["name"].ToString();
                    product.description = tb.Rows[i]["description"] != DBNull.Value ? tb.Rows[i]["description"].ToString() : null ;
                    product.created_at = tb.Rows[i]["created_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["created_at"].ToString()) : null;
                    product.updated_at = tb.Rows[i]["updated_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["updated_at"].ToString()) : null;
                    product.status_id = tb.Rows[i]["status_id"] != DBNull.Value ? int.Parse(tb.Rows[i]["status_id"].ToString()) : null;
                    product.collection_id = tb.Rows[i]["collection_id"] != DBNull.Value ? int.Parse(tb.Rows[i]["collection_id"].ToString()) : null;


                    product_item.id = int.Parse(tb.Rows[i]["product_item_id"].ToString());
                    product_item.normal_price = int.Parse(tb.Rows[i]["normal_price"].ToString());
                    product_item.sale_price = tb.Rows[i]["sale_price"] != DBNull.Value ?  int.Parse(tb.Rows[i]["sale_price"].ToString()): null;
                    product_item.colour_id = tb.Rows[i]["colour_id"] != DBNull.Value ? int.Parse(tb.Rows[i]["colour_id"].ToString()) : null;
                    product_item.colour_name = tb.Rows[i]["colour_name"] != DBNull.Value ? tb.Rows[i]["colour_name"].ToString() : null;
                    product_item.style_id = tb.Rows[i]["style_id"] != DBNull.Value ? int.Parse(tb.Rows[i]["style_id"].ToString()) : null;
                    product_item.style_name = tb.Rows[i]["style_name"] != DBNull.Value ? (tb.Rows[i]["style_name"].ToString()) : null;

                    product.product_items.Add(product_item);
                    list.Add(product);
                }

                list = handleListProduct(list);


            }
            catch (Exception ex)
            {
                list = null;
                errStr = ex.ToString();
            }
            return list;
        }
    }
}

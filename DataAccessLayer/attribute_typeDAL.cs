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
    public class attribute_typeDAL
    {
        DataHelper helper = new DataHelper();

        public List<attribute_typeModel> get_all_attribute_type()
        {
            string errStr = "";
            List<attribute_typeModel> list = new List<attribute_typeModel>();
            try
            {
                DataTable tb = helper.ExcuteReaderReturnDataTable(out errStr, "pro_get_all_attribute_type");
                if (!string.IsNullOrEmpty(errStr))
                {
                    throw new Exception(errStr);
                }
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    attribute_typeModel attribute_Type = new attribute_typeModel();
                    attribute_Type.id = int.Parse(tb.Rows[i]["id"].ToString());
                    attribute_Type.attribute_name = tb.Rows[i]["attribute_name"].ToString();
                    list.Add(attribute_Type);
                }
                return list;

            }
            catch (Exception ex)
            {
                list = null;

            }
            return list;
        }
    }
}

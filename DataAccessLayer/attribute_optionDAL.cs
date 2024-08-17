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
    public class attribute_optionDAL
    {
        DataHelper helper = new DataHelper();

        public List<attribute_optionModel> get_attribute_option()
        {
            List<attribute_optionModel> list = new List<attribute_optionModel>();
            string errStr = "";
            try
            {
                DataTable tb = helper.ExcuteReaderReturnDataTable(out errStr,"pro_get_attribute_option");
                if (!string.IsNullOrEmpty(errStr))
                {
                    throw new Exception(errStr);
                }
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    attribute_optionModel attribute_Option = new attribute_optionModel();
                    attribute_Option.id = int.Parse(tb.Rows[i]["id"].ToString());
                    attribute_Option.attribute_option_name = tb.Rows[i]["attribute_option_name"].ToString();
                    attribute_Option.attribute_type_id = tb.Rows[i]["attribute_type_id"] != DBNull.Value ? int.Parse(tb.Rows[i]["attribute_type_id"].ToString()) : 0;
                    list.Add(attribute_Option);
                }
            }catch (Exception ex)
            {
                list = null;
            }
            return list;
        }

        public List<attribute_optionModel> get_attribute_optionByattribute_type_id(int id)
        {
            List<attribute_optionModel> list = new List<attribute_optionModel>();
            string errStr = "";
            try
            {
                DataTable tb = helper.ExcuteReaderReturnDataTable(out errStr, "pro_get_attribute_optionByattribute_type_id","@attribute_type_id",id);
                if (!string.IsNullOrEmpty(errStr))
                {
                    throw new Exception(errStr);
                }
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    attribute_optionModel attribute_Option = new attribute_optionModel();
                    attribute_Option.id = int.Parse(tb.Rows[i]["id"].ToString());
                    attribute_Option.attribute_option_name = tb.Rows[i]["attribute_option_name"].ToString();
                    attribute_Option.attribute_type_id = tb.Rows[i]["attribute_type_id"] != DBNull.Value ? int.Parse(tb.Rows[i]["attribute_type_id"].ToString()) : 0;
                    list.Add(attribute_Option);
                }
            }
            catch (Exception ex)
            {
                list = null;
            }
            return list;
        }
    }
}

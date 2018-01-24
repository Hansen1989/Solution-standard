using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using System.Data;
using System.Xml.Linq;
using System.Linq.Expressions;

namespace Solution.Logic.Managers
{
    public partial class COMPONENT01Bll : LogicBase
    {
        public DataTable GetCOMPONENT01Table(string prod_id)
        {
            DataTable da;
            try
            {
                DataSet dsCom = null;
                dsCom = (DataSet)SPs.GET_COMPONENT01List(prod_id).ExecuteDataSet();
                if (dsCom.Tables.Count > 0)
                {
                    da = dsCom.Tables[0].Copy();
                }
                else
                {
                    da = new DataTable();
                }
            }
            catch
            {
                da = new DataTable();
            }
            return da;
        }

        /// <summary>
        /// 读取某个固定字段的值
        /// </summary>
        /// <param name="conditionColName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetModelSingleValue(string colunm, Expression<Func<COMPONENT01, bool>> expression)
        {
            var model = new COMPONENT01(expression);
            string result = "";
            switch (colunm)
            {
                case "COM_ID": result = model.COM_ID; break;
                case "DETAIL_ID": result = model.DETAIL_ID.ToString(); break;
                case "PROD_ID;": result = model.PROD_ID; break;
                case "QUANTITY": result = model.QUANTITY.ToString(); break;
                case "LQUANTITY": result = model.LQUANTITY.ToString(); break;
                case "New_PROD_ID;": result = model.New_PROD_ID; break;
                case "IsScales": result = model.IsScales.ToString(); break;
                case "PrtTag": result = model.PrtTag.ToString(); break;
                case "IsFlag": result = model.IsFlag.ToString(); break;
                case "Memo": result = model.Memo; break;
                default: result = ""; break;
            }
            return result;
        }
    }
}

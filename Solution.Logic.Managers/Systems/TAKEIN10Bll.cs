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
    public partial class TAKEIN10Bll: LogicBase
    {
        public void BindOrderGrid(string st, string et, int type,string shop_name,string shop_id, FineUI.Grid grid)
        {
            DataTable da;
            try
            {
                DataSet dsCom = null;
                dsCom = (DataSet)SPs.Get_Purchase00(st, et, shop_id, type).ExecuteDataSet();
                if (dsCom.Tables.Count > 0)
                {
                    da = dsCom.Tables[0].Copy();
                    grid.DataSource = da;
                    grid.DataBind();
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
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Solution.DataAccess.DataModel;
using Solution.DataAccess.DbHelper;

namespace Solution.Logic.Managers
{
    public partial class ORDER00Bll : LogicBase
    {
        public DataSet Get_ORDER01_PRODUCT00_PRODUCT01_(string order_id,string prcarea_id)
        {
            DataSet ds = null;

            ds = (DataSet)SPs.Get_ORDER01_PRODUCT00_PRODUCT01(order_id,prcarea_id).ExecuteDataSet();

            return ds;

        }

        public void Delete(string order_id)
        {
            //设置Sql语句
            var sql = string.Format("delete from {0} where {1} = '{2}'", ORDER01Table.TableName,ORDER01Table.ORDER_ID,order_id);

            //删除
            var delete = new DeleteHelper();
            delete.Delete(sql);

            

        }



    }
}

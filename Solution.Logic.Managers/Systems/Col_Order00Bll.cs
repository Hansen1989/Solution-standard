using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Solution.Logic.Managers
{
    public partial class Col_Order00Bll : LogicBase
    {
        /// <summary>
        /// 汇整
        /// </summary>
        /// <param name="ORD_USER_C"></param>
        /// <param name="ORD_DEP_ID_C"></param>
        /// <param name="Import_Shop_C"></param>
        /// <param name="COL_BeginDate"></param>
        /// <param name="COL_EndDate"></param>
        /// <param name="IsTime"></param>
        /// <returns></returns>
        public int ADD_ARCHIVEORDERS(string ORD_USER_C,string ORD_DEP_ID_C, string ARCHIVEORDER_Shop_ID, string COL_BeginDate, string COL_EndDate,int IsTime)
        {
            int error = 0;
            try {
                SPs.ADD_ARCHIVEORDERS(ORD_USER_C,ORD_DEP_ID_C, ARCHIVEORDER_Shop_ID, COL_BeginDate, COL_EndDate,IsTime).Execute();

            }
            catch(Exception)
            {
                error = 1;
            }

            return error;

        }

        /// <summary>
        /// 获取汇整商品列表 
        /// </summary>
        /// <param name="col_id"></param>
        /// <returns></returns>
        public DataTable GET_ARCHIVEORDERS_LEFT_LIST(string col_id) {
            DataTable dt = null;

            try {
                dt = SPs.GET_ARCHIVEORDERS_LEFT_LIST(col_id).ExecuteDataTable();
            } catch (Exception)
            {

            }

            return dt;
        }

        /// <summary>
        /// 获取右侧列表
        /// </summary>
        /// <param name="shop_id"></param>
        /// <param name="prod_id"></param>
        /// <param name="col_id"></param>
        /// <returns></returns>
        public DataTable GET_ARCHIVEORDERS_RIGHT_LIST(string shop_id,string prod_id,string col_id)
        {
            DataTable dt = null;

            try
            {
                dt = SPs.GET_ARCHIVEORDERS_RIGHT_LIST(shop_id,prod_id,col_id).ExecuteDataTable();
            }
            catch (Exception)
            {

            }

            return dt;
        }

        /// <summary>
        /// 汇整 核准
        /// </summary>
        /// <param name="COL_ID"></param>
        /// <param name="SHOP_ID_NOW"></param>
        /// <param name="USER_ID"></param>
        /// <param name="ISPP"></param>
        /// <returns></returns>
        public int ADD_PLAN_PURCHASE(string COL_ID,string SHOP_ID_NOW,string USER_ID,int ISPP)
        {
            int error = 0;
            try {
                SPs.ADD_PLAN_PURCHASE(COL_ID, SHOP_ID_NOW, USER_ID, ISPP).Execute();
            } catch (Exception)
            {
                error = 1;

            }

            return error;

        }



    }
}

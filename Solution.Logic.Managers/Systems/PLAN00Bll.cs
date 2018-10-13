using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Solution.Logic.Managers
{
    public partial class PLAN00Bll : LogicBase
    {
         
        public DataTable GET_PLAN_LEFT_LIST(string plan_id)
        {
            DataTable dt = null;

            int error = 0;
            try
            {
                dt = SPs.Get_PLAN_Left_List(plan_id).ExecuteDataTable();

            }
            catch (Exception)
            {
                error = 1;
            }

            return dt;

        }

        public DataTable GET_PLAN_RIGHT_LIST(string plan_id)
        {
            DataTable dt = null;
            int error = 0;
            try
            {
                dt = SPs.Get_PLAN_Left_List(plan_id).ExecuteDataTable();

            }
            catch (Exception)
            {
                error = 1;
            }

            return dt;

        }



    }
 
}

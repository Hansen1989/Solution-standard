using Solution.DataAccess.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solution.Logic.Managers
{
    public partial class Material00Bll:LogicBase
    {
        //public int LeadIntoProductPlanList(string beginTime, string endTime, string isChoseTime, string shopId, string userId)
        //{
        //    int error = 0;
        //    try
        //    {
        //        SPs.LeadIntoProductPlanList(beginTime, endTime, isChoseTime, shopId, userId).Execute();

        //    }
        //    catch (Exception)
        //    {
        //        error = 1;
        //    }

        //    return error;

        //}

        public int ApprovalReduceStock(string shopId, string takeinId, string userId)
        {
            int error = 0;
            try
            {
                SPs.ApprovalReduceMaterial(shopId, takeinId, userId).Execute();

            }
            catch (Exception)
            {
                error = 1;
            }

            return error;
        }
    }
}

using Solution.DataAccess.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solution.Logic.Managers
{
    public partial class OUT00Bll:LogicBase
    {
        public int SplitOrders(string col_id)
        {
            int error = 0;
            try
            {
                SPs.SplitOrders(col_id).Execute();

            }
            catch (Exception)
            {
                error = 1;
            }

            return error;

        }

    }
}

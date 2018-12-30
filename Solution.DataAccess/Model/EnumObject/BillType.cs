using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Solution.DataAccess.Model.EnumObject
{
    public enum BillType
    {
        [Description("出货单")]
        OutBill = 1,
        [Description("退货单")]
        BackBill = 2
    }
}

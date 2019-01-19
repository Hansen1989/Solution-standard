using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Solution.DataAccess.Model.EnumObject
{
    public enum ShopKind
    {
        [Description("区域中心")]
        Area = 0,
        [Description("直营门店")]
        DirectStore = 1,
        [Description("加盟店")]
        Franchisee = 2
    }
}

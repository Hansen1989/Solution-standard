 
using System;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: PagePowerSignPublic
        /// </summary>

        public class PagePowerSignPublicTable {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "PagePowerSignPublic";
      			}
			}

			/// <summary>
			/// 主键Id
			/// </summary>
   			public static string Id{
			      get{
        			return "Id";
      			}
		    }
			/// <summary>
			/// 权限中文名称
			/// </summary>
   			public static string Cname{
			      get{
        			return "Cname";
      			}
		    }
			/// <summary>
			/// 权限英文名称
			/// </summary>
   			public static string Ename{
			      get{
        			return "Ename";
      			}
		    }
                    
        }
}

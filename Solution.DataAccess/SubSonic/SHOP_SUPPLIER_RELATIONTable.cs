 
using System;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: SHOP_SUPPLIER_RELATION
        /// </summary>

        public class SHOP_SUPPLIER_RELATIONTable {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "SHOP_SUPPLIER_RELATION";
      			}
			}

			/// <summary>
			/// 
			/// </summary>
   			public static string Id{
			      get{
        			return "Id";
      			}
		    }
			/// <summary>
			/// 分店编号
			/// </summary>
   			public static string SHOP_ID{
			      get{
        			return "SHOP_ID";
      			}
		    }
			/// <summary>
			/// 供应商编号
			/// </summary>
   			public static string SUP_ID{
			      get{
        			return "SUP_ID";
      			}
		    }
			/// <summary>
			/// 供应商名称
			/// </summary>
   			public static string SUP_NAME{
			      get{
        			return "SUP_NAME";
      			}
		    }
			/// <summary>
			/// 备注
			/// </summary>
   			public static string MEMO{
			      get{
        			return "MEMO";
      			}
		    }
			/// <summary>
			/// 创建时间
			/// </summary>
   			public static string CRT_DATETIME{
			      get{
        			return "CRT_DATETIME";
      			}
		    }
                    
        }
}

 
using System;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: RECEIVABLES00
        /// </summary>

        public class RECEIVABLES00Table {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "RECEIVABLES00";
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
			/// 总店编号
			/// </summary>
   			public static string SHOP_ID{
			      get{
        			return "SHOP_ID";
      			}
		    }
			/// <summary>
			/// 出货单编号
			/// </summary>
   			public static string OUT_ID{
			      get{
        			return "OUT_ID";
      			}
		    }
			/// <summary>
			/// 账单状态
			/// </summary>
   			public static string STATUS{
			      get{
        			return "STATUS";
      			}
		    }
			/// <summary>
			/// 出货单日期
			/// </summary>
   			public static string INPUT_DATE{
			      get{
        			return "INPUT_DATE";
      			}
		    }
			/// <summary>
			/// 分店编号
			/// </summary>
   			public static string IN_SHOP{
			      get{
        			return "IN_SHOP";
      			}
		    }
			/// <summary>
			/// 出货单制单人
			/// </summary>
   			public static string USER_ID{
			      get{
        			return "USER_ID";
      			}
		    }
			/// <summary>
			/// 出货单审核人
			/// </summary>
   			public static string APP_USER{
			      get{
        			return "APP_USER";
      			}
		    }
			/// <summary>
			/// 出货单审核时间
			/// </summary>
   			public static string APP_DATETIME{
			      get{
        			return "APP_DATETIME";
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
			/// 建档时间
			/// </summary>
   			public static string CRT_DATETIME{
			      get{
        			return "CRT_DATETIME";
      			}
		    }
			/// <summary>
			/// 建档人
			/// </summary>
   			public static string CRT_USER_ID{
			      get{
        			return "CRT_USER_ID";
      			}
		    }
			/// <summary>
			/// 修改时间
			/// </summary>
   			public static string MOD_DATETIME{
			      get{
        			return "MOD_DATETIME";
      			}
		    }
			/// <summary>
			/// 修改人
			/// </summary>
   			public static string MOD_USER_ID{
			      get{
        			return "MOD_USER_ID";
      			}
		    }
			/// <summary>
			/// 更新时间
			/// </summary>
   			public static string LAST_UPDATE{
			      get{
        			return "LAST_UPDATE";
      			}
		    }
			/// <summary>
			/// 账单金额
			/// </summary>
   			public static string BILL_AMOUNT{
			      get{
        			return "BILL_AMOUNT";
      			}
		    }
			/// <summary>
			/// 出货成本
			/// </summary>
   			public static string BILL_COST{
			      get{
        			return "BILL_COST";
      			}
		    }
                    
        }
}

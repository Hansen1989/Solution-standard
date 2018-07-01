 
using System;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: DUE00
        /// </summary>

        public class DUE00Table {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "DUE00";
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
			/// 店铺编号
			/// </summary>
   			public static string SHOP_ID{
			      get{
        			return "SHOP_ID";
      			}
		    }
			/// <summary>
			/// 进货单
			/// </summary>
   			public static string TAKEIN_ID{
			      get{
        			return "TAKEIN_ID";
      			}
		    }
			/// <summary>
			/// 应付账单状态
			/// </summary>
   			public static string STATUS{
			      get{
        			return "STATUS";
      			}
		    }
			/// <summary>
			/// 进货单日期
			/// </summary>
   			public static string INPUT_DATE{
			      get{
        			return "INPUT_DATE";
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
			/// 进货单制单人
			/// </summary>
   			public static string USER_ID{
			      get{
        			return "USER_ID";
      			}
		    }
			/// <summary>
			/// 进货单审核人
			/// </summary>
   			public static string APP_USER{
			      get{
        			return "APP_USER";
      			}
		    }
			/// <summary>
			/// 审核时间
			/// </summary>
   			public static string APP_DATETIME{
			      get{
        			return "APP_DATETIME";
      			}
		    }
			/// <summary>
			/// 进货单金额
			/// </summary>
   			public static string TOT_AMOUNT{
			      get{
        			return "TOT_AMOUNT";
      			}
		    }
			/// <summary>
			/// 采购总税额
			/// </summary>
   			public static string TOT_TAX{
			      get{
        			return "TOT_TAX";
      			}
		    }
			/// <summary>
			/// 采购总数量
			/// </summary>
   			public static string TOT_QTY{
			      get{
        			return "TOT_QTY";
      			}
		    }
			/// <summary>
			/// 采购预付款
			/// </summary>
   			public static string PRE_PAY{
			      get{
        			return "PRE_PAY";
      			}
		    }
			/// <summary>
			/// 
			/// </summary>
   			public static string PRE_PAY_ID{
			      get{
        			return "PRE_PAY_ID";
      			}
		    }
			/// <summary>
			/// 关联单号
			/// </summary>
   			public static string RELATE_ID{
			      get{
        			return "RELATE_ID";
      			}
		    }
			/// <summary>
			/// 发票号码
			/// </summary>
   			public static string INVOICE_ID{
			      get{
        			return "INVOICE_ID";
      			}
		    }
			/// <summary>
			/// 进货类型
			/// </summary>
   			public static string TAKEIN_TYPE{
			      get{
        			return "TAKEIN_TYPE";
      			}
		    }
			/// <summary>
			/// 备注
			/// </summary>
   			public static string Memo{
			      get{
        			return "Memo";
      			}
		    }
			/// <summary>
			/// 建档日期
			/// </summary>
   			public static string CRT_DATETIME{
			      get{
        			return "CRT_DATETIME";
      			}
		    }
			/// <summary>
			/// 建档人员
			/// </summary>
   			public static string CRT_USER_ID{
			      get{
        			return "CRT_USER_ID";
      			}
		    }
			/// <summary>
			/// 修改日期
			/// </summary>
   			public static string MOD_DATETIME{
			      get{
        			return "MOD_DATETIME";
      			}
		    }
			/// <summary>
			/// 修改人员
			/// </summary>
   			public static string MOD_USER_ID{
			      get{
        			return "MOD_USER_ID";
      			}
		    }
			/// <summary>
			/// 最后异动时间
			/// </summary>
   			public static string LAST_UPDATE{
			      get{
        			return "LAST_UPDATE";
      			}
		    }
                    
        }
}

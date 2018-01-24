 
using System;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: EmailSendHistory
        /// </summary>

        public class EmailSendHistoryTable {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "EmailSendHistory";
      			}
			}

			/// <summary>
			/// 站内信ID
			/// </summary>
   			public static string Id{
			      get{
        			return "Id";
      			}
		    }
			/// <summary>
			/// 发送者编号ID，0=系统管理员
			/// </summary>
   			public static string SendUsers_Id{
			      get{
        			return "SendUsers_Id";
      			}
		    }
			/// <summary>
			/// 发送者账号
			/// </summary>
   			public static string SendUsers_Name{
			      get{
        			return "SendUsers_Name";
      			}
		    }
			/// <summary>
			/// 发送者邮箱
			/// </summary>
   			public static string SendUsers_Email{
			      get{
        			return "SendUsers_Email";
      			}
		    }
			/// <summary>
			/// 接受者编号ID，0=所有人
			/// </summary>
   			public static string RecUsers_Id{
			      get{
        			return "RecUsers_Id";
      			}
		    }
			/// <summary>
			/// 接收者账号
			/// </summary>
   			public static string RecUsers_Name{
			      get{
        			return "RecUsers_Name";
      			}
		    }
			/// <summary>
			/// 接收者邮箱
			/// </summary>
   			public static string RecUsers_Email{
			      get{
        			return "RecUsers_Email";
      			}
		    }
			/// <summary>
			/// 接受者编号ID，0=所有人
			/// </summary>
   			public static string RecUserLevel_Id{
			      get{
        			return "RecUserLevel_Id";
      			}
		    }
			/// <summary>
			/// 接受者账号
			/// </summary>
   			public static string RecUserLevel_Name{
			      get{
        			return "RecUserLevel_Name";
      			}
		    }
			/// <summary>
			/// 邮件主题
			/// </summary>
   			public static string EmailSubject{
			      get{
        			return "EmailSubject";
      			}
		    }
			/// <summary>
			/// 邮件内容
			/// </summary>
   			public static string EmailContent{
			      get{
        			return "EmailContent";
      			}
		    }
			/// <summary>
			/// 站内信发送时间
			/// </summary>
   			public static string SendDate{
			      get{
        			return "SendDate";
      			}
		    }
			/// <summary>
			/// 发送状态：0：发送失败；1发送成功
			/// </summary>
   			public static string Status{
			      get{
        			return "Status";
      			}
		    }
			/// <summary>
			/// 发送状态名称
			/// </summary>
   			public static string StatusName{
			      get{
        			return "StatusName";
      			}
		    }
			/// <summary>
			/// 异常信息
			/// </summary>
   			public static string ErrorMsg{
			      get{
        			return "ErrorMsg";
      			}
		    }
			/// <summary>
			/// 模板ID
			/// </summary>
   			public static string Template_Id{
			      get{
        			return "Template_Id";
      			}
		    }
			/// <summary>
			/// 模板名称
			/// </summary>
   			public static string Template_Name{
			      get{
        			return "Template_Name";
      			}
		    }
                    
        }
}

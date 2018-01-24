 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// EmailSendHistory表实体类
    /// </summary>
    public partial class EmailSendHistory
    {

		int _Id = 0;
		/// <summary>
		/// 站内信ID
		/// </summary>
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		int _SendUsers_Id = 0;
		/// <summary>
		/// 发送者编号ID，0=系统管理员
		/// </summary>
		public int SendUsers_Id
		{
			get { return _SendUsers_Id; }
			set { _SendUsers_Id = value; }
		}

		string _SendUsers_Name = "";
		/// <summary>
		/// 发送者账号
		/// </summary>
		public string SendUsers_Name
		{
			get { return _SendUsers_Name; }
			set { _SendUsers_Name = value; }
		}

		string _SendUsers_Email = "";
		/// <summary>
		/// 发送者邮箱
		/// </summary>
		public string SendUsers_Email
		{
			get { return _SendUsers_Email; }
			set { _SendUsers_Email = value; }
		}

		int _RecUsers_Id = 0;
		/// <summary>
		/// 接受者编号ID，0=所有人
		/// </summary>
		public int RecUsers_Id
		{
			get { return _RecUsers_Id; }
			set { _RecUsers_Id = value; }
		}

		string _RecUsers_Name = "";
		/// <summary>
		/// 接收者账号
		/// </summary>
		public string RecUsers_Name
		{
			get { return _RecUsers_Name; }
			set { _RecUsers_Name = value; }
		}

		string _RecUsers_Email = "";
		/// <summary>
		/// 接收者邮箱
		/// </summary>
		public string RecUsers_Email
		{
			get { return _RecUsers_Email; }
			set { _RecUsers_Email = value; }
		}

		int _RecUserLevel_Id = 0;
		/// <summary>
		/// 接受者编号ID，0=所有人
		/// </summary>
		public int RecUserLevel_Id
		{
			get { return _RecUserLevel_Id; }
			set { _RecUserLevel_Id = value; }
		}

		string _RecUserLevel_Name = "";
		/// <summary>
		/// 接受者账号
		/// </summary>
		public string RecUserLevel_Name
		{
			get { return _RecUserLevel_Name; }
			set { _RecUserLevel_Name = value; }
		}

		string _EmailSubject = "";
		/// <summary>
		/// 邮件主题
		/// </summary>
		public string EmailSubject
		{
			get { return _EmailSubject; }
			set { _EmailSubject = value; }
		}

		string _EmailContent = "";
		/// <summary>
		/// 邮件内容
		/// </summary>
		public string EmailContent
		{
			get { return _EmailContent; }
			set { _EmailContent = value; }
		}

		DateTime _SendDate = new DateTime(1900,1,1);
		/// <summary>
		/// 站内信发送时间
		/// </summary>
		public DateTime SendDate
		{
			get { return _SendDate; }
			set { _SendDate = value; }
		}

		byte _Status = 0;
		/// <summary>
		/// 发送状态：0：发送失败；1发送成功
		/// </summary>
		public byte Status
		{
			get { return _Status; }
			set { _Status = value; }
		}

		string _StatusName = "";
		/// <summary>
		/// 发送状态名称
		/// </summary>
		public string StatusName
		{
			get { return _StatusName; }
			set { _StatusName = value; }
		}

		string _ErrorMsg = "";
		/// <summary>
		/// 异常信息
		/// </summary>
		public string ErrorMsg
		{
			get { return _ErrorMsg; }
			set { _ErrorMsg = value; }
		}

		int _Template_Id = 0;
		/// <summary>
		/// 模板ID
		/// </summary>
		public int Template_Id
		{
			get { return _Template_Id; }
			set { _Template_Id = value; }
		}

		string _Template_Name = "";
		/// <summary>
		/// 模板名称
		/// </summary>
		public string Template_Name
		{
			get { return _Template_Name; }
			set { _Template_Name = value; }
		}
    } 

}



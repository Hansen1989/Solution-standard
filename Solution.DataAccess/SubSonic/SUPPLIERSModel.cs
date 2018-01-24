 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// SUPPLIERS表实体类
    /// </summary>
    public partial class SUPPLIERS
    {

		int _Id = 0;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		string _SUP_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string SUP_ID
		{
			get { return _SUP_ID; }
			set { _SUP_ID = value; }
		}

		string _SUP_NAME = "";
		/// <summary>
		/// 
		/// </summary>
		public string SUP_NAME
		{
			get { return _SUP_NAME; }
			set { _SUP_NAME = value; }
		}

		string _SUP_NICKNAME = "";
		/// <summary>
		/// 
		/// </summary>
		public string SUP_NICKNAME
		{
			get { return _SUP_NICKNAME; }
			set { _SUP_NICKNAME = value; }
		}

		int _SUP_TYPE = 0;
		/// <summary>
		/// 
		/// </summary>
		public int SUP_TYPE
		{
			get { return _SUP_TYPE; }
			set { _SUP_TYPE = value; }
		}

		string _SUP_ADD = "";
		/// <summary>
		/// 
		/// </summary>
		public string SUP_ADD
		{
			get { return _SUP_ADD; }
			set { _SUP_ADD = value; }
		}

		string _SUP_TEL = "";
		/// <summary>
		/// 
		/// </summary>
		public string SUP_TEL
		{
			get { return _SUP_TEL; }
			set { _SUP_TEL = value; }
		}

		string _SUP_Email = "";
		/// <summary>
		/// 
		/// </summary>
		public string SUP_Email
		{
			get { return _SUP_Email; }
			set { _SUP_Email = value; }
		}

		string _SUP_ZIP = "";
		/// <summary>
		/// 
		/// </summary>
		public string SUP_ZIP
		{
			get { return _SUP_ZIP; }
			set { _SUP_ZIP = value; }
		}

		string _SUP_Contact = "";
		/// <summary>
		/// 
		/// </summary>
		public string SUP_Contact
		{
			get { return _SUP_Contact; }
			set { _SUP_Contact = value; }
		}

		string _SUP_Mobile = "";
		/// <summary>
		/// 
		/// </summary>
		public string SUP_Mobile
		{
			get { return _SUP_Mobile; }
			set { _SUP_Mobile = value; }
		}

		string _SUP_CODE_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string SUP_CODE_ID
		{
			get { return _SUP_CODE_ID; }
			set { _SUP_CODE_ID = value; }
		}

		string _SUP_BankName = "";
		/// <summary>
		/// 
		/// </summary>
		public string SUP_BankName
		{
			get { return _SUP_BankName; }
			set { _SUP_BankName = value; }
		}

		string _SUP_BankID = "";
		/// <summary>
		/// 
		/// </summary>
		public string SUP_BankID
		{
			get { return _SUP_BankID; }
			set { _SUP_BankID = value; }
		}

		string _SUP_PASSWORD = "";
		/// <summary>
		/// 
		/// </summary>
		public string SUP_PASSWORD
		{
			get { return _SUP_PASSWORD; }
			set { _SUP_PASSWORD = value; }
		}

		int _Send_DAY = 0;
		/// <summary>
		/// 
		/// </summary>
		public int Send_DAY
		{
			get { return _Send_DAY; }
			set { _Send_DAY = value; }
		}

		DateTime _CRT_DATETIME = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime CRT_DATETIME
		{
			get { return _CRT_DATETIME; }
			set { _CRT_DATETIME = value; }
		}

		string _CRT_USER_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string CRT_USER_ID
		{
			get { return _CRT_USER_ID; }
			set { _CRT_USER_ID = value; }
		}

		DateTime _MOD_DATETIME = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime MOD_DATETIME
		{
			get { return _MOD_DATETIME; }
			set { _MOD_DATETIME = value; }
		}

		string _MOD_USER_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string MOD_USER_ID
		{
			get { return _MOD_USER_ID; }
			set { _MOD_USER_ID = value; }
		}

		DateTime _LAST_UPDATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime LAST_UPDATE
		{
			get { return _LAST_UPDATE; }
			set { _LAST_UPDATE = value; }
		}
    } 

}



 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// EMPLOYEE表实体类
    /// </summary>
    public partial class EMPLOYEE
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

		string _EMP_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string EMP_ID
		{
			get { return _EMP_ID; }
			set { _EMP_ID = value; }
		}

		string _EMP_NAME = "";
		/// <summary>
		/// 
		/// </summary>
		public string EMP_NAME
		{
			get { return _EMP_NAME; }
			set { _EMP_NAME = value; }
		}

		DateTime _EMP_Birthday = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime EMP_Birthday
		{
			get { return _EMP_Birthday; }
			set { _EMP_Birthday = value; }
		}

		string _EMP_ADD = "";
		/// <summary>
		/// 
		/// </summary>
		public string EMP_ADD
		{
			get { return _EMP_ADD; }
			set { _EMP_ADD = value; }
		}

		string _EMP_TEL = "";
		/// <summary>
		/// 
		/// </summary>
		public string EMP_TEL
		{
			get { return _EMP_TEL; }
			set { _EMP_TEL = value; }
		}

		string _EMP_ZIP = "";
		/// <summary>
		/// 
		/// </summary>
		public string EMP_ZIP
		{
			get { return _EMP_ZIP; }
			set { _EMP_ZIP = value; }
		}

		string _EMP_EMAIL = "";
		/// <summary>
		/// 
		/// </summary>
		public string EMP_EMAIL
		{
			get { return _EMP_EMAIL; }
			set { _EMP_EMAIL = value; }
		}

		string _EMP_MOBILE = "";
		/// <summary>
		/// 
		/// </summary>
		public string EMP_MOBILE
		{
			get { return _EMP_MOBILE; }
			set { _EMP_MOBILE = value; }
		}

		string _EMP_MEMO = "";
		/// <summary>
		/// 
		/// </summary>
		public string EMP_MEMO
		{
			get { return _EMP_MEMO; }
			set { _EMP_MEMO = value; }
		}

		int _EMP_ENABLE = 0;
		/// <summary>
		/// 
		/// </summary>
		public int EMP_ENABLE
		{
			get { return _EMP_ENABLE; }
			set { _EMP_ENABLE = value; }
		}

		int _EMP_SEX = 0;
		/// <summary>
		/// 
		/// </summary>
		public int EMP_SEX
		{
			get { return _EMP_SEX; }
			set { _EMP_SEX = value; }
		}

		string _EMP_CodeID = "";
		/// <summary>
		/// 
		/// </summary>
		public string EMP_CodeID
		{
			get { return _EMP_CodeID; }
			set { _EMP_CodeID = value; }
		}

		int _EMP_LEVEL = 0;
		/// <summary>
		/// 
		/// </summary>
		public int EMP_LEVEL
		{
			get { return _EMP_LEVEL; }
			set { _EMP_LEVEL = value; }
		}

		string _EMP_PASSWORD = "";
		/// <summary>
		/// 
		/// </summary>
		public string EMP_PASSWORD
		{
			get { return _EMP_PASSWORD; }
			set { _EMP_PASSWORD = value; }
		}

		DateTime _EMP_BDATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime EMP_BDATE
		{
			get { return _EMP_BDATE; }
			set { _EMP_BDATE = value; }
		}

		DateTime _EMP_EDATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime EMP_EDATE
		{
			get { return _EMP_EDATE; }
			set { _EMP_EDATE = value; }
		}

		decimal _EMP_WAGE = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal EMP_WAGE
		{
			get { return _EMP_WAGE; }
			set { _EMP_WAGE = value; }
		}

		int _EMP_Education = 0;
		/// <summary>
		/// 
		/// </summary>
		public int EMP_Education
		{
			get { return _EMP_Education; }
			set { _EMP_Education = value; }
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

		byte _STATUS = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte STATUS
		{
			get { return _STATUS; }
			set { _STATUS = value; }
		}
    } 

}



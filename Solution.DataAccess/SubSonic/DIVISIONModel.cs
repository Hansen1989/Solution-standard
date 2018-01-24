 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// DIVISION表实体类
    /// </summary>
    public partial class DIVISION
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

		string _DIV_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string DIV_ID
		{
			get { return _DIV_ID; }
			set { _DIV_ID = value; }
		}

		string _DIV_NAME = "";
		/// <summary>
		/// 
		/// </summary>
		public string DIV_NAME
		{
			get { return _DIV_NAME; }
			set { _DIV_NAME = value; }
		}

		int _DIV_TYPE = 0;
		/// <summary>
		/// 
		/// </summary>
		public int DIV_TYPE
		{
			get { return _DIV_TYPE; }
			set { _DIV_TYPE = value; }
		}

		string _STOCK_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string STOCK_ID
		{
			get { return _STOCK_ID; }
			set { _STOCK_ID = value; }
		}

		string _DIV_MEMO = "";
		/// <summary>
		/// 
		/// </summary>
		public string DIV_MEMO
		{
			get { return _DIV_MEMO; }
			set { _DIV_MEMO = value; }
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



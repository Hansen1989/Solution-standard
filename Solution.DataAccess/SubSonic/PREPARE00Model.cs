 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// PREPARE00表实体类
    /// </summary>
    public partial class PREPARE00
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

		string _SHOP_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string SHOP_ID
		{
			get { return _SHOP_ID; }
			set { _SHOP_ID = value; }
		}

		string _PREPAR_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string PREPAR_ID
		{
			get { return _PREPAR_ID; }
			set { _PREPAR_ID = value; }
		}

		int _STATUS = 0;
		/// <summary>
		/// 
		/// </summary>
		public int STATUS
		{
			get { return _STATUS; }
			set { _STATUS = value; }
		}

		DateTime _INPUT_DATE = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime INPUT_DATE
		{
			get { return _INPUT_DATE; }
			set { _INPUT_DATE = value; }
		}

		int _PRE_TYPE = 0;
		/// <summary>
		/// 
		/// </summary>
		public int PRE_TYPE
		{
			get { return _PRE_TYPE; }
			set { _PRE_TYPE = value; }
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

		string _USER_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string USER_ID
		{
			get { return _USER_ID; }
			set { _USER_ID = value; }
		}

		string _APP_USER = "";
		/// <summary>
		/// 
		/// </summary>
		public string APP_USER
		{
			get { return _APP_USER; }
			set { _APP_USER = value; }
		}

		DateTime _APP_DATETIME = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime APP_DATETIME
		{
			get { return _APP_DATETIME; }
			set { _APP_DATETIME = value; }
		}

		string _RELATE_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string RELATE_ID
		{
			get { return _RELATE_ID; }
			set { _RELATE_ID = value; }
		}

		string _Memo = "";
		/// <summary>
		/// 
		/// </summary>
		public string Memo
		{
			get { return _Memo; }
			set { _Memo = value; }
		}

		bool _LOCKED = true;
		/// <summary>
		/// 
		/// </summary>
		public bool LOCKED
		{
			get { return _LOCKED; }
			set { _LOCKED = value; }
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

		bool _Trans_STATUS = true;
		/// <summary>
		/// 
		/// </summary>
		public bool Trans_STATUS
		{
			get { return _Trans_STATUS; }
			set { _Trans_STATUS = value; }
		}
    } 

}



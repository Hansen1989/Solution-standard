 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// SHOP00表实体类
    /// </summary>
    public partial class SHOP00
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

		string _SHOP_NAME1 = "";
		/// <summary>
		/// 
		/// </summary>
		public string SHOP_NAME1
		{
			get { return _SHOP_NAME1; }
			set { _SHOP_NAME1 = value; }
		}

		string _SHOP_NAME2 = "";
		/// <summary>
		/// 
		/// </summary>
		public string SHOP_NAME2
		{
			get { return _SHOP_NAME2; }
			set { _SHOP_NAME2 = value; }
		}

		int _SHOP_KIND = 0;
		/// <summary>
		/// 
		/// </summary>
		public int SHOP_KIND
		{
			get { return _SHOP_KIND; }
			set { _SHOP_KIND = value; }
		}

		string _SHOP_Area_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string SHOP_Area_ID
		{
			get { return _SHOP_Area_ID; }
			set { _SHOP_Area_ID = value; }
		}

		string _SHOP_Price_Area = "";
		/// <summary>
		/// 
		/// </summary>
		public string SHOP_Price_Area
		{
			get { return _SHOP_Price_Area; }
			set { _SHOP_Price_Area = value; }
		}

		string _SHOP_ADD = "";
		/// <summary>
		/// 
		/// </summary>
		public string SHOP_ADD
		{
			get { return _SHOP_ADD; }
			set { _SHOP_ADD = value; }
		}

		string _SHOP_TEL = "";
		/// <summary>
		/// 
		/// </summary>
		public string SHOP_TEL
		{
			get { return _SHOP_TEL; }
			set { _SHOP_TEL = value; }
		}

		string _SHOP_EMAIL = "";
		/// <summary>
		/// 
		/// </summary>
		public string SHOP_EMAIL
		{
			get { return _SHOP_EMAIL; }
			set { _SHOP_EMAIL = value; }
		}

		string _SHOP_CONTECT = "";
		/// <summary>
		/// 
		/// </summary>
		public string SHOP_CONTECT
		{
			get { return _SHOP_CONTECT; }
			set { _SHOP_CONTECT = value; }
		}

		string _SHOP_MEMO = "";
		/// <summary>
		/// 
		/// </summary>
		public string SHOP_MEMO
		{
			get { return _SHOP_MEMO; }
			set { _SHOP_MEMO = value; }
		}

		byte _SHOP_STATUS = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte SHOP_STATUS
		{
			get { return _SHOP_STATUS; }
			set { _SHOP_STATUS = value; }
		}

		int _SHOP_Limited = 0;
		/// <summary>
		/// 
		/// </summary>
		public int SHOP_Limited
		{
			get { return _SHOP_Limited; }
			set { _SHOP_Limited = value; }
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



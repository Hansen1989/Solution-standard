 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// SYS_PARAMATERS表实体类
    /// </summary>
    public partial class SYS_PARAMATERS
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

		string _AREA_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string AREA_ID
		{
			get { return _AREA_ID; }
			set { _AREA_ID = value; }
		}

		int _COL_ORDER_TYPE = 0;
		/// <summary>
		/// 
		/// </summary>
		public int COL_ORDER_TYPE
		{
			get { return _COL_ORDER_TYPE; }
			set { _COL_ORDER_TYPE = value; }
		}

		int _ORDER_PRICE_TYPE = 0;
		/// <summary>
		/// 
		/// </summary>
		public int ORDER_PRICE_TYPE
		{
			get { return _ORDER_PRICE_TYPE; }
			set { _ORDER_PRICE_TYPE = value; }
		}

		int _QUANTITY_TYPE = 0;
		/// <summary>
		/// 
		/// </summary>
		public int QUANTITY_TYPE
		{
			get { return _QUANTITY_TYPE; }
			set { _QUANTITY_TYPE = value; }
		}

		int _EXPECT_DATE_TYPE = 0;
		/// <summary>
		/// 
		/// </summary>
		public int EXPECT_DATE_TYPE
		{
			get { return _EXPECT_DATE_TYPE; }
			set { _EXPECT_DATE_TYPE = value; }
		}

		int _PRD_BOM_TYPE = 0;
		/// <summary>
		/// 
		/// </summary>
		public int PRD_BOM_TYPE
		{
			get { return _PRD_BOM_TYPE; }
			set { _PRD_BOM_TYPE = value; }
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

		string _MEMO = "";
		/// <summary>
		/// 
		/// </summary>
		public string MEMO
		{
			get { return _MEMO; }
			set { _MEMO = value; }
		}

		int _PALN_TYPE = 0;
		/// <summary>
		/// 
		/// </summary>
		public int PALN_TYPE
		{
			get { return _PALN_TYPE; }
			set { _PALN_TYPE = value; }
		}
    } 

}



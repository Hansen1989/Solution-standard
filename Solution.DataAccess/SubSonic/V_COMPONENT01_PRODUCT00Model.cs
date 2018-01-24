 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// V_COMPONENT01_PRODUCT00表实体类
    /// </summary>
    public partial class V_COMPONENT01_PRODUCT00
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

		string _COM_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string COM_ID
		{
			get { return _COM_ID; }
			set { _COM_ID = value; }
		}

		int _DETAIL_ID = 0;
		/// <summary>
		/// 
		/// </summary>
		public int DETAIL_ID
		{
			get { return _DETAIL_ID; }
			set { _DETAIL_ID = value; }
		}

		string _PROD_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string PROD_ID
		{
			get { return _PROD_ID; }
			set { _PROD_ID = value; }
		}

		string _PROD_NAME1 = "";
		/// <summary>
		/// 
		/// </summary>
		public string PROD_NAME1
		{
			get { return _PROD_NAME1; }
			set { _PROD_NAME1 = value; }
		}

		decimal _QUANTITY = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal QUANTITY
		{
			get { return _QUANTITY; }
			set { _QUANTITY = value; }
		}

		decimal _LQUANTITY = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal LQUANTITY
		{
			get { return _LQUANTITY; }
			set { _LQUANTITY = value; }
		}

		string _New_PROD_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string New_PROD_ID
		{
			get { return _New_PROD_ID; }
			set { _New_PROD_ID = value; }
		}

		string _New_PROD_NAME1 = "";
		/// <summary>
		/// 
		/// </summary>
		public string New_PROD_NAME1
		{
			get { return _New_PROD_NAME1; }
			set { _New_PROD_NAME1 = value; }
		}

		byte _IsScales = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte IsScales
		{
			get { return _IsScales; }
			set { _IsScales = value; }
		}

		byte _PrtTag = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte PrtTag
		{
			get { return _PrtTag; }
			set { _PrtTag = value; }
		}

		byte _IsFlag = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte IsFlag
		{
			get { return _IsFlag; }
			set { _IsFlag = value; }
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



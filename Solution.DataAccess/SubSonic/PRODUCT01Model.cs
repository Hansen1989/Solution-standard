 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// PRODUCT01表实体类
    /// </summary>
    public partial class PRODUCT01
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

		string _PRCAREA_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string PRCAREA_ID
		{
			get { return _PRCAREA_ID; }
			set { _PRCAREA_ID = value; }
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

		string _SUP_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string SUP_ID
		{
			get { return _SUP_ID; }
			set { _SUP_ID = value; }
		}

		byte _SEND_TYPE = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte SEND_TYPE
		{
			get { return _SEND_TYPE; }
			set { _SEND_TYPE = value; }
		}

		byte _TAX_TYPE = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte TAX_TYPE
		{
			get { return _TAX_TYPE; }
			set { _TAX_TYPE = value; }
		}

		int _Tax = 0;
		/// <summary>
		/// 
		/// </summary>
		public int Tax
		{
			get { return _Tax; }
			set { _Tax = value; }
		}

		decimal _SUP_COST = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal SUP_COST
		{
			get { return _SUP_COST; }
			set { _SUP_COST = value; }
		}

		decimal _SUP_COST1 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal SUP_COST1
		{
			get { return _SUP_COST1; }
			set { _SUP_COST1 = value; }
		}

		decimal _SUP_COST2 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal SUP_COST2
		{
			get { return _SUP_COST2; }
			set { _SUP_COST2 = value; }
		}

		decimal _SUP_Return = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal SUP_Return
		{
			get { return _SUP_Return; }
			set { _SUP_Return = value; }
		}

		decimal _SUP_Return1 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal SUP_Return1
		{
			get { return _SUP_Return1; }
			set { _SUP_Return1 = value; }
		}

		decimal _SUP_Return2 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal SUP_Return2
		{
			get { return _SUP_Return2; }
			set { _SUP_Return2 = value; }
		}

		decimal _U_Cost = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal U_Cost
		{
			get { return _U_Cost; }
			set { _U_Cost = value; }
		}

		decimal _U_Cost1 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal U_Cost1
		{
			get { return _U_Cost1; }
			set { _U_Cost1 = value; }
		}

		decimal _U_Cost2 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal U_Cost2
		{
			get { return _U_Cost2; }
			set { _U_Cost2 = value; }
		}

		decimal _U_Ret_COST = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal U_Ret_COST
		{
			get { return _U_Ret_COST; }
			set { _U_Ret_COST = value; }
		}

		decimal _U_Ret_COST1 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal U_Ret_COST1
		{
			get { return _U_Ret_COST1; }
			set { _U_Ret_COST1 = value; }
		}

		decimal _U_Ret_COST2 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal U_Ret_COST2
		{
			get { return _U_Ret_COST2; }
			set { _U_Ret_COST2 = value; }
		}

		decimal _T_COST = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal T_COST
		{
			get { return _T_COST; }
			set { _T_COST = value; }
		}

		decimal _T_COST1 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal T_COST1
		{
			get { return _T_COST1; }
			set { _T_COST1 = value; }
		}

		decimal _T_COST2 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal T_COST2
		{
			get { return _T_COST2; }
			set { _T_COST2 = value; }
		}

		decimal _T_Ret_COST = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal T_Ret_COST
		{
			get { return _T_Ret_COST; }
			set { _T_Ret_COST = value; }
		}

		decimal _T_Ret_COST1 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal T_Ret_COST1
		{
			get { return _T_Ret_COST1; }
			set { _T_Ret_COST1 = value; }
		}

		decimal _T_Ret_COST2 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal T_Ret_COST2
		{
			get { return _T_Ret_COST2; }
			set { _T_Ret_COST2 = value; }
		}

		decimal _COST = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal COST
		{
			get { return _COST; }
			set { _COST = value; }
		}

		decimal _COST1 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal COST1
		{
			get { return _COST1; }
			set { _COST1 = value; }
		}

		decimal _COST2 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal COST2
		{
			get { return _COST2; }
			set { _COST2 = value; }
		}

		byte _ENABLE = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte ENABLE
		{
			get { return _ENABLE; }
			set { _ENABLE = value; }
		}

		byte _VISIBLE = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte VISIBLE
		{
			get { return _VISIBLE; }
			set { _VISIBLE = value; }
		}

		string _BOM_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string BOM_ID
		{
			get { return _BOM_ID; }
			set { _BOM_ID = value; }
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

		int _ORDER_UNIT = 0;
		/// <summary>
		/// 
		/// </summary>
		public int ORDER_UNIT
		{
			get { return _ORDER_UNIT; }
			set { _ORDER_UNIT = value; }
		}

		int _ORDER_QUAN = 0;
		/// <summary>
		/// 
		/// </summary>
		public int ORDER_QUAN
		{
			get { return _ORDER_QUAN; }
			set { _ORDER_QUAN = value; }
		}

		int _Purchase_UNIT = 0;
		/// <summary>
		/// 
		/// </summary>
		public int Purchase_UNIT
		{
			get { return _Purchase_UNIT; }
			set { _Purchase_UNIT = value; }
		}

		int _Purchase_QUAN = 0;
		/// <summary>
		/// 
		/// </summary>
		public int Purchase_QUAN
		{
			get { return _Purchase_QUAN; }
			set { _Purchase_QUAN = value; }
		}

		int _SAFE_QUAN = 0;
		/// <summary>
		/// 
		/// </summary>
		public int SAFE_QUAN
		{
			get { return _SAFE_QUAN; }
			set { _SAFE_QUAN = value; }
		}

		decimal _PROD_PRICE = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal PROD_PRICE
		{
			get { return _PROD_PRICE; }
			set { _PROD_PRICE = value; }
		}
    } 

}



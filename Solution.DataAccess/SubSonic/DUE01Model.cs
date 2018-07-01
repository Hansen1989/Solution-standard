 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// DUE01表实体类
    /// </summary>
    public partial class DUE01
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

		string _TAKEIN_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string TAKEIN_ID
		{
			get { return _TAKEIN_ID; }
			set { _TAKEIN_ID = value; }
		}

		int _SNO = 0;
		/// <summary>
		/// 
		/// </summary>
		public int SNO
		{
			get { return _SNO; }
			set { _SNO = value; }
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

		string _STD_UNIT = "";
		/// <summary>
		/// 
		/// </summary>
		public string STD_UNIT
		{
			get { return _STD_UNIT; }
			set { _STD_UNIT = value; }
		}

		decimal _STD_QUAN = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal STD_QUAN
		{
			get { return _STD_QUAN; }
			set { _STD_QUAN = value; }
		}

		decimal _STD_PRICE = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal STD_PRICE
		{
			get { return _STD_PRICE; }
			set { _STD_PRICE = value; }
		}

		decimal _TAX = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal TAX
		{
			get { return _TAX; }
			set { _TAX = value; }
		}

		decimal _QUAN1 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal QUAN1
		{
			get { return _QUAN1; }
			set { _QUAN1 = value; }
		}

		decimal _QUAN2 = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal QUAN2
		{
			get { return _QUAN2; }
			set { _QUAN2 = value; }
		}

		decimal _ITEM_DISC_AMT = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal ITEM_DISC_AMT
		{
			get { return _ITEM_DISC_AMT; }
			set { _ITEM_DISC_AMT = value; }
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

		string _BAT_NO = "";
		/// <summary>
		/// 
		/// </summary>
		public string BAT_NO
		{
			get { return _BAT_NO; }
			set { _BAT_NO = value; }
		}

		decimal _COST = 0;
		/// <summary>
		/// 成本
		/// </summary>
		public decimal COST
		{
			get { return _COST; }
			set { _COST = value; }
		}
    } 

}



 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// OUT_BACK01表实体类
    /// </summary>
    public partial class OUT_BACK01
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

		string _BK_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string BK_ID
		{
			get { return _BK_ID; }
			set { _BK_ID = value; }
		}

		int _SNo = 0;
		/// <summary>
		/// 
		/// </summary>
		public int SNo
		{
			get { return _SNo; }
			set { _SNo = value; }
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

		double _QUANTITY = 0;
		/// <summary>
		/// 
		/// </summary>
		public double QUANTITY
		{
			get { return _QUANTITY; }
			set { _QUANTITY = value; }
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

		int _STD_CONVERT = 0;
		/// <summary>
		/// 
		/// </summary>
		public int STD_CONVERT
		{
			get { return _STD_CONVERT; }
			set { _STD_CONVERT = value; }
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

		decimal _COST = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal COST
		{
			get { return _COST; }
			set { _COST = value; }
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

		string _REASON_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string REASON_ID
		{
			get { return _REASON_ID; }
			set { _REASON_ID = value; }
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

		DateTime _Exp_DateTime = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime Exp_DateTime
		{
			get { return _Exp_DateTime; }
			set { _Exp_DateTime = value; }
		}
    } 

}



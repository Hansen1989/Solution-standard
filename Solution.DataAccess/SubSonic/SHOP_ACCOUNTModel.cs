 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// SHOP_ACCOUNT表实体类
    /// </summary>
    public partial class SHOP_ACCOUNT
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

		string _HEAD_SHOP_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string HEAD_SHOP_ID
		{
			get { return _HEAD_SHOP_ID; }
			set { _HEAD_SHOP_ID = value; }
		}

		decimal _AMOUNT = 0;
		/// <summary>
		/// 
		/// </summary>
		public decimal AMOUNT
		{
			get { return _AMOUNT; }
			set { _AMOUNT = value; }
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

		decimal _CREDIT_AMOUNT = 0;
		/// <summary>
		/// 信用额度
		/// </summary>
		public decimal CREDIT_AMOUNT
		{
			get { return _CREDIT_AMOUNT; }
			set { _CREDIT_AMOUNT = value; }
		}
    } 

}



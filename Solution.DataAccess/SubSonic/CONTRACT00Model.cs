 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// CONTRACT00表实体类
    /// </summary>
    public partial class CONTRACT00
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

		string _CONTRACT_ID = "";
		/// <summary>
		/// 
		/// </summary>
		public string CONTRACT_ID
		{
			get { return _CONTRACT_ID; }
			set { _CONTRACT_ID = value; }
		}

		string _CONTRACT_TITLE = "";
		/// <summary>
		/// 
		/// </summary>
		public string CONTRACT_TITLE
		{
			get { return _CONTRACT_TITLE; }
			set { _CONTRACT_TITLE = value; }
		}

		DateTime _CONTRACTP_SIGN = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime CONTRACTP_SIGN
		{
			get { return _CONTRACTP_SIGN; }
			set { _CONTRACTP_SIGN = value; }
		}

		DateTime _CONTRACTP_STARTTIME = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime CONTRACTP_STARTTIME
		{
			get { return _CONTRACTP_STARTTIME; }
			set { _CONTRACTP_STARTTIME = value; }
		}

		DateTime _CONTRACTP_ENDTIME = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime CONTRACTP_ENDTIME
		{
			get { return _CONTRACTP_ENDTIME; }
			set { _CONTRACTP_ENDTIME = value; }
		}

		byte _USABLE = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte USABLE
		{
			get { return _USABLE; }
			set { _USABLE = value; }
		}

		byte _LOCK = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte LOCK
		{
			get { return _LOCK; }
			set { _LOCK = value; }
		}

		string _FIRST_PARTY = "";
		/// <summary>
		/// 
		/// </summary>
		public string FIRST_PARTY
		{
			get { return _FIRST_PARTY; }
			set { _FIRST_PARTY = value; }
		}

		string _SECEND_PARTY = "";
		/// <summary>
		/// 
		/// </summary>
		public string SECEND_PARTY
		{
			get { return _SECEND_PARTY; }
			set { _SECEND_PARTY = value; }
		}

		string _Meno = "";
		/// <summary>
		/// 
		/// </summary>
		public string Meno
		{
			get { return _Meno; }
			set { _Meno = value; }
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



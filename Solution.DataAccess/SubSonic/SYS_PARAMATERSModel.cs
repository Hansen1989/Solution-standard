 
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

		string _Code = "";
		/// <summary>
		/// 
		/// </summary>
		public string Code
		{
			get { return _Code; }
			set { _Code = value; }
		}

		string _VALUE = "";
		/// <summary>
		/// 
		/// </summary>
		public string VALUE
		{
			get { return _VALUE; }
			set { _VALUE = value; }
		}

		string _KEY_CN = "";
		/// <summary>
		/// 
		/// </summary>
		public string KEY_CN
		{
			get { return _KEY_CN; }
			set { _KEY_CN = value; }
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

		string _Area_Id = "";
		/// <summary>
		/// 
		/// </summary>
		public string Area_Id
		{
			get { return _Area_Id; }
			set { _Area_Id = value; }
		}
    } 

}



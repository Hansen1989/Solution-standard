 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// V_Position_Branch表实体类
    /// </summary>
    public partial class V_Position_Branch
    {

		string _Code = "";
		/// <summary>
		/// 
		/// </summary>
		public string Code
		{
			get { return _Code; }
			set { _Code = value; }
		}

		int _Id = 0;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		string _Name = "";
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		int _Branch_Id = 0;
		/// <summary>
		/// 
		/// </summary>
		public int Branch_Id
		{
			get { return _Branch_Id; }
			set { _Branch_Id = value; }
		}

		string _Branch_Code = "";
		/// <summary>
		/// 
		/// </summary>
		public string Branch_Code
		{
			get { return _Branch_Code; }
			set { _Branch_Code = value; }
		}

		string _Branch_Name = "";
		/// <summary>
		/// 
		/// </summary>
		public string Branch_Name
		{
			get { return _Branch_Name; }
			set { _Branch_Name = value; }
		}

		string _PagePower = "";
		/// <summary>
		/// 
		/// </summary>
		public string PagePower
		{
			get { return _PagePower; }
			set { _PagePower = value; }
		}

		string _ControlPower = "";
		/// <summary>
		/// 
		/// </summary>
		public string ControlPower
		{
			get { return _ControlPower; }
			set { _ControlPower = value; }
		}

		byte _IsSetBranchPower = 0;
		/// <summary>
		/// 
		/// </summary>
		public byte IsSetBranchPower
		{
			get { return _IsSetBranchPower; }
			set { _IsSetBranchPower = value; }
		}

		string _SetBranchCode = "";
		/// <summary>
		/// 
		/// </summary>
		public string SetBranchCode
		{
			get { return _SetBranchCode; }
			set { _SetBranchCode = value; }
		}

		int _Manager_Id = 0;
		/// <summary>
		/// 
		/// </summary>
		public int Manager_Id
		{
			get { return _Manager_Id; }
			set { _Manager_Id = value; }
		}

		string _Manager_CName = "";
		/// <summary>
		/// 
		/// </summary>
		public string Manager_CName
		{
			get { return _Manager_CName; }
			set { _Manager_CName = value; }
		}

		DateTime _UpdateDate = new DateTime(1900,1,1);
		/// <summary>
		/// 
		/// </summary>
		public DateTime UpdateDate
		{
			get { return _UpdateDate; }
			set { _UpdateDate = value; }
		}

		string _Expr1 = "";
		/// <summary>
		/// 
		/// </summary>
		public string Expr1
		{
			get { return _Expr1; }
			set { _Expr1 = value; }
		}

		int _ParentId = 0;
		/// <summary>
		/// 
		/// </summary>
		public int ParentId
		{
			get { return _ParentId; }
			set { _ParentId = value; }
		}

		int _Sort = 0;
		/// <summary>
		/// 
		/// </summary>
		public int Sort
		{
			get { return _Sort; }
			set { _Sort = value; }
		}

		int _Depth = 0;
		/// <summary>
		/// 
		/// </summary>
		public int Depth
		{
			get { return _Depth; }
			set { _Depth = value; }
		}

		string _Notes = "";
		/// <summary>
		/// 
		/// </summary>
		public string Notes
		{
			get { return _Notes; }
			set { _Notes = value; }
		}
    } 

}



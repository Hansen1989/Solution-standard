 
using System;

namespace Solution.DataAccess.Model
{
    /// <summary>
    /// Position表实体类
    /// </summary>
    public partial class Position
    {

		int _Id = 0;
		/// <summary>
		/// 主键Id
		/// </summary>
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		string _Name = "";
		/// <summary>
		/// 职位名称
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		int _Branch_Id = 0;
		/// <summary>
		/// 部门自编号ID
		/// </summary>
		public int Branch_Id
		{
			get { return _Branch_Id; }
			set { _Branch_Id = value; }
		}

		string _Branch_Code = "";
		/// <summary>
		/// 部门编号
		/// </summary>
		public string Branch_Code
		{
			get { return _Branch_Code; }
			set { _Branch_Code = value; }
		}

		string _Branch_Name = "";
		/// <summary>
		/// 部门名称
		/// </summary>
		public string Branch_Name
		{
			get { return _Branch_Name; }
			set { _Branch_Name = value; }
		}

		string _PagePower = "";
		/// <summary>
		/// 菜单操作权限，有操作权限的菜单ID列表：|1|2|3|4|5|
		/// </summary>
		public string PagePower
		{
			get { return _PagePower; }
			set { _PagePower = value; }
		}

		string _ControlPower = "";
		/// <summary>
		/// 页面功能操作权限，各个页面有操作权限的菜单ID和页面权限标志ID列表：|1,1|2,1|2,2|2,4|
		/// </summary>
		public string ControlPower
		{
			get { return _ControlPower; }
			set { _ControlPower = value; }
		}

		byte _IsSetBranchPower = 0;
		/// <summary>
		/// 是否有操作绑定指定部门的权限，0=无，1=有
		/// </summary>
		public byte IsSetBranchPower
		{
			get { return _IsSetBranchPower; }
			set { _IsSetBranchPower = value; }
		}

		string _SetBranchCode = "";
		/// <summary>
		/// 绑定部门的编号
		/// </summary>
		public string SetBranchCode
		{
			get { return _SetBranchCode; }
			set { _SetBranchCode = value; }
		}

		int _Manager_Id = 0;
		/// <summary>
		/// 修改人员id
		/// </summary>
		public int Manager_Id
		{
			get { return _Manager_Id; }
			set { _Manager_Id = value; }
		}

		string _Manager_CName = "";
		/// <summary>
		/// 修改人员姓名
		/// </summary>
		public string Manager_CName
		{
			get { return _Manager_CName; }
			set { _Manager_CName = value; }
		}

		DateTime _UpdateDate = new DateTime(1900,1,1);
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime UpdateDate
		{
			get { return _UpdateDate; }
			set { _UpdateDate = value; }
		}
    } 

}



using System.Collections.Generic;
using System.Web.UI;
using Solution.DataAccess.DbHelper;


namespace Solution.Logic.Managers.Application
{
    public interface ILogicBase
    {
        #region 绑定表格

        void BindGrid(FineUI.Grid grid, int pageIndex = 0, int pageSize = 0,
            List<ConditionFun.SqlqueryCondition> wheres = null, List<string> orders = null);

        void BindGrid(FineUI.Grid grid, int parentValue,
            List<ConditionFun.SqlqueryCondition> wheres = null, List<string> orders = null, string parentId = "ParentId");

        void BindGrid(FineUI.Grid grid, int parentValue, List<string> orders = null, string parentId = "ParentId"); //"ParentId"

      
        #endregion

        #region 删除记录

        void Delete(Page page, int id, bool isAddUseLog = true);

        void Delete(Page page, int[] id, bool isAddUseLog = true);

        #endregion

        #region 保存排序

        bool UpdateSort(Page page, FineUI.Grid grid1, string tbxSort, string sortName = "Sort");

        #endregion

        #region 自动排序

        bool UpdateAutoSort(Page page, string strWhere = "", bool isExistsMoreLv = false, int pid = 0,
            string fieldName = "Sort", string fieldParentId = "ParentId");

        #endregion
    }
}

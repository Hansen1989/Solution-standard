using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using DotNet.Utilities;
using Solution.DataAccess.DataModel;
using System.Linq.Expressions;
using System.Data;

namespace Solution.Logic.Managers
{
    public partial class TABLE_SEEDBll : LogicBase      
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="seed_date">日期，格式YYYYMMDD</param>
        /// <param name="num">效验码位数，不足部分前面补0</param>
        /// <returns></returns>
        public string GetTableSeed(string table_name,string seed_date,int num)
        {
            string result="";
            try
            {
                DataSet dsCom = null;
                dsCom = (DataSet)SPs.GET_TABLE_SEED(table_name, seed_date).ExecuteDataSet();
                if (dsCom.Tables.Count > 0)
                {
                    if (dsCom.Tables[0].Rows.Count > 0)
                    {
                        result = dsCom.Tables[0].Rows[0]["ret"].ToString();
                    }
                    else
                    {
                        result = "0";
                    }
                }
                else
                {
                    result = "0";
                }
            }
            catch
            {
                result ="0";
            }
            for(int i=result.Length;i<num;i++)
            {
                result="0"+result;
            }

            return seed_date+result;
        }
    }
}

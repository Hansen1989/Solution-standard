using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solution.DataAccess.Model.ObjectEntity
{
    public class DueMain
    {
        public long Id { get; set; }
        //进货单审核日期
        public DateTime APP_DATETIME { get; set; }
        //进货单审核人
        public string APP_USER { get; set; }
        //应付账单创建日期
        public DateTime CRT_DATETIME { get; set; }
        //应付账单创建人
        public String CRT_USER_ID { get; set; }
        //进货单日期
        public DateTime INPUT_DATE { get; set; }
        //发票
        public string INVOICE_ID { get; set; }
        //应付账单最后修改日期
        public DateTime LAST_UPDATE { get; set; }
        //备注
        public string Memo { get; set; }
        //更新时间
        public DateTime MOD_DATETIME { get; set; }
        //修改人
        public string MOD_USER_ID { get; set; }
        //预付款
        public decimal PRE_PAY { get; set; }
        //预付款单号
        public string PRE_PAY_ID { get; set; }
        //关联ID
        public string RELATE_ID { get; set; }
        //进货分店编号
        public string SHOP_ID { get; set; }
        //待核准状态
        public int STATUS { get; set; }
        //供应商编号
        public string SUP_ID { get; set; }
        //进货单号
        public string TAKEIN_ID { get; set; }
        //进货类型
        public int TAKEIN_TYPE { get; set; }
        public decimal TOT_AMOUNT { get; set; }
        //进货单数量
        public decimal TOT_QTY { get; set; }
        //税额
        public decimal TOT_TAX { get; set; }
        public string USER_ID { get; set; }
    }
}

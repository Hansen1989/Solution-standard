using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solution.DataAccess.Model.ObjectEntity
{
    public class ReceiveBillMain
    {
        public long Id { get; set; }

        public string SHOP_ID { get; set; }

        public string BILL_ID { get; set; }

        public int STATUS { get; set; }

        public DateTime INPUT_DATE { get; set; }

        public string IN_SHOP { get; set; }

        public string USER_ID { get; set; }

        public string APP_USER { get; set; }

        public DateTime APP_DATETIME { get; set; }

        public string MEMO { get; set; }

        public DateTime CRT_DATETIME { get; set; }

        public string CRT_USER_ID { get; set; }

        public DateTime MOD_DATETIME { get; set; }

        public string MOD_USER_ID { get; set; }

        public DateTime LAST_UPDATE { get; set; }

        public decimal BILL_AMOUNT { get; set; }

        public decimal BILL_COST { get; set; }

        /// <summary>
        /// 1 - 出货单
        /// 2 - 退货单
        /// </summary>
        public int BILL_TYPE { get; set; }
    }
}

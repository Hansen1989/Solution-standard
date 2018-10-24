


  
using System;
using System.Data;
using SubSonic.Schema;
using SubSonic.DataProviders;

namespace Solution.DataAccess.DataModel{
	public partial class SPs{

        public static StoredProcedure ADD_ARCHIVEORDERS(string ORD_USER_C,string ORD_DEP_ID_C,string Import_Shop_C,string COL_BeginDate,string COL_EndDate,int IsTime){
            StoredProcedure sp=new StoredProcedure("ADD_ARCHIVEORDERS");
			

            sp.Command.AddParameter("ORD_USER_C",ORD_USER_C,DbType.AnsiString);
            sp.Command.AddParameter("ORD_DEP_ID_C",ORD_DEP_ID_C,DbType.AnsiString);
            sp.Command.AddParameter("Import_Shop_C",Import_Shop_C,DbType.AnsiString);
            sp.Command.AddParameter("COL_BeginDate",COL_BeginDate,DbType.AnsiString);
            sp.Command.AddParameter("COL_EndDate",COL_EndDate,DbType.AnsiString);
            sp.Command.AddParameter("IsTime",IsTime,DbType.Int32);
            return sp;
        }
        public static StoredProcedure ADD_PLAN_PURCHASE(string COL_ID,string SHOP_ID_NOW,string USER_ID,int ISPP){
            StoredProcedure sp=new StoredProcedure("ADD_PLAN_PURCHASE");
			

            sp.Command.AddParameter("COL_ID",COL_ID,DbType.AnsiString);
            sp.Command.AddParameter("SHOP_ID_NOW",SHOP_ID_NOW,DbType.AnsiString);
            sp.Command.AddParameter("USER_ID",USER_ID,DbType.AnsiString);
            sp.Command.AddParameter("ISPP",ISPP,DbType.Int32);
            return sp;
        }
        public static StoredProcedure Delete_COMPONENT00_01(string COM_ID){
            StoredProcedure sp=new StoredProcedure("Delete_COMPONENT00_01");
			

            sp.Command.AddParameter("COM_ID",COM_ID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Delete_ORDER_DOP00_01_02(int Id){
            StoredProcedure sp=new StoredProcedure("Delete_ORDER_DOP00_01_02");
			

            sp.Command.AddParameter("Id",Id,DbType.Int32);
            return sp;
        }
        public static StoredProcedure GET_ARCHIVEORDERS_LEFT_LIST(string COL_ID){
            StoredProcedure sp=new StoredProcedure("GET_ARCHIVEORDERS_LEFT_LIST");
			

            sp.Command.AddParameter("COL_ID",COL_ID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure GET_ARCHIVEORDERS_RIGHT_LIST(string PROD_ID,string COL_ID){
            StoredProcedure sp=new StoredProcedure("GET_ARCHIVEORDERS_RIGHT_LIST");
			

            sp.Command.AddParameter("PROD_ID",PROD_ID,DbType.AnsiString);
            sp.Command.AddParameter("COL_ID",COL_ID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Get_COMPONENT00List(){
            StoredProcedure sp=new StoredProcedure("Get_COMPONENT00List");
			

            return sp;
        }
        public static StoredProcedure GET_COMPONENT01List(string PROD_ID){
            StoredProcedure sp=new StoredProcedure("GET_COMPONENT01List");
			

            sp.Command.AddParameter("PROD_ID",PROD_ID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Get_CONTRACT01_PRODUCT01(string UserHashKey,string PROD_ID){
            StoredProcedure sp=new StoredProcedure("Get_CONTRACT01_PRODUCT01");
			

            sp.Command.AddParameter("UserHashKey",UserHashKey,DbType.AnsiString);
            sp.Command.AddParameter("PROD_ID",PROD_ID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Get_MAX_Inventory_DATE(){
            StoredProcedure sp=new StoredProcedure("Get_MAX_Inventory_DATE");
			

            return sp;
        }
        public static StoredProcedure GET_ORDER_DEP00_ORDER_DEP01_LIST(string SHOP_ID){
            StoredProcedure sp=new StoredProcedure("GET_ORDER_DEP00_ORDER_DEP01_LIST");
			

            sp.Command.AddParameter("SHOP_ID",SHOP_ID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Get_ORDER_DEP01_SHOP(int ret,string ORDDEP_ID){
            StoredProcedure sp=new StoredProcedure("Get_ORDER_DEP01_SHOP");
			

            sp.Command.AddParameter("ret",ret,DbType.Int32);
            sp.Command.AddParameter("ORDDEP_ID",ORDDEP_ID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Get_ORDER_SEED(string shop_id,string tablename){
            StoredProcedure sp=new StoredProcedure("Get_ORDER_SEED");
			

            sp.Command.AddParameter("shop_id",shop_id,DbType.AnsiString);
            sp.Command.AddParameter("tablename",tablename,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Get_ORDER01_PRODUCT00_PRODUCT01(string ORDER_ID,string PRCAREA_ID){
            StoredProcedure sp=new StoredProcedure("Get_ORDER01_PRODUCT00_PRODUCT01");
			

            sp.Command.AddParameter("ORDER_ID",ORDER_ID,DbType.AnsiString);
            sp.Command.AddParameter("PRCAREA_ID",PRCAREA_ID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure GET_OUT00_STOCK_INFO(string OUT_ID){
            StoredProcedure sp=new StoredProcedure("GET_OUT00_STOCK_INFO");
			

            sp.Command.AddParameter("OUT_ID",OUT_ID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Get_PLAN_Left_List(string plan_id){
            StoredProcedure sp=new StoredProcedure("Get_PLAN_Left_List");
			

            sp.Command.AddParameter("plan_id",plan_id,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Get_PLAN_Right_List(string plan_id){
            StoredProcedure sp=new StoredProcedure("Get_PLAN_Right_List");
			

            sp.Command.AddParameter("plan_id",plan_id,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Get_PROD_KIND_DEP_CATE(string type){
            StoredProcedure sp=new StoredProcedure("Get_PROD_KIND_DEP_CATE");
			

            sp.Command.AddParameter("type",type,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure GET_PRODUCT00_PRODUCT01_LIST(string PRODUCT_ID,string SHOP_ID){
            StoredProcedure sp=new StoredProcedure("GET_PRODUCT00_PRODUCT01_LIST");
			

            sp.Command.AddParameter("PRODUCT_ID",PRODUCT_ID,DbType.AnsiString);
            sp.Command.AddParameter("SHOP_ID",SHOP_ID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Get_Purchase00(string st,string et,int date_type){
            StoredProcedure sp=new StoredProcedure("Get_Purchase00");
			

            sp.Command.AddParameter("st",st,DbType.AnsiString);
            sp.Command.AddParameter("et",et,DbType.AnsiString);
            sp.Command.AddParameter("date_type",date_type,DbType.Int32);
            return sp;
        }
        public static StoredProcedure Get_Purchase00_SEED(string shop_id){
            StoredProcedure sp=new StoredProcedure("Get_Purchase00_SEED");
			

            sp.Command.AddParameter("shop_id",shop_id,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure GET_STOCK01_PROD(string STOCK_ID,string INV_ID,string SHOP_ID,string INV_TYPE){
            StoredProcedure sp=new StoredProcedure("GET_STOCK01_PROD");
			

            sp.Command.AddParameter("STOCK_ID",STOCK_ID,DbType.AnsiString);
            sp.Command.AddParameter("INV_ID",INV_ID,DbType.AnsiString);
            sp.Command.AddParameter("SHOP_ID",SHOP_ID,DbType.AnsiString);
            sp.Command.AddParameter("INV_TYPE",INV_TYPE,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure GET_TABLE_SEED(string TABLE_NAME,string SEED_DATETIME){
            StoredProcedure sp=new StoredProcedure("GET_TABLE_SEED");
			

            sp.Command.AddParameter("TABLE_NAME",TABLE_NAME,DbType.AnsiString);
            sp.Command.AddParameter("SEED_DATETIME",SEED_DATETIME,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure IN_OUT01_IN01(string OUT_ID,string IN_ID,string SHOP_ID){
            StoredProcedure sp=new StoredProcedure("IN_OUT01_IN01");
			

            sp.Command.AddParameter("OUT_ID",OUT_ID,DbType.AnsiString);
            sp.Command.AddParameter("IN_ID",IN_ID,DbType.AnsiString);
            sp.Command.AddParameter("SHOP_ID",SHOP_ID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure IN_OUTBACK01_INBACK01(string BK_ID,string IB_ID,string SHOP_ID){
            StoredProcedure sp=new StoredProcedure("IN_OUTBACK01_INBACK01");
			

            sp.Command.AddParameter("BK_ID",BK_ID,DbType.AnsiString);
            sp.Command.AddParameter("IB_ID",IB_ID,DbType.AnsiString);
            sp.Command.AddParameter("SHOP_ID",SHOP_ID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Insert_PRODUCT01(string PROD_ID,string CRT_USER_ID){
            StoredProcedure sp=new StoredProcedure("Insert_PRODUCT01");
			

            sp.Command.AddParameter("PROD_ID",PROD_ID,DbType.AnsiString);
            sp.Command.AddParameter("CRT_USER_ID",CRT_USER_ID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure INTO_Stock_IN_BACK(string IB_ID){
            StoredProcedure sp=new StoredProcedure("INTO_Stock_IN_BACK");
			

            sp.Command.AddParameter("IB_ID",IB_ID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure SplitOrders(string col_id,string ORD_USER){
            StoredProcedure sp=new StoredProcedure("SplitOrders");
			

            sp.Command.AddParameter("col_id",col_id,DbType.AnsiString);
            sp.Command.AddParameter("ORD_USER",ORD_USER,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Tran_PRICE_UNIT(string PROD_ID,decimal P_PRICE,int UNIT_TYPE){
            StoredProcedure sp=new StoredProcedure("Tran_PRICE_UNIT");
			

            sp.Command.AddParameter("PROD_ID",PROD_ID,DbType.AnsiString);
            sp.Command.AddParameter("P_PRICE",P_PRICE,DbType.Decimal);
            sp.Command.AddParameter("UNIT_TYPE",UNIT_TYPE,DbType.Int32);
            return sp;
        }
        public static StoredProcedure Update_in_back00_stock01(string IB_id){
            StoredProcedure sp=new StoredProcedure("Update_in_back00_stock01");
			

            sp.Command.AddParameter("IB_id",IB_id,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Update_in_back00_stock01_cancel(string ib_id){
            StoredProcedure sp=new StoredProcedure("Update_in_back00_stock01_cancel");
			

            sp.Command.AddParameter("ib_id",ib_id,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Update_in00_stock01(string IN_id){
            StoredProcedure sp=new StoredProcedure("Update_in00_stock01");
			

            sp.Command.AddParameter("IN_id",IN_id,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Update_in00_stock01_cancel(string IN_id){
            StoredProcedure sp=new StoredProcedure("Update_in00_stock01_cancel");
			

            sp.Command.AddParameter("IN_id",IN_id,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Update_out_back00_stock01(string BK_id){
            StoredProcedure sp=new StoredProcedure("Update_out_back00_stock01");
			

            sp.Command.AddParameter("BK_id",BK_id,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Update_out_back00_stock01_cancel(string BK_id){
            StoredProcedure sp=new StoredProcedure("Update_out_back00_stock01_cancel");
			

            sp.Command.AddParameter("BK_id",BK_id,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Update_out00_stock01(string out_id){
            StoredProcedure sp=new StoredProcedure("Update_out00_stock01");
			

            sp.Command.AddParameter("out_id",out_id,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Update_out00_stock01_cancel(string out_id){
            StoredProcedure sp=new StoredProcedure("Update_out00_stock01_cancel");
			

            sp.Command.AddParameter("out_id",out_id,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure UPDATE_Purchase00(string Purchase_ID,int STATUS,string SUP_ID,DateTime APP_DATETIME,string MOD_USER_ID){
            StoredProcedure sp=new StoredProcedure("UPDATE_Purchase00");
			

            sp.Command.AddParameter("Purchase_ID",Purchase_ID,DbType.AnsiString);
            sp.Command.AddParameter("STATUS",STATUS,DbType.Int32);
            sp.Command.AddParameter("SUP_ID",SUP_ID,DbType.AnsiString);
            sp.Command.AddParameter("APP_DATETIME",APP_DATETIME,DbType.DateTime);
            sp.Command.AddParameter("MOD_USER_ID",MOD_USER_ID,DbType.AnsiString);
            return sp;
        }
        public static StoredProcedure Update_Purchase00_TOT(string SHOP_ID,string PURCHASE_ID){
            StoredProcedure sp=new StoredProcedure("Update_Purchase00_TOT");
			

            sp.Command.AddParameter("SHOP_ID",SHOP_ID,DbType.AnsiString);
            sp.Command.AddParameter("PURCHASE_ID",PURCHASE_ID,DbType.AnsiString);
            return sp;
        }
	
	}
	
}
 
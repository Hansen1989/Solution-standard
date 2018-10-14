 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: V_Product01_PRCAREA
        /// Primary Key: 
        /// </summary>

        public class V_Product01_PRCAREAStructs: DatabaseTable {
            
            public V_Product01_PRCAREAStructs(IDataProvider provider):base("V_Product01_PRCAREA",provider){
                ClassName = "V_Product01_PRCAREA";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Id"
                });

                Columns.Add(new DatabaseColumn("PRCAREA_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "PRCAREA_ID"
                });

                Columns.Add(new DatabaseColumn("PRCAREA_NAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "PRCAREA_NAME"
                });

                Columns.Add(new DatabaseColumn("PROD_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "PROD_ID"
                });

                Columns.Add(new DatabaseColumn("PROD_NAME1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40,
					PropertyName = "PROD_NAME1"
                });

                Columns.Add(new DatabaseColumn("PROD_NAME1_SPELLING", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40,
					PropertyName = "PROD_NAME1_SPELLING"
                });

                Columns.Add(new DatabaseColumn("PROD_KIND", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "PROD_KIND"
                });

                Columns.Add(new DatabaseColumn("PROD_DEP", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "PROD_DEP"
                });

                Columns.Add(new DatabaseColumn("PROD_CATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "PROD_CATE"
                });

                Columns.Add(new DatabaseColumn("PROD_UNIT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "PROD_UNIT"
                });

                Columns.Add(new DatabaseColumn("UNIT_NAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "UNIT_NAME"
                });

                Columns.Add(new DatabaseColumn("PROD_UNIT1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "PROD_UNIT1"
                });

                Columns.Add(new DatabaseColumn("UNIT_NAME1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "UNIT_NAME1"
                });

                Columns.Add(new DatabaseColumn("PROD_CONVERT1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "PROD_CONVERT1"
                });

                Columns.Add(new DatabaseColumn("PROD_UNIT2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "PROD_UNIT2"
                });

                Columns.Add(new DatabaseColumn("UNIT_NAME2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "UNIT_NAME2"
                });

                Columns.Add(new DatabaseColumn("PROD_CONVERT2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "PROD_CONVERT2"
                });

                Columns.Add(new DatabaseColumn("SUP_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "SUP_ID"
                });

                Columns.Add(new DatabaseColumn("SUP_NAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "SUP_NAME"
                });

                Columns.Add(new DatabaseColumn("SEND_TYPE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SEND_TYPE"
                });

                Columns.Add(new DatabaseColumn("TAX_TYPE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "TAX_TYPE"
                });

                Columns.Add(new DatabaseColumn("Tax", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Tax"
                });

                Columns.Add(new DatabaseColumn("SUP_COST", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SUP_COST"
                });

                Columns.Add(new DatabaseColumn("SUP_COST1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SUP_COST1"
                });

                Columns.Add(new DatabaseColumn("SUP_COST2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SUP_COST2"
                });

                Columns.Add(new DatabaseColumn("SUP_Return", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SUP_Return"
                });

                Columns.Add(new DatabaseColumn("SUP_Return1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SUP_Return1"
                });

                Columns.Add(new DatabaseColumn("SUP_Return2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SUP_Return2"
                });

                Columns.Add(new DatabaseColumn("U_Cost", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "U_Cost"
                });

                Columns.Add(new DatabaseColumn("U_Cost1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "U_Cost1"
                });

                Columns.Add(new DatabaseColumn("U_Cost2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "U_Cost2"
                });

                Columns.Add(new DatabaseColumn("U_Ret_COST", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "U_Ret_COST"
                });

                Columns.Add(new DatabaseColumn("U_Ret_COST1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "U_Ret_COST1"
                });

                Columns.Add(new DatabaseColumn("U_Ret_COST2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "U_Ret_COST2"
                });

                Columns.Add(new DatabaseColumn("T_COST", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T_COST"
                });

                Columns.Add(new DatabaseColumn("T_COST1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T_COST1"
                });

                Columns.Add(new DatabaseColumn("T_COST2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T_COST2"
                });

                Columns.Add(new DatabaseColumn("T_Ret_COST", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T_Ret_COST"
                });

                Columns.Add(new DatabaseColumn("T_Ret_COST1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T_Ret_COST1"
                });

                Columns.Add(new DatabaseColumn("T_Ret_COST2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "T_Ret_COST2"
                });

                Columns.Add(new DatabaseColumn("COST", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "COST"
                });

                Columns.Add(new DatabaseColumn("COST1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "COST1"
                });

                Columns.Add(new DatabaseColumn("COST2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "COST2"
                });

                Columns.Add(new DatabaseColumn("ORDER_UNIT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ORDER_UNIT"
                });

                Columns.Add(new DatabaseColumn("ORDER_NAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "ORDER_NAME"
                });

                Columns.Add(new DatabaseColumn("ORDER_QUAN", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ORDER_QUAN"
                });

                Columns.Add(new DatabaseColumn("Purchase_UNIT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Purchase_UNIT"
                });

                Columns.Add(new DatabaseColumn("Purchase_UNIT_NAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "Purchase_UNIT_NAME"
                });

                Columns.Add(new DatabaseColumn("Purchase_QUAN", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Purchase_QUAN"
                });

                Columns.Add(new DatabaseColumn("SAFE_QUAN", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SAFE_QUAN"
                });

                Columns.Add(new DatabaseColumn("PROD_PRICE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "PROD_PRICE"
                });

                Columns.Add(new DatabaseColumn("ENABLE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ENABLE"
                });

                Columns.Add(new DatabaseColumn("VISIBLE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "VISIBLE"
                });

                Columns.Add(new DatabaseColumn("BOM_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "BOM_ID"
                });

                Columns.Add(new DatabaseColumn("CRT_DATETIME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "CRT_DATETIME"
                });

                Columns.Add(new DatabaseColumn("CRT_USER_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "CRT_USER_ID"
                });

                Columns.Add(new DatabaseColumn("MOD_DATETIME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "MOD_DATETIME"
                });

                Columns.Add(new DatabaseColumn("MOD_USER_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "MOD_USER_ID"
                });

                Columns.Add(new DatabaseColumn("LAST_UPDATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "LAST_UPDATE"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn PRCAREA_ID{
                get{
                    return this.GetColumn("PRCAREA_ID");
                }
            }
				
            
            public IColumn PRCAREA_NAME{
                get{
                    return this.GetColumn("PRCAREA_NAME");
                }
            }
				
            
            public IColumn PROD_ID{
                get{
                    return this.GetColumn("PROD_ID");
                }
            }
				
            
            public IColumn PROD_NAME1{
                get{
                    return this.GetColumn("PROD_NAME1");
                }
            }
				
            
            public IColumn PROD_NAME1_SPELLING{
                get{
                    return this.GetColumn("PROD_NAME1_SPELLING");
                }
            }
				
            
            public IColumn PROD_KIND{
                get{
                    return this.GetColumn("PROD_KIND");
                }
            }
				
            
            public IColumn PROD_DEP{
                get{
                    return this.GetColumn("PROD_DEP");
                }
            }
				
            
            public IColumn PROD_CATE{
                get{
                    return this.GetColumn("PROD_CATE");
                }
            }
				
            
            public IColumn PROD_UNIT{
                get{
                    return this.GetColumn("PROD_UNIT");
                }
            }
				
            
            public IColumn UNIT_NAME{
                get{
                    return this.GetColumn("UNIT_NAME");
                }
            }
				
            
            public IColumn PROD_UNIT1{
                get{
                    return this.GetColumn("PROD_UNIT1");
                }
            }
				
            
            public IColumn UNIT_NAME1{
                get{
                    return this.GetColumn("UNIT_NAME1");
                }
            }
				
            
            public IColumn PROD_CONVERT1{
                get{
                    return this.GetColumn("PROD_CONVERT1");
                }
            }
				
            
            public IColumn PROD_UNIT2{
                get{
                    return this.GetColumn("PROD_UNIT2");
                }
            }
				
            
            public IColumn UNIT_NAME2{
                get{
                    return this.GetColumn("UNIT_NAME2");
                }
            }
				
            
            public IColumn PROD_CONVERT2{
                get{
                    return this.GetColumn("PROD_CONVERT2");
                }
            }
				
            
            public IColumn SUP_ID{
                get{
                    return this.GetColumn("SUP_ID");
                }
            }
				
            
            public IColumn SUP_NAME{
                get{
                    return this.GetColumn("SUP_NAME");
                }
            }
				
            
            public IColumn SEND_TYPE{
                get{
                    return this.GetColumn("SEND_TYPE");
                }
            }
				
            
            public IColumn TAX_TYPE{
                get{
                    return this.GetColumn("TAX_TYPE");
                }
            }
				
            
            public IColumn Tax{
                get{
                    return this.GetColumn("Tax");
                }
            }
				
            
            public IColumn SUP_COST{
                get{
                    return this.GetColumn("SUP_COST");
                }
            }
				
            
            public IColumn SUP_COST1{
                get{
                    return this.GetColumn("SUP_COST1");
                }
            }
				
            
            public IColumn SUP_COST2{
                get{
                    return this.GetColumn("SUP_COST2");
                }
            }
				
            
            public IColumn SUP_Return{
                get{
                    return this.GetColumn("SUP_Return");
                }
            }
				
            
            public IColumn SUP_Return1{
                get{
                    return this.GetColumn("SUP_Return1");
                }
            }
				
            
            public IColumn SUP_Return2{
                get{
                    return this.GetColumn("SUP_Return2");
                }
            }
				
            
            public IColumn U_Cost{
                get{
                    return this.GetColumn("U_Cost");
                }
            }
				
            
            public IColumn U_Cost1{
                get{
                    return this.GetColumn("U_Cost1");
                }
            }
				
            
            public IColumn U_Cost2{
                get{
                    return this.GetColumn("U_Cost2");
                }
            }
				
            
            public IColumn U_Ret_COST{
                get{
                    return this.GetColumn("U_Ret_COST");
                }
            }
				
            
            public IColumn U_Ret_COST1{
                get{
                    return this.GetColumn("U_Ret_COST1");
                }
            }
				
            
            public IColumn U_Ret_COST2{
                get{
                    return this.GetColumn("U_Ret_COST2");
                }
            }
				
            
            public IColumn T_COST{
                get{
                    return this.GetColumn("T_COST");
                }
            }
				
            
            public IColumn T_COST1{
                get{
                    return this.GetColumn("T_COST1");
                }
            }
				
            
            public IColumn T_COST2{
                get{
                    return this.GetColumn("T_COST2");
                }
            }
				
            
            public IColumn T_Ret_COST{
                get{
                    return this.GetColumn("T_Ret_COST");
                }
            }
				
            
            public IColumn T_Ret_COST1{
                get{
                    return this.GetColumn("T_Ret_COST1");
                }
            }
				
            
            public IColumn T_Ret_COST2{
                get{
                    return this.GetColumn("T_Ret_COST2");
                }
            }
				
            
            public IColumn COST{
                get{
                    return this.GetColumn("COST");
                }
            }
				
            
            public IColumn COST1{
                get{
                    return this.GetColumn("COST1");
                }
            }
				
            
            public IColumn COST2{
                get{
                    return this.GetColumn("COST2");
                }
            }
				
            
            public IColumn ORDER_UNIT{
                get{
                    return this.GetColumn("ORDER_UNIT");
                }
            }
				
            
            public IColumn ORDER_NAME{
                get{
                    return this.GetColumn("ORDER_NAME");
                }
            }
				
            
            public IColumn ORDER_QUAN{
                get{
                    return this.GetColumn("ORDER_QUAN");
                }
            }
				
            
            public IColumn Purchase_UNIT{
                get{
                    return this.GetColumn("Purchase_UNIT");
                }
            }
				
            
            public IColumn Purchase_UNIT_NAME{
                get{
                    return this.GetColumn("Purchase_UNIT_NAME");
                }
            }
				
            
            public IColumn Purchase_QUAN{
                get{
                    return this.GetColumn("Purchase_QUAN");
                }
            }
				
            
            public IColumn SAFE_QUAN{
                get{
                    return this.GetColumn("SAFE_QUAN");
                }
            }
				
            
            public IColumn PROD_PRICE{
                get{
                    return this.GetColumn("PROD_PRICE");
                }
            }
				
            
            public IColumn ENABLE{
                get{
                    return this.GetColumn("ENABLE");
                }
            }
				
            
            public IColumn VISIBLE{
                get{
                    return this.GetColumn("VISIBLE");
                }
            }
				
            
            public IColumn BOM_ID{
                get{
                    return this.GetColumn("BOM_ID");
                }
            }
				
            
            public IColumn CRT_DATETIME{
                get{
                    return this.GetColumn("CRT_DATETIME");
                }
            }
				
            
            public IColumn CRT_USER_ID{
                get{
                    return this.GetColumn("CRT_USER_ID");
                }
            }
				
            
            public IColumn MOD_DATETIME{
                get{
                    return this.GetColumn("MOD_DATETIME");
                }
            }
				
            
            public IColumn MOD_USER_ID{
                get{
                    return this.GetColumn("MOD_USER_ID");
                }
            }
				
            
            public IColumn LAST_UPDATE{
                get{
                    return this.GetColumn("LAST_UPDATE");
                }
            }
				
            
                    
        }
        
}

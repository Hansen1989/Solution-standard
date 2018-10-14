 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: V_OUT01_PRODUCT00
        /// Primary Key: 
        /// </summary>

        public class V_OUT01_PRODUCT00Structs: DatabaseTable {
            
            public V_OUT01_PRODUCT00Structs(IDataProvider provider):base("V_OUT01_PRODUCT00",provider){
                ClassName = "V_OUT01_PRODUCT00";
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

                Columns.Add(new DatabaseColumn("SHOP_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "SHOP_ID"
                });

                Columns.Add(new DatabaseColumn("OUT_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "OUT_ID"
                });

                Columns.Add(new DatabaseColumn("SNo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SNo"
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

                Columns.Add(new DatabaseColumn("QUANTITY", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "QUANTITY"
                });

                Columns.Add(new DatabaseColumn("STD_UNIT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "STD_UNIT"
                });

                Columns.Add(new DatabaseColumn("STD_CONVERT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "STD_CONVERT"
                });

                Columns.Add(new DatabaseColumn("STD_QUAN", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "STD_QUAN"
                });

                Columns.Add(new DatabaseColumn("STD_PRICE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "STD_PRICE"
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

                Columns.Add(new DatabaseColumn("QUAN1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "QUAN1"
                });

                Columns.Add(new DatabaseColumn("QUAN2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "QUAN2"
                });

                Columns.Add(new DatabaseColumn("MEMO", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200,
					PropertyName = "MEMO"
                });

                Columns.Add(new DatabaseColumn("BAT_NO", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40,
					PropertyName = "BAT_NO"
                });

                Columns.Add(new DatabaseColumn("Exp_DateTime", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Exp_DateTime"
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

                Columns.Add(new DatabaseColumn("STD_UNIT_NAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "STD_UNIT_NAME"
                });

                Columns.Add(new DatabaseColumn("COST1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "COST1"
                });

                Columns.Add(new DatabaseColumn("COST2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "COST2"
                });

                Columns.Add(new DatabaseColumn("COST3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "COST3"
                });

                Columns.Add(new DatabaseColumn("STD_PRICE1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "STD_PRICE1"
                });

                Columns.Add(new DatabaseColumn("STD_PRICE2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "STD_PRICE2"
                });

                Columns.Add(new DatabaseColumn("STD_PRICE3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "STD_PRICE3"
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

                Columns.Add(new DatabaseColumn("PRCAREA_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "PRCAREA_ID"
                });

                Columns.Add(new DatabaseColumn("TAX_TYPE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "TAX_TYPE"
                });

                Columns.Add(new DatabaseColumn("Tax_Num", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Tax_Num"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn SHOP_ID{
                get{
                    return this.GetColumn("SHOP_ID");
                }
            }
				
            
            public IColumn OUT_ID{
                get{
                    return this.GetColumn("OUT_ID");
                }
            }
				
            
            public IColumn SNo{
                get{
                    return this.GetColumn("SNo");
                }
            }
				
            
            public IColumn PROD_ID{
                get{
                    return this.GetColumn("PROD_ID");
                }
            }
				
            
            public IColumn QUANTITY{
                get{
                    return this.GetColumn("QUANTITY");
                }
            }
				
            
            public IColumn STD_UNIT{
                get{
                    return this.GetColumn("STD_UNIT");
                }
            }
				
            
            public IColumn STD_CONVERT{
                get{
                    return this.GetColumn("STD_CONVERT");
                }
            }
				
            
            public IColumn STD_QUAN{
                get{
                    return this.GetColumn("STD_QUAN");
                }
            }
				
            
            public IColumn STD_PRICE{
                get{
                    return this.GetColumn("STD_PRICE");
                }
            }
				
            
            public IColumn COST{
                get{
                    return this.GetColumn("COST");
                }
            }
				
            
            public IColumn QUAN1{
                get{
                    return this.GetColumn("QUAN1");
                }
            }
				
            
            public IColumn QUAN2{
                get{
                    return this.GetColumn("QUAN2");
                }
            }
				
            
            public IColumn MEMO{
                get{
                    return this.GetColumn("MEMO");
                }
            }
				
            
            public IColumn BAT_NO{
                get{
                    return this.GetColumn("BAT_NO");
                }
            }
				
            
            public IColumn Exp_DateTime{
                get{
                    return this.GetColumn("Exp_DateTime");
                }
            }
				
            
            public IColumn PROD_NAME1{
                get{
                    return this.GetColumn("PROD_NAME1");
                }
            }
				
            
            public IColumn STD_UNIT_NAME{
                get{
                    return this.GetColumn("STD_UNIT_NAME");
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
				
            
            public IColumn COST3{
                get{
                    return this.GetColumn("COST3");
                }
            }
				
            
            public IColumn STD_PRICE1{
                get{
                    return this.GetColumn("STD_PRICE1");
                }
            }
				
            
            public IColumn STD_PRICE2{
                get{
                    return this.GetColumn("STD_PRICE2");
                }
            }
				
            
            public IColumn STD_PRICE3{
                get{
                    return this.GetColumn("STD_PRICE3");
                }
            }
				
            
            public IColumn UNIT_NAME{
                get{
                    return this.GetColumn("UNIT_NAME");
                }
            }
				
            
            public IColumn UNIT_NAME1{
                get{
                    return this.GetColumn("UNIT_NAME1");
                }
            }
				
            
            public IColumn UNIT_NAME2{
                get{
                    return this.GetColumn("UNIT_NAME2");
                }
            }
				
            
            public IColumn PROD_CONVERT1{
                get{
                    return this.GetColumn("PROD_CONVERT1");
                }
            }
				
            
            public IColumn PROD_CONVERT2{
                get{
                    return this.GetColumn("PROD_CONVERT2");
                }
            }
				
            
            public IColumn PRCAREA_ID{
                get{
                    return this.GetColumn("PRCAREA_ID");
                }
            }
				
            
            public IColumn TAX_TYPE{
                get{
                    return this.GetColumn("TAX_TYPE");
                }
            }
				
            
            public IColumn Tax_Num{
                get{
                    return this.GetColumn("Tax_Num");
                }
            }
				
            
                    
        }
        
}

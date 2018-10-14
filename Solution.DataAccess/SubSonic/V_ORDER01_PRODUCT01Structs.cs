 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: V_ORDER01_PRODUCT01
        /// Primary Key: 
        /// </summary>

        public class V_ORDER01_PRODUCT01Structs: DatabaseTable {
            
            public V_ORDER01_PRODUCT01Structs(IDataProvider provider):base("V_ORDER01_PRODUCT01",provider){
                ClassName = "V_ORDER01_PRODUCT01";
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

                Columns.Add(new DatabaseColumn("ORDER_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "ORDER_ID"
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

                Columns.Add(new DatabaseColumn("ON_QUAN", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ON_QUAN"
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

                Columns.Add(new DatabaseColumn("COST_PRICE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "COST_PRICE"
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

                Columns.Add(new DatabaseColumn("Memo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "Memo"
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
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "MOD_DATETIME"
                });

                Columns.Add(new DatabaseColumn("MOD_USER_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "MOD_USER_ID"
                });

                Columns.Add(new DatabaseColumn("STD_TYPE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "STD_TYPE"
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

                Columns.Add(new DatabaseColumn("SHOP_NAME1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40,
					PropertyName = "SHOP_NAME1"
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
				
            
            public IColumn ORDER_ID{
                get{
                    return this.GetColumn("ORDER_ID");
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
				
            
            public IColumn ON_QUAN{
                get{
                    return this.GetColumn("ON_QUAN");
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
				
            
            public IColumn COST_PRICE{
                get{
                    return this.GetColumn("COST_PRICE");
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
				
            
            public IColumn Memo{
                get{
                    return this.GetColumn("Memo");
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
				
            
            public IColumn STD_TYPE{
                get{
                    return this.GetColumn("STD_TYPE");
                }
            }
				
            
            public IColumn PROD_NAME1{
                get{
                    return this.GetColumn("PROD_NAME1");
                }
            }
				
            
            public IColumn SHOP_NAME1{
                get{
                    return this.GetColumn("SHOP_NAME1");
                }
            }
				
            
                    
        }
        
}

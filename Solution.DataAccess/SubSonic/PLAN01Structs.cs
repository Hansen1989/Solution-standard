 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: PLAN01
        /// Primary Key: Id
        /// </summary>

        public class PLAN01Structs: DatabaseTable {
            
            public PLAN01Structs(IDataProvider provider):base("PLAN01",provider){
                ClassName = "PLAN01";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
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

                Columns.Add(new DatabaseColumn("PLAN_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "PLAN_ID"
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

                Columns.Add(new DatabaseColumn("ACT_QUAN", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ACT_QUAN"
                });

                Columns.Add(new DatabaseColumn("Dispose_QUAN", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Dispose_QUAN"
                });

                Columns.Add(new DatabaseColumn("QUAN", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "QUAN"
                });

                Columns.Add(new DatabaseColumn("BATCH1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "BATCH1"
                });

                Columns.Add(new DatabaseColumn("BATCH2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "BATCH2"
                });

                Columns.Add(new DatabaseColumn("QUAN1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "QUAN1"
                });

                Columns.Add(new DatabaseColumn("QUAN2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "QUAN2"
                });

                Columns.Add(new DatabaseColumn("COM_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "COM_ID"
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
				
            
            public IColumn PLAN_ID{
                get{
                    return this.GetColumn("PLAN_ID");
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
				
            
            public IColumn ACT_QUAN{
                get{
                    return this.GetColumn("ACT_QUAN");
                }
            }
				
            
            public IColumn Dispose_QUAN{
                get{
                    return this.GetColumn("Dispose_QUAN");
                }
            }
				
            
            public IColumn QUAN{
                get{
                    return this.GetColumn("QUAN");
                }
            }
				
            
            public IColumn BATCH1{
                get{
                    return this.GetColumn("BATCH1");
                }
            }
				
            
            public IColumn BATCH2{
                get{
                    return this.GetColumn("BATCH2");
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
				
            
            public IColumn COM_ID{
                get{
                    return this.GetColumn("COM_ID");
                }
            }
				
            
            public IColumn Memo{
                get{
                    return this.GetColumn("Memo");
                }
            }
				
            
                    
        }
        
}

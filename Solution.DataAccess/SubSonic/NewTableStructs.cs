 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: NewTable
        /// Primary Key: Id
        /// </summary>

        public class NewTableStructs: DatabaseTable {
            
            public NewTableStructs(IDataProvider provider):base("NewTable",provider){
                ClassName = "NewTable";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Id"
                });

                Columns.Add(new DatabaseColumn("ITEM_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 60,
					PropertyName = "ITEM_ID"
                });

                Columns.Add(new DatabaseColumn("SHOP_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "SHOP_ID"
                });

                Columns.Add(new DatabaseColumn("OUT_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "OUT_ID"
                });

                Columns.Add(new DatabaseColumn("SNO", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SNO"
                });

                Columns.Add(new DatabaseColumn("PROD_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "PROD_ID"
                });

                Columns.Add(new DatabaseColumn("STD_UNIT", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "STD_UNIT"
                });

                Columns.Add(new DatabaseColumn("STD_QUAN", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "STD_QUAN"
                });

                Columns.Add(new DatabaseColumn("STD_PRICE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "STD_PRICE"
                });

                Columns.Add(new DatabaseColumn("COST", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "COST"
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
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn ITEM_ID{
                get{
                    return this.GetColumn("ITEM_ID");
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
				
            
            public IColumn SNO{
                get{
                    return this.GetColumn("SNO");
                }
            }
				
            
            public IColumn PROD_ID{
                get{
                    return this.GetColumn("PROD_ID");
                }
            }
				
            
            public IColumn STD_UNIT{
                get{
                    return this.GetColumn("STD_UNIT");
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
				
            
                    
        }
        
}

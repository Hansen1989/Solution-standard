 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: Col_Order00
        /// Primary Key: Id
        /// </summary>

        public class Col_Order00Structs: DatabaseTable {
            
            public Col_Order00Structs(IDataProvider provider):base("Col_Order00",provider){
                ClassName = "Col_Order00";
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

                Columns.Add(new DatabaseColumn("COL_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "COL_ID"
                });

                Columns.Add(new DatabaseColumn("INPUT_DATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "INPUT_DATE"
                });

                Columns.Add(new DatabaseColumn("ORD_USER", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "ORD_USER"
                });

                Columns.Add(new DatabaseColumn("EXPECT_DATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EXPECT_DATE"
                });

                Columns.Add(new DatabaseColumn("STATUS", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "STATUS"
                });

                Columns.Add(new DatabaseColumn("PROD_TYPE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "PROD_TYPE"
                });

                Columns.Add(new DatabaseColumn("ORD_TYPE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "ORD_TYPE"
                });

                Columns.Add(new DatabaseColumn("ORD_DEP_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "ORD_DEP_ID"
                });

                Columns.Add(new DatabaseColumn("COL_BeginDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "COL_BeginDate"
                });

                Columns.Add(new DatabaseColumn("COL_EndDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "COL_EndDate"
                });

                Columns.Add(new DatabaseColumn("APP_USER", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "APP_USER"
                });

                Columns.Add(new DatabaseColumn("APP_DATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "APP_DATE"
                });

                Columns.Add(new DatabaseColumn("Memo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200,
					PropertyName = "Memo"
                });

                Columns.Add(new DatabaseColumn("LOCKED", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "LOCKED"
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

                Columns.Add(new DatabaseColumn("Trans_STATUS", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Trans_STATUS"
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
				
            
            public IColumn COL_ID{
                get{
                    return this.GetColumn("COL_ID");
                }
            }
				
            
            public IColumn INPUT_DATE{
                get{
                    return this.GetColumn("INPUT_DATE");
                }
            }
				
            
            public IColumn ORD_USER{
                get{
                    return this.GetColumn("ORD_USER");
                }
            }
				
            
            public IColumn EXPECT_DATE{
                get{
                    return this.GetColumn("EXPECT_DATE");
                }
            }
				
            
            public IColumn STATUS{
                get{
                    return this.GetColumn("STATUS");
                }
            }
				
            
            public IColumn PROD_TYPE{
                get{
                    return this.GetColumn("PROD_TYPE");
                }
            }
				
            
            public IColumn ORD_TYPE{
                get{
                    return this.GetColumn("ORD_TYPE");
                }
            }
				
            
            public IColumn ORD_DEP_ID{
                get{
                    return this.GetColumn("ORD_DEP_ID");
                }
            }
				
            
            public IColumn COL_BeginDate{
                get{
                    return this.GetColumn("COL_BeginDate");
                }
            }
				
            
            public IColumn COL_EndDate{
                get{
                    return this.GetColumn("COL_EndDate");
                }
            }
				
            
            public IColumn APP_USER{
                get{
                    return this.GetColumn("APP_USER");
                }
            }
				
            
            public IColumn APP_DATE{
                get{
                    return this.GetColumn("APP_DATE");
                }
            }
				
            
            public IColumn Memo{
                get{
                    return this.GetColumn("Memo");
                }
            }
				
            
            public IColumn LOCKED{
                get{
                    return this.GetColumn("LOCKED");
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
				
            
            public IColumn Trans_STATUS{
                get{
                    return this.GetColumn("Trans_STATUS");
                }
            }
				
            
                    
        }
        
}

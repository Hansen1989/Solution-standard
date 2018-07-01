 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: SHOP_SUPPLIER_RELATION
        /// Primary Key: Id
        /// </summary>

        public class SHOP_SUPPLIER_RELATIONStructs: DatabaseTable {
            
            public SHOP_SUPPLIER_RELATIONStructs(IDataProvider provider):base("SHOP_SUPPLIER_RELATION",provider){
                ClassName = "SHOP_SUPPLIER_RELATION";
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
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "SHOP_ID"
                });

                Columns.Add(new DatabaseColumn("SUP_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
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

                Columns.Add(new DatabaseColumn("CRT_DATETIME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "CRT_DATETIME"
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
				
            
            public IColumn MEMO{
                get{
                    return this.GetColumn("MEMO");
                }
            }
				
            
            public IColumn CRT_DATETIME{
                get{
                    return this.GetColumn("CRT_DATETIME");
                }
            }
				
            
                    
        }
        
}

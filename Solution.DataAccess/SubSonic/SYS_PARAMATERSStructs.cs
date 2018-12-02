 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: SYS_PARAMATERS
        /// Primary Key: Id
        /// </summary>

        public class SYS_PARAMATERSStructs: DatabaseTable {
            
            public SYS_PARAMATERSStructs(IDataProvider provider):base("SYS_PARAMATERS",provider){
                ClassName = "SYS_PARAMATERS";
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

                Columns.Add(new DatabaseColumn("Code", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "Code"
                });

                Columns.Add(new DatabaseColumn("VALUE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "VALUE"
                });

                Columns.Add(new DatabaseColumn("KEY_CN", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "KEY_CN"
                });

                Columns.Add(new DatabaseColumn("MEMO", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "MEMO"
                });

                Columns.Add(new DatabaseColumn("Area_Id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "Area_Id"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn Code{
                get{
                    return this.GetColumn("Code");
                }
            }
				
            
            public IColumn VALUE{
                get{
                    return this.GetColumn("VALUE");
                }
            }
				
            
            public IColumn KEY_CN{
                get{
                    return this.GetColumn("KEY_CN");
                }
            }
				
            
            public IColumn MEMO{
                get{
                    return this.GetColumn("MEMO");
                }
            }
				
            
            public IColumn Area_Id{
                get{
                    return this.GetColumn("Area_Id");
                }
            }
				
            
                    
        }
        
}

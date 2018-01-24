 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: TABLE_SEED
        /// Primary Key: Id
        /// </summary>

        public class TABLE_SEEDStructs: DatabaseTable {
            
            public TABLE_SEEDStructs(IDataProvider provider):base("TABLE_SEED",provider){
                ClassName = "TABLE_SEED";
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

                Columns.Add(new DatabaseColumn("TABLE_NAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "TABLE_NAME"
                });

                Columns.Add(new DatabaseColumn("SEED_DATETIME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "SEED_DATETIME"
                });

                Columns.Add(new DatabaseColumn("SEED_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SEED_ID"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn TABLE_NAME{
                get{
                    return this.GetColumn("TABLE_NAME");
                }
            }
				
            
            public IColumn SEED_DATETIME{
                get{
                    return this.GetColumn("SEED_DATETIME");
                }
            }
				
            
            public IColumn SEED_ID{
                get{
                    return this.GetColumn("SEED_ID");
                }
            }
				
            
                    
        }
        
}

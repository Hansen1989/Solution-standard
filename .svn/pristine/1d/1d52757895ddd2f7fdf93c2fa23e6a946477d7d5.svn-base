 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: TEST
        /// Primary Key: Id
        /// </summary>

        public class TESTStructs: DatabaseTable {
            
            public TESTStructs(IDataProvider provider):base("TEST",provider){
                ClassName = "TEST";
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

                Columns.Add(new DatabaseColumn("COL1", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "COL1"
                });

                Columns.Add(new DatabaseColumn("COL2", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "COL2"
                });

                Columns.Add(new DatabaseColumn("COL3", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "COL3"
                });

                Columns.Add(new DatabaseColumn("COL4", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "COL4"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn COL1{
                get{
                    return this.GetColumn("COL1");
                }
            }
				
            
            public IColumn COL2{
                get{
                    return this.GetColumn("COL2");
                }
            }
				
            
            public IColumn COL3{
                get{
                    return this.GetColumn("COL3");
                }
            }
				
            
            public IColumn COL4{
                get{
                    return this.GetColumn("COL4");
                }
            }
				
            
                    
        }
        
}

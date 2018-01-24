 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: EMPLOYEE
        /// Primary Key: Id
        /// </summary>

        public class EMPLOYEEStructs: DatabaseTable {
            
            public EMPLOYEEStructs(IDataProvider provider):base("EMPLOYEE",provider){
                ClassName = "EMPLOYEE";
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

                Columns.Add(new DatabaseColumn("EMP_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "EMP_ID"
                });

                Columns.Add(new DatabaseColumn("EMP_NAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "EMP_NAME"
                });

                Columns.Add(new DatabaseColumn("EMP_Birthday", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EMP_Birthday"
                });

                Columns.Add(new DatabaseColumn("EMP_ADD", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40,
					PropertyName = "EMP_ADD"
                });

                Columns.Add(new DatabaseColumn("EMP_TEL", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "EMP_TEL"
                });

                Columns.Add(new DatabaseColumn("EMP_ZIP", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "EMP_ZIP"
                });

                Columns.Add(new DatabaseColumn("EMP_EMAIL", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40,
					PropertyName = "EMP_EMAIL"
                });

                Columns.Add(new DatabaseColumn("EMP_MOBILE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "EMP_MOBILE"
                });

                Columns.Add(new DatabaseColumn("EMP_MEMO", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100,
					PropertyName = "EMP_MEMO"
                });

                Columns.Add(new DatabaseColumn("EMP_ENABLE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EMP_ENABLE"
                });

                Columns.Add(new DatabaseColumn("EMP_SEX", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EMP_SEX"
                });

                Columns.Add(new DatabaseColumn("EMP_CodeID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "EMP_CodeID"
                });

                Columns.Add(new DatabaseColumn("EMP_LEVEL", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EMP_LEVEL"
                });

                Columns.Add(new DatabaseColumn("EMP_PASSWORD", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40,
					PropertyName = "EMP_PASSWORD"
                });

                Columns.Add(new DatabaseColumn("EMP_BDATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EMP_BDATE"
                });

                Columns.Add(new DatabaseColumn("EMP_EDATE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EMP_EDATE"
                });

                Columns.Add(new DatabaseColumn("EMP_WAGE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EMP_WAGE"
                });

                Columns.Add(new DatabaseColumn("EMP_Education", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "EMP_Education"
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
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "LAST_UPDATE"
                });

                Columns.Add(new DatabaseColumn("STATUS", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "STATUS"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn EMP_ID{
                get{
                    return this.GetColumn("EMP_ID");
                }
            }
				
            
            public IColumn EMP_NAME{
                get{
                    return this.GetColumn("EMP_NAME");
                }
            }
				
            
            public IColumn EMP_Birthday{
                get{
                    return this.GetColumn("EMP_Birthday");
                }
            }
				
            
            public IColumn EMP_ADD{
                get{
                    return this.GetColumn("EMP_ADD");
                }
            }
				
            
            public IColumn EMP_TEL{
                get{
                    return this.GetColumn("EMP_TEL");
                }
            }
				
            
            public IColumn EMP_ZIP{
                get{
                    return this.GetColumn("EMP_ZIP");
                }
            }
				
            
            public IColumn EMP_EMAIL{
                get{
                    return this.GetColumn("EMP_EMAIL");
                }
            }
				
            
            public IColumn EMP_MOBILE{
                get{
                    return this.GetColumn("EMP_MOBILE");
                }
            }
				
            
            public IColumn EMP_MEMO{
                get{
                    return this.GetColumn("EMP_MEMO");
                }
            }
				
            
            public IColumn EMP_ENABLE{
                get{
                    return this.GetColumn("EMP_ENABLE");
                }
            }
				
            
            public IColumn EMP_SEX{
                get{
                    return this.GetColumn("EMP_SEX");
                }
            }
				
            
            public IColumn EMP_CodeID{
                get{
                    return this.GetColumn("EMP_CodeID");
                }
            }
				
            
            public IColumn EMP_LEVEL{
                get{
                    return this.GetColumn("EMP_LEVEL");
                }
            }
				
            
            public IColumn EMP_PASSWORD{
                get{
                    return this.GetColumn("EMP_PASSWORD");
                }
            }
				
            
            public IColumn EMP_BDATE{
                get{
                    return this.GetColumn("EMP_BDATE");
                }
            }
				
            
            public IColumn EMP_EDATE{
                get{
                    return this.GetColumn("EMP_EDATE");
                }
            }
				
            
            public IColumn EMP_WAGE{
                get{
                    return this.GetColumn("EMP_WAGE");
                }
            }
				
            
            public IColumn EMP_Education{
                get{
                    return this.GetColumn("EMP_Education");
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
				
            
            public IColumn STATUS{
                get{
                    return this.GetColumn("STATUS");
                }
            }
				
            
                    
        }
        
}

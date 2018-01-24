 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: SUPPLIERS
        /// Primary Key: Id
        /// </summary>

        public class SUPPLIERSStructs: DatabaseTable {
            
            public SUPPLIERSStructs(IDataProvider provider):base("SUPPLIERS",provider){
                ClassName = "SUPPLIERS";
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

                Columns.Add(new DatabaseColumn("SUP_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10,
					PropertyName = "SUP_ID"
                });

                Columns.Add(new DatabaseColumn("SUP_NAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "SUP_NAME"
                });

                Columns.Add(new DatabaseColumn("SUP_NICKNAME", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "SUP_NICKNAME"
                });

                Columns.Add(new DatabaseColumn("SUP_TYPE", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SUP_TYPE"
                });

                Columns.Add(new DatabaseColumn("SUP_ADD", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40,
					PropertyName = "SUP_ADD"
                });

                Columns.Add(new DatabaseColumn("SUP_TEL", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "SUP_TEL"
                });

                Columns.Add(new DatabaseColumn("SUP_Email", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "SUP_Email"
                });

                Columns.Add(new DatabaseColumn("SUP_ZIP", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 6,
					PropertyName = "SUP_ZIP"
                });

                Columns.Add(new DatabaseColumn("SUP_Contact", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "SUP_Contact"
                });

                Columns.Add(new DatabaseColumn("SUP_Mobile", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "SUP_Mobile"
                });

                Columns.Add(new DatabaseColumn("SUP_CODE_ID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "SUP_CODE_ID"
                });

                Columns.Add(new DatabaseColumn("SUP_BankName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40,
					PropertyName = "SUP_BankName"
                });

                Columns.Add(new DatabaseColumn("SUP_BankID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "SUP_BankID"
                });

                Columns.Add(new DatabaseColumn("SUP_PASSWORD", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40,
					PropertyName = "SUP_PASSWORD"
                });

                Columns.Add(new DatabaseColumn("Send_DAY", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Send_DAY"
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
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "LAST_UPDATE"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
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
				
            
            public IColumn SUP_NICKNAME{
                get{
                    return this.GetColumn("SUP_NICKNAME");
                }
            }
				
            
            public IColumn SUP_TYPE{
                get{
                    return this.GetColumn("SUP_TYPE");
                }
            }
				
            
            public IColumn SUP_ADD{
                get{
                    return this.GetColumn("SUP_ADD");
                }
            }
				
            
            public IColumn SUP_TEL{
                get{
                    return this.GetColumn("SUP_TEL");
                }
            }
				
            
            public IColumn SUP_Email{
                get{
                    return this.GetColumn("SUP_Email");
                }
            }
				
            
            public IColumn SUP_ZIP{
                get{
                    return this.GetColumn("SUP_ZIP");
                }
            }
				
            
            public IColumn SUP_Contact{
                get{
                    return this.GetColumn("SUP_Contact");
                }
            }
				
            
            public IColumn SUP_Mobile{
                get{
                    return this.GetColumn("SUP_Mobile");
                }
            }
				
            
            public IColumn SUP_CODE_ID{
                get{
                    return this.GetColumn("SUP_CODE_ID");
                }
            }
				
            
            public IColumn SUP_BankName{
                get{
                    return this.GetColumn("SUP_BankName");
                }
            }
				
            
            public IColumn SUP_BankID{
                get{
                    return this.GetColumn("SUP_BankID");
                }
            }
				
            
            public IColumn SUP_PASSWORD{
                get{
                    return this.GetColumn("SUP_PASSWORD");
                }
            }
				
            
            public IColumn Send_DAY{
                get{
                    return this.GetColumn("Send_DAY");
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
				
            
                    
        }
        
}

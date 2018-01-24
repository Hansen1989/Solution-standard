 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace Solution.DataAccess.DataModel {
        /// <summary>
        /// Table: EmailSendHistory
        /// Primary Key: Id
        /// </summary>

        public class EmailSendHistoryStructs: DatabaseTable {
            
            public EmailSendHistoryStructs(IDataProvider provider):base("EmailSendHistory",provider){
                ClassName = "EmailSendHistory";
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

                Columns.Add(new DatabaseColumn("SendUsers_Id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SendUsers_Id"
                });

                Columns.Add(new DatabaseColumn("SendUsers_Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "SendUsers_Name"
                });

                Columns.Add(new DatabaseColumn("SendUsers_Email", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "SendUsers_Email"
                });

                Columns.Add(new DatabaseColumn("RecUsers_Id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "RecUsers_Id"
                });

                Columns.Add(new DatabaseColumn("RecUsers_Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "RecUsers_Name"
                });

                Columns.Add(new DatabaseColumn("RecUsers_Email", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "RecUsers_Email"
                });

                Columns.Add(new DatabaseColumn("RecUserLevel_Id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "RecUserLevel_Id"
                });

                Columns.Add(new DatabaseColumn("RecUserLevel_Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20,
					PropertyName = "RecUserLevel_Name"
                });

                Columns.Add(new DatabaseColumn("EmailSubject", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50,
					PropertyName = "EmailSubject"
                });

                Columns.Add(new DatabaseColumn("EmailContent", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1073741823,
					PropertyName = "EmailContent"
                });

                Columns.Add(new DatabaseColumn("SendDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "SendDate"
                });

                Columns.Add(new DatabaseColumn("Status", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Byte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Status"
                });

                Columns.Add(new DatabaseColumn("StatusName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "StatusName"
                });

                Columns.Add(new DatabaseColumn("ErrorMsg", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200,
					PropertyName = "ErrorMsg"
                });

                Columns.Add(new DatabaseColumn("Template_Id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Template_Id"
                });

                Columns.Add(new DatabaseColumn("Template_Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30,
					PropertyName = "Template_Name"
                });
                    
                
                
            }

            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            
            public IColumn SendUsers_Id{
                get{
                    return this.GetColumn("SendUsers_Id");
                }
            }
				
            
            public IColumn SendUsers_Name{
                get{
                    return this.GetColumn("SendUsers_Name");
                }
            }
				
            
            public IColumn SendUsers_Email{
                get{
                    return this.GetColumn("SendUsers_Email");
                }
            }
				
            
            public IColumn RecUsers_Id{
                get{
                    return this.GetColumn("RecUsers_Id");
                }
            }
				
            
            public IColumn RecUsers_Name{
                get{
                    return this.GetColumn("RecUsers_Name");
                }
            }
				
            
            public IColumn RecUsers_Email{
                get{
                    return this.GetColumn("RecUsers_Email");
                }
            }
				
            
            public IColumn RecUserLevel_Id{
                get{
                    return this.GetColumn("RecUserLevel_Id");
                }
            }
				
            
            public IColumn RecUserLevel_Name{
                get{
                    return this.GetColumn("RecUserLevel_Name");
                }
            }
				
            
            public IColumn EmailSubject{
                get{
                    return this.GetColumn("EmailSubject");
                }
            }
				
            
            public IColumn EmailContent{
                get{
                    return this.GetColumn("EmailContent");
                }
            }
				
            
            public IColumn SendDate{
                get{
                    return this.GetColumn("SendDate");
                }
            }
				
            
            public IColumn Status{
                get{
                    return this.GetColumn("Status");
                }
            }
				
            
            public IColumn StatusName{
                get{
                    return this.GetColumn("StatusName");
                }
            }
				
            
            public IColumn ErrorMsg{
                get{
                    return this.GetColumn("ErrorMsg");
                }
            }
				
            
            public IColumn Template_Id{
                get{
                    return this.GetColumn("Template_Id");
                }
            }
				
            
            public IColumn Template_Name{
                get{
                    return this.GetColumn("Template_Name");
                }
            }
				
            
                    
        }
        
}

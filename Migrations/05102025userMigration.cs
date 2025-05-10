using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations 
{
    [Migration(202510051516)]
    public class _05102025userMigration : Migration
    {
        public override void Up()
        {
            Create.Table("user")
                .WithColumn("userId").AsInt32().PrimaryKey().Identity()
                .WithColumn("userName").AsString(250).NotNullable()
                .WithColumn("userPassword").AsString(100).NotNullable()
                .WithColumn("userEmail").AsString(300).NotNullable()
                .WithColumn("userRole").AsString(10).NotNullable()
                .WithColumn("createdDate").AsDateTime().NotNullable()
                ;
        }
        public override void Down()
        {
            Delete.Table("user");
        }  


    
    }
}

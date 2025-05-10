using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
    [Migration(02)]
    public class _02jobMigration : Migration
    {
        public override void Up()
        {
            Create.Table("job")
                .WithColumn("jibId").AsString().Identity().PrimaryKey()
                .WithColumn("title").AsString().NotNullable()
                .WithColumn("descriPtion").AsString().Nullable()
                .WithColumn("postedBy").AsString().NotNullable()
                .WithColumn("applicationId").AsString().NotNullable()
                .WithColumn("createdOn").AsDateTime().NotNullable();
                
        }

        public override void Down()
        {
            Delete.Table("job");
        }

       
    }
}

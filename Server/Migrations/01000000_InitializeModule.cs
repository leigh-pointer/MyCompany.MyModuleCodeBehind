using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using MyCompany.MyModuleCodeBehind.Migrations.EntityBuilders;
using MyCompany.MyModuleCodeBehind.Repository;

namespace MyCompany.MyModuleCodeBehind.Migrations
{
    [DbContext(typeof(MyModuleCodeBehindContext))]
    [Migration("MyModuleCodeBehind.01.00.00.00")]
    public class InitializeModule : MultiDatabaseMigration
    {
        public InitializeModule(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new MyModuleCodeBehindEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Create();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new MyModuleCodeBehindEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Drop();
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace MyCompany.MyModuleCodeBehind.Migrations.EntityBuilders
{
    public class MyModuleCodeBehindEntityBuilder : AuditableBaseEntityBuilder<MyModuleCodeBehindEntityBuilder>
    {
        private const string _entityTableName = "MyCompanyMyModuleCodeBehind";
        private readonly PrimaryKey<MyModuleCodeBehindEntityBuilder> _primaryKey = new("PK_MyCompanyMyModuleCodeBehind", x => x.MyModuleCodeBehindId);
        private readonly ForeignKey<MyModuleCodeBehindEntityBuilder> _moduleForeignKey = new("FK_MyCompanyMyModuleCodeBehind_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public MyModuleCodeBehindEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override MyModuleCodeBehindEntityBuilder BuildTable(ColumnsBuilder table)
        {
            MyModuleCodeBehindId = AddAutoIncrementColumn(table,"MyModuleCodeBehindId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> MyModuleCodeBehindId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}

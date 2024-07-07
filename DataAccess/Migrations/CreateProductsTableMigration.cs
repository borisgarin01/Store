using FluentMigrator;

namespace Migrations.Migrations;

[Migration(1, "CreateProductsTableMigration_07_04_2024_14_45")]
public sealed class CreateProductsTableMigration : Migration
{
    public override void Down()
    {
        Execute.Sql("DROP TABLE Products");
    }

    public override void Up()
    {
        Execute.Sql(@"
                CREATE TABLE Products(
                    Id bigserial not null primary key,
                    Name varchar(255) not null unique,
                    Description varchar(8191) null,
                    CreatedAt timestamp not null,
                    UpdatedAt timestamp null,
                    IsDeleted boolean not null,
                    DeletedAt timestamp null
                );
            ");
    }
}

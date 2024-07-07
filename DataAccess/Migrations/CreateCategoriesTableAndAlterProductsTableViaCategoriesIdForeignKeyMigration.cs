using FluentMigrator;

namespace DataAccess.Migrations;

[Migration(2, "CreateCategoriesTableAndAlterProductsTableViaCategoriesIdForeignKeyMigration_07_04_2024_14_49")]

public sealed class CreateCategoriesTableAndAlterProductsTableViaCategoriesIdForeignKeyMigration : Migration
{
    public override void Down()
    {
        Execute.Sql("DROP TABLE Categories");
    }

    public override void Up()
    {
        Execute.Sql(@"
                CREATE TABLE Categories(
                    Id bigserial not null primary key,
                    Name varchar(255) not null unique
                );

                ALTER TABLE Products ADD Column CategoryId bigint not null;
                    
                ALTER TABLE Products
                ADD CONSTRAINT FK_CATEGORY
                FOREIGN KEY (CategoryId)
                REFERENCES Categories (Id)
                ON DELETE RESTRICT;
            ");
    }
}

using FluentMigrator;

namespace Migrations.Migrations;

[Migration(3, "CreateManufacturersTableAndAlterProductsTableViaManufacturersIdForeignKeyMigration_07_04_2024_14_56")]

public sealed class CreateManufacturersTableAndAlterProductsTableViaManufacturersIdForeignKeyMigration : Migration
{
    public override void Down()
    {
        Execute.Sql("DROP TABLE Manufacturers");
    }

    public override void Up()
    {
        Execute.Sql(@"
                CREATE TABLE Manufacturers(
                    Id bigserial not null primary key,
                    Name varchar(255) not null unique
                );

                ALTER TABLE Products ADD Column ManufacturerId bigint not null;
                    
                ALTER TABLE Products
                ADD CONSTRAINT FK_MANUFACTURER
                FOREIGN KEY (ManufacturerId)
                REFERENCES Manufacturers (Id)
                ON DELETE RESTRICT;
            ");
    }
}
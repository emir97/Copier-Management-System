using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iCopy.SERVICES.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Countries",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Countries",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValueSql: "1");
        }
    }
}

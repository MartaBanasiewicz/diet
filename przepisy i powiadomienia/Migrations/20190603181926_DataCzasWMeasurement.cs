using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace przepisy_i_powiadomienia.Migrations
{
    public partial class DataCzasWMeasurement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Measurements",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Measurements");
        }
    }
}

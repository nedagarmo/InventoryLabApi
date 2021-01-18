using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.Entities.Migrations
{
    public partial class TypesAndMovementUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Warehouses_WarehouseId",
                table: "Movements");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                table: "Movements",
                newName: "WarehouseOriginId");

            migrationBuilder.RenameIndex(
                name: "IX_Movements_WarehouseId",
                table: "Movements",
                newName: "IX_Movements_WarehouseOriginId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Warehouses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 10, 23, 52, 58, 412, DateTimeKind.Utc).AddTicks(1159),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 1, 10, 11, 26, 23, 507, DateTimeKind.Utc).AddTicks(5525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Stock",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 10, 23, 52, 58, 443, DateTimeKind.Utc).AddTicks(3901),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 1, 10, 11, 26, 23, 523, DateTimeKind.Utc).AddTicks(4651));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 10, 23, 52, 58, 426, DateTimeKind.Utc).AddTicks(687),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 1, 10, 11, 26, 23, 519, DateTimeKind.Utc).AddTicks(1485));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MovementTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 10, 23, 52, 58, 427, DateTimeKind.Utc).AddTicks(1936),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 1, 10, 11, 26, 23, 520, DateTimeKind.Utc).AddTicks(778));

            migrationBuilder.AddColumn<bool>(
                name: "IsTransfer",
                table: "MovementTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Movements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 10, 23, 52, 58, 431, DateTimeKind.Utc).AddTicks(672),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 1, 10, 11, 26, 23, 521, DateTimeKind.Utc).AddTicks(2296));

            migrationBuilder.AddColumn<Guid>(
                name: "WarehouseDestinationId",
                table: "Movements",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "MovementTypes",
                columns: new[] { "Id", "CreatedAt", "IsOutlet", "IsTransfer", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("41841961-b61c-42b4-a88d-5c617409bf79"), new DateTime(2021, 1, 10, 23, 52, 58, 427, DateTimeKind.Utc).AddTicks(9722), false, false, null, "Entrada por compra" },
                    { new Guid("37a33133-1db4-4eaf-b96f-db678506d30b"), new DateTime(2021, 1, 10, 23, 52, 58, 428, DateTimeKind.Utc).AddTicks(205), true, false, null, "Salida por venta" },
                    { new Guid("2e31f9af-1d4f-4bbf-a25e-818a335c5119"), new DateTime(2021, 1, 10, 23, 52, 58, 428, DateTimeKind.Utc).AddTicks(209), false, true, null, "Entrada por traslado" },
                    { new Guid("e19abc4b-e0d4-4bf2-b0aa-dc7ae2b0fe74"), new DateTime(2021, 1, 10, 23, 52, 58, 428, DateTimeKind.Utc).AddTicks(212), true, true, null, "Salida por traslado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movements_WarehouseDestinationId",
                table: "Movements",
                column: "WarehouseDestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Warehouses_WarehouseDestinationId",
                table: "Movements",
                column: "WarehouseDestinationId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Warehouses_WarehouseOriginId",
                table: "Movements",
                column: "WarehouseOriginId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Warehouses_WarehouseDestinationId",
                table: "Movements");

            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Warehouses_WarehouseOriginId",
                table: "Movements");

            migrationBuilder.DropIndex(
                name: "IX_Movements_WarehouseDestinationId",
                table: "Movements");

            migrationBuilder.DeleteData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: new Guid("2e31f9af-1d4f-4bbf-a25e-818a335c5119"));

            migrationBuilder.DeleteData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: new Guid("37a33133-1db4-4eaf-b96f-db678506d30b"));

            migrationBuilder.DeleteData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: new Guid("41841961-b61c-42b4-a88d-5c617409bf79"));

            migrationBuilder.DeleteData(
                table: "MovementTypes",
                keyColumn: "Id",
                keyValue: new Guid("e19abc4b-e0d4-4bf2-b0aa-dc7ae2b0fe74"));

            migrationBuilder.DropColumn(
                name: "IsTransfer",
                table: "MovementTypes");

            migrationBuilder.DropColumn(
                name: "WarehouseDestinationId",
                table: "Movements");

            migrationBuilder.RenameColumn(
                name: "WarehouseOriginId",
                table: "Movements",
                newName: "WarehouseId");

            migrationBuilder.RenameIndex(
                name: "IX_Movements_WarehouseOriginId",
                table: "Movements",
                newName: "IX_Movements_WarehouseId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Warehouses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 10, 11, 26, 23, 507, DateTimeKind.Utc).AddTicks(5525),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 1, 10, 23, 52, 58, 412, DateTimeKind.Utc).AddTicks(1159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Stock",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 10, 11, 26, 23, 523, DateTimeKind.Utc).AddTicks(4651),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 1, 10, 23, 52, 58, 443, DateTimeKind.Utc).AddTicks(3901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 10, 11, 26, 23, 519, DateTimeKind.Utc).AddTicks(1485),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 1, 10, 23, 52, 58, 426, DateTimeKind.Utc).AddTicks(687));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "MovementTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 10, 11, 26, 23, 520, DateTimeKind.Utc).AddTicks(778),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 1, 10, 23, 52, 58, 427, DateTimeKind.Utc).AddTicks(1936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Movements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 10, 11, 26, 23, 521, DateTimeKind.Utc).AddTicks(2296),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 1, 10, 23, 52, 58, 431, DateTimeKind.Utc).AddTicks(672));

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Warehouses_WarehouseId",
                table: "Movements",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

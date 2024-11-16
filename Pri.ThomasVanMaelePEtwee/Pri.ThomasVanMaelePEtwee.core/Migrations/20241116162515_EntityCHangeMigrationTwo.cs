using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.ThomasVanMaelePEtwee.core.Migrations
{
    /// <inheritdoc />
    public partial class EntityCHangeMigrationTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminComment",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerComment",
                table: "Quotations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6d21b490-ca78-4dc3-8c8f-cf6611a598dc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d3b79a73-2c13-464a-8237-e76d29c92e92");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "612cb349-aa59-49a3-8e0e-affff72056a8", "AQAAAAIAAYagAAAAEC0nRxIbHXkbWQRgIy2jYCJmoI5oKRoW892pNhBz4h3OWEvOJ+BSP6wn8HYVEOkijg==", "37738e3c-8ad7-4772-81b5-78c7e3d47619" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc000a96-e06c-4b53-ae7e-6360c4179340", "AQAAAAIAAYagAAAAEGo2CoMlVzx3gxvH/ltVyKMTCkUrca5Ha/NvpNfl83wMXHuEEv95iqkAIylyxfWt8w==", "c7f382fc-b0ee-488a-be25-94147842cbb0" });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AdminComment", "CustomerComment", "RequestDate" },
                values: new object[] { null, "Ik wil de goedkoopste prijs aub", new DateTime(2024, 11, 16, 16, 25, 14, 705, DateTimeKind.Utc).AddTicks(8530) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminComment",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "CustomerComment",
                table: "Quotations");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "97a402f3-d187-4bb9-a8a2-add53ca6c44a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0938b655-edd4-4463-8d24-83c076d167f9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2f90c10-9935-449b-aa1b-198374e06a4f", "AQAAAAIAAYagAAAAEBVNtwn//pLhExNX3sGcViR4wDD6D3mkjn3dDYEjgdf+IsvdsHSEmm/swtJRfaVHLg==", "7a1a47a9-62c4-45ca-9cd9-5057ead8c740" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b1c280e-3427-4b2b-8091-0ac0563d92b7", "AQAAAAIAAYagAAAAEIFJUkmHzILZD3XnR/40jqsMSSjgHdXDRkuw0+dDuRGRQGoPePs3qn1z0KHMoWpRSQ==", "460526ff-f019-4763-8e9d-223f4f39deb0" });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2024, 11, 16, 14, 47, 23, 344, DateTimeKind.Utc).AddTicks(5744));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.ThomasVanMaelePEtwee.core.Migrations
{
    /// <inheritdoc />
    public partial class EntityCHangeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SwimmingPools_Quotations_QuotationId",
                table: "SwimmingPools");

            migrationBuilder.AlterColumn<int>(
                name: "QuotationId",
                table: "SwimmingPools",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SwimmingPools_Quotations_QuotationId",
                table: "SwimmingPools",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SwimmingPools_Quotations_QuotationId",
                table: "SwimmingPools");

            migrationBuilder.AlterColumn<int>(
                name: "QuotationId",
                table: "SwimmingPools",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b7dbc2ef-9f7a-4a95-a619-feda46abb066");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e1d482b9-1907-4c3f-9796-97553a93eff7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b016f4c2-9c8d-4887-8631-efc3a204fe1c", "AQAAAAIAAYagAAAAEHaF+hufGV+j3g3+grJpS1njNq7UXngTSi+Q1e35ve33CMzgVx8563X+p/HZbSrQMg==", "3a4b0abd-b6d0-48fc-965f-9673fb40ebe1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb105f98-70b2-4fda-87e2-3f9abe8c5cc6", "AQAAAAIAAYagAAAAEEsdwd72OzOrAEC16Qm6J2Ag77rSW8GIsWT+or93v2Pbf63+ZEHbZ/LOe1TVwO+a7Q==", "c37e3f19-a1a5-47fc-8d57-84bb07899f5c" });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                column: "RequestDate",
                value: new DateTime(2024, 11, 14, 20, 41, 44, 259, DateTimeKind.Utc).AddTicks(4102));

            migrationBuilder.AddForeignKey(
                name: "FK_SwimmingPools_Quotations_QuotationId",
                table: "SwimmingPools",
                column: "QuotationId",
                principalTable: "Quotations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

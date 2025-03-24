using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demo_csdlnc.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MinhChung",
                table: "TieuChiSinhViens",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaTieuChi",
                table: "ThamGiaHoatDongs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MinhChung",
                table: "ThamGiaHoatDongs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaAccount",
                table: "SinhViens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThamGiaHoatDongs_MaTieuChi",
                table: "ThamGiaHoatDongs",
                column: "MaTieuChi");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_MaAccount",
                table: "SinhViens",
                column: "MaAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhViens_Accounts_MaAccount",
                table: "SinhViens",
                column: "MaAccount",
                principalTable: "Accounts",
                principalColumn: "MaAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_ThamGiaHoatDongs_TieuChis_MaTieuChi",
                table: "ThamGiaHoatDongs",
                column: "MaTieuChi",
                principalTable: "TieuChis",
                principalColumn: "MaTieuChi",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhViens_Accounts_MaAccount",
                table: "SinhViens");

            migrationBuilder.DropForeignKey(
                name: "FK_ThamGiaHoatDongs_TieuChis_MaTieuChi",
                table: "ThamGiaHoatDongs");

            migrationBuilder.DropIndex(
                name: "IX_ThamGiaHoatDongs_MaTieuChi",
                table: "ThamGiaHoatDongs");

            migrationBuilder.DropIndex(
                name: "IX_SinhViens_MaAccount",
                table: "SinhViens");

            migrationBuilder.DropColumn(
                name: "MinhChung",
                table: "TieuChiSinhViens");

            migrationBuilder.DropColumn(
                name: "MaTieuChi",
                table: "ThamGiaHoatDongs");

            migrationBuilder.DropColumn(
                name: "MinhChung",
                table: "ThamGiaHoatDongs");

            migrationBuilder.DropColumn(
                name: "MaAccount",
                table: "SinhViens");
        }
    }
}

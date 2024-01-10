using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogRazor.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class Addingnormalizedusername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "de0b87d9-f234-4f85-875c-1816f73563ff",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cedf59ec-16af-4778-8c09-78c9a2568a78", "SUPERADMIN@TEST.COM", "SUPERADMIN@TEST.COM", "AQAAAAIAAYagAAAAEBcgezyzUEx9bzgHDXJxTJ6WXVSElRI6kWxqv3quqzrGjQznvLyZYijBOQjyNIsZKA==", "dc796354-4d50-4b50-8b58-7ce646df8a7b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "de0b87d9-f234-4f85-875c-1816f73563ff",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b662578-b05a-4479-bd03-b34cb0df11fd", null, null, "AQAAAAIAAYagAAAAEK3y0ARv4bat+ZY4+muMIKaCUeNSourtUoqLsjQ2/pq3l3XE3mQYcqPXIpzEuPOOnw==", "0be922fe-8e25-4a32-81a2-033578a379fb" });
        }
    }
}

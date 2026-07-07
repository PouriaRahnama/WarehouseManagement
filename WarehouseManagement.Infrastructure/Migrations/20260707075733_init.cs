using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseManagement.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "WarehouseManagement");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "WarehouseManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    MinimumStock = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasure = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    DeletedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ModifiedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "WarehouseManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    DeletedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ModifiedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                schema: "WarehouseManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreatedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    DeletedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ModifiedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRefreshTokens",
                schema: "WarehouseManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    RevokedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    DeletedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ModifiedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "WarehouseManagement",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockBalances",
                schema: "WarehouseManagement",
                columns: table => new
                {
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    DeletedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ModifiedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockBalances", x => new { x.WarehouseId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_StockBalances_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "WarehouseManagement",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockBalances_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "WarehouseManagement",
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockDocuments",
                schema: "WarehouseManagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FromWarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToWarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    DeletedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ModifiedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockDocuments_Warehouses_FromWarehouseId",
                        column: x => x.FromWarehouseId,
                        principalSchema: "WarehouseManagement",
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockDocuments_Warehouses_ToWarehouseId",
                        column: x => x.ToWarehouseId,
                        principalSchema: "WarehouseManagement",
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockDocumentItems",
                schema: "WarehouseManagement",
                columns: table => new
                {
                    StockDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    DeletedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ModifiedByIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockDocumentItems", x => new { x.StockDocumentId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_StockDocumentItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "WarehouseManagement",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockDocumentItems_StockDocuments_StockDocumentId",
                        column: x => x.StockDocumentId,
                        principalSchema: "WarehouseManagement",
                        principalTable: "StockDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "WarehouseManagement",
                table: "Users",
                columns: new[] { "Id", "CreatedByIP", "CreatedByUserId", "DeletedByIP", "DeletedByUserId", "DeletedDateTime", "ModifiedByIP", "ModifiedByUserId", "ModifiedDateTime", "PasswordHash", "PasswordSalt", "Phone", "Role", "Username" },
                values: new object[] { new Guid("6712adb7-a20d-43e9-8b29-357271f3bd65"), null, null, null, null, null, null, null, null, "3c830e2af2e5db02e2f467634499d3c807e7b0c1b09c247a478c893703999b0e", "6081de2f-df32-4e79-a844-772054b8fb32", "09121234567", 10, "AdminUser" });

            migrationBuilder.InsertData(
                schema: "WarehouseManagement",
                table: "Users",
                columns: new[] { "Id", "CreatedByIP", "CreatedByUserId", "DeletedByIP", "DeletedByUserId", "DeletedDateTime", "ModifiedByIP", "ModifiedByUserId", "ModifiedDateTime", "PasswordHash", "PasswordSalt", "Phone", "Role", "Username" },
                values: new object[] { new Guid("92aa3814-ee96-4593-bdd3-cd613268137a"), null, null, null, null, null, null, null, null, "3c830e2af2e5db02e2f467634499d3c807e7b0c1b09c247a478c893703999b0e", "6081de2f-df32-4e79-a844-772054b8fb32", "09139876543", 20, "OperatorUser2" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Code",
                schema: "WarehouseManagement",
                table: "Products",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                schema: "WarehouseManagement",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_StockBalances_ProductId",
                schema: "WarehouseManagement",
                table: "StockBalances",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockDocumentItems_ProductId",
                schema: "WarehouseManagement",
                table: "StockDocumentItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockDocuments_FromWarehouseId",
                schema: "WarehouseManagement",
                table: "StockDocuments",
                column: "FromWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_StockDocuments_Number",
                schema: "WarehouseManagement",
                table: "StockDocuments",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockDocuments_ToWarehouseId",
                schema: "WarehouseManagement",
                table: "StockDocuments",
                column: "ToWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_RefreshToken",
                schema: "WarehouseManagement",
                table: "UserRefreshTokens",
                column: "RefreshToken",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_UserId",
                schema: "WarehouseManagement",
                table: "UserRefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Phone",
                schema: "WarehouseManagement",
                table: "Users",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                schema: "WarehouseManagement",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_Code",
                schema: "WarehouseManagement",
                table: "Warehouses",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_Name",
                schema: "WarehouseManagement",
                table: "Warehouses",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockBalances",
                schema: "WarehouseManagement");

            migrationBuilder.DropTable(
                name: "StockDocumentItems",
                schema: "WarehouseManagement");

            migrationBuilder.DropTable(
                name: "UserRefreshTokens",
                schema: "WarehouseManagement");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "WarehouseManagement");

            migrationBuilder.DropTable(
                name: "StockDocuments",
                schema: "WarehouseManagement");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "WarehouseManagement");

            migrationBuilder.DropTable(
                name: "Warehouses",
                schema: "WarehouseManagement");
        }
    }
}

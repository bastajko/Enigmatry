using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EnigmatryFinancial.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductCode = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WhenUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyConfigs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductCode = table.Column<string>(type: "TEXT", nullable: false),
                    EntityName = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyName = table.Column<int>(type: "INTEGER", nullable: false),
                    VisibilityType = table.Column<int>(type: "INTEGER", nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WhenUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsWhitelisted = table.Column<bool>(type: "INTEGER", nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WhenUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClientVAT = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Website = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyType = table.Column<int>(type: "INTEGER", nullable: false),
                    IsWhitelisted = table.Column<bool>(type: "INTEGER", nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WhenUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenantId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    Currency = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WhenUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FinancialDocumentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WhenUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Documents_FinancialDocumentId",
                        column: x => x.FinancialDocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "ProductCode", "WhenCreated", "WhenUpdated" },
                values: new object[,]
                {
                    { new Guid("2020945e-6da3-468c-8d14-dc10956bafc1"), "ProductA", "ProductA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4f222773-68bd-43ed-8f02-71b3c9b4773e"), "ProductB", "ProductB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PropertyConfigs",
                columns: new[] { "Id", "EntityName", "ProductCode", "PropertyName", "VisibilityType", "WhenCreated", "WhenUpdated" },
                values: new object[,]
                {
                    { new Guid("02210b17-5f26-40ad-80ae-12a9becc9be9"), 1, "ProductA", 5, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0d980124-6f6c-404f-9f9f-0f4e162577ee"), 1, "ProductB", 8, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("103829c8-34e0-44d9-b369-aa4e37c61325"), 1, "ProductB", 9, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1d6030ca-8957-4244-ba21-362d5a20a316"), 0, "ProductA", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1f12fbc3-635b-4005-a056-177f44feb3ec"), 0, "ProductB", 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("21981030-df70-4aa9-b37a-2854804c6c7b"), 1, "ProductA", 9, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("389de7bd-db34-4de5-a223-69f89692159c"), 1, "ProductA", 7, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4cc729ee-4c4e-43aa-a23b-dbe4d68bf7e8"), 1, "ProductB", 7, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5d8b2da6-5ce2-4c2c-957f-0b1c15bf331a"), 0, "ProductB", 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6add967e-3d5f-4729-80df-29f5855395ae"), 0, "ProductB", 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("889e186b-7724-46e0-8beb-4f10c8266c4d"), 0, "ProductB", 3, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("98cbcd4e-94ec-4229-a773-2f3fe9c6c41c"), 0, "ProductA", 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ade3e49c-80bb-4210-a0a7-ed0223378e43"), 0, "ProductA", 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b4e3cc66-88ef-4b87-84c1-d83585f0e038"), 1, "ProductA", 8, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b98886a5-666d-4f73-8bce-3b13a6de9696"), 1, "ProductA", 6, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c296349d-1f07-4655-b541-44f802b8714e"), 1, "ProductB", 6, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ee614dcf-9269-4181-b0f8-b07eeb5490da"), 1, "ProductB", 5, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "IsWhitelisted", "Name", "WhenCreated", "WhenUpdated" },
                values: new object[,]
                {
                    { new Guid("8eb58f39-03a3-4024-8d1d-f58a727eed64"), true, "TenantB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("93bb8aad-e788-4a87-a6a9-612a621a9668"), true, "TenantA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e90985d5-b3c7-4302-8120-8d72727c84c4"), false, "TenantC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "ClientVAT", "CompanyType", "Email", "IsWhitelisted", "Name", "Phone", "RegistrationNumber", "TenantId", "Website", "WhenCreated", "WhenUpdated" },
                values: new object[,]
                {
                    { new Guid("111603fa-e372-4173-b7fe-74e492b8facf"), "", "135792468", 2, "", true, "ClientE", "", "JKL345", new Guid("8eb58f39-03a3-4024-8d1d-f58a727eed64"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("664976ec-ae26-4087-851c-08ef4b8f6129"), "", "123456789", 0, "", true, "ClientA", "", "ABC123", new Guid("93bb8aad-e788-4a87-a6a9-612a621a9668"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bcae78e3-f0cd-4e27-83ba-ed456f45d1f9"), "", "246813579", 1, "", true, "ClientC", "", "DEF789", new Guid("e90985d5-b3c7-4302-8120-8d72727c84c4"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bdb9e183-a3ef-4579-bf7f-4913d97fb53e"), "", "987654321", 0, "", true, "ClientB", "", "XYZ456", new Guid("8eb58f39-03a3-4024-8d1d-f58a727eed64"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c79997d9-afd5-4f12-ab75-e1c24a60a3f5"), "", "369258147", 2, "", true, "ClientF", "", "MNO678", new Guid("8eb58f39-03a3-4024-8d1d-f58a727eed64"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f04d15fe-ac3d-4f87-8811-22b3e2602b65"), "", "654321987", 1, "", true, "ClientD", "", "GHI012", new Guid("93bb8aad-e788-4a87-a6a9-612a621a9668"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "AccountNumber", "Balance", "ClientId", "Currency", "Status", "TenantId", "Type", "WhenCreated", "WhenUpdated" },
                values: new object[,]
                {
                    { new Guid("479184bd-8e27-4d61-a032-e36c64ef4488"), "95867648", 1000.00m, new Guid("f04d15fe-ac3d-4f87-8811-22b3e2602b65"), 1, 5, new Guid("93bb8aad-e788-4a87-a6a9-612a621a9668"), "Invoice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c8dcf52a-c368-46a8-87e5-43c5b6abf015"), "93577094", 2500.00m, new Guid("111603fa-e372-4173-b7fe-74e492b8facf"), 0, 9, new Guid("8eb58f39-03a3-4024-8d1d-f58a727eed64"), "Receipt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Category", "Date", "Description", "FinancialDocumentId", "WhenCreated", "WhenUpdated" },
                values: new object[,]
                {
                    { new Guid("0611ed3f-c640-4321-bae1-16f510a6d64f"), 705.03m, "Food & Dining", new DateTime(2023, 7, 2, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9333), "Grocery shopping", new Guid("479184bd-8e27-4d61-a032-e36c64ef4488"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0881b757-bedf-4e48-b8c1-c9777df5a8fc"), 17.52m, "Shopping", new DateTime(2024, 2, 2, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9249), "Dinner at restaurant", new Guid("c8dcf52a-c368-46a8-87e5-43c5b6abf015"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0fcaac00-01b4-4cc2-8f51-a3485b83bd59"), 783.61m, "Utilities", new DateTime(2023, 3, 17, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9064), "Online shopping", new Guid("c8dcf52a-c368-46a8-87e5-43c5b6abf015"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11387832-d2b6-42fd-8f3e-4c23ad2f44f9"), 581.26m, "Shopping", new DateTime(2023, 5, 18, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9393), "Online shopping", new Guid("c8dcf52a-c368-46a8-87e5-43c5b6abf015"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("289de9f9-d8fc-4699-b917-35956b3d4531"), 913.32m, "Shopping", new DateTime(2023, 11, 4, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9363), "Dinner at restaurant", new Guid("c8dcf52a-c368-46a8-87e5-43c5b6abf015"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3ab0b22e-9ec3-4024-a744-e0da82014bf1"), 677.89m, "Shopping", new DateTime(2023, 11, 11, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9414), "Online shopping", new Guid("479184bd-8e27-4d61-a032-e36c64ef4488"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4a72e24c-33fa-4051-ab44-445d6ebc641b"), 274.69m, "Shopping", new DateTime(2023, 3, 10, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9280), "Grocery shopping", new Guid("479184bd-8e27-4d61-a032-e36c64ef4488"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("52b2e25c-95a3-4448-aa60-99063203ef86"), 514.79m, "Food & Dining", new DateTime(2024, 1, 17, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9462), "Grocery shopping", new Guid("c8dcf52a-c368-46a8-87e5-43c5b6abf015"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5dd65e39-b3ba-4a1f-9215-0eaf3377a242"), 396.11m, "Entertainment", new DateTime(2023, 12, 29, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9383), "Gas station purchase", new Guid("479184bd-8e27-4d61-a032-e36c64ef4488"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6d362412-1afb-4826-894f-d3edd1aabc03"), 542.63m, "Utilities", new DateTime(2023, 3, 2, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9424), "Online shopping", new Guid("c8dcf52a-c368-46a8-87e5-43c5b6abf015"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bbb62e61-b9f3-4abf-a049-3bbd6bcee5c9"), 678.36m, "Food & Dining", new DateTime(2023, 4, 23, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9270), "Gas station purchase", new Guid("479184bd-8e27-4d61-a032-e36c64ef4488"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c3b385c8-9db2-4f48-ad1e-80435630145d"), 136.94m, "Shopping", new DateTime(2023, 4, 28, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9348), "Dinner at restaurant", new Guid("c8dcf52a-c368-46a8-87e5-43c5b6abf015"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cc75bbe9-9cb2-42d5-9889-36a3c26bd347"), 434.44m, "Shopping", new DateTime(2023, 4, 21, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9306), "Dinner at restaurant", new Guid("479184bd-8e27-4d61-a032-e36c64ef4488"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cddeface-0808-46c0-a673-f4018d8eff4b"), 311.73m, "Entertainment", new DateTime(2023, 6, 2, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9315), "Dinner at restaurant", new Guid("479184bd-8e27-4d61-a032-e36c64ef4488"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ce6081d6-5bf7-4fde-bdc8-dc37efaefade"), 708.07m, "Shopping", new DateTime(2023, 5, 17, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9452), "Grocery shopping", new Guid("479184bd-8e27-4d61-a032-e36c64ef4488"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d708241b-cbc4-44e9-a5e3-0dead02f7d75"), 262.04m, "Shopping", new DateTime(2023, 6, 30, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9373), "Online shopping", new Guid("479184bd-8e27-4d61-a032-e36c64ef4488"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e2b3c753-6c63-4cf9-922e-165993d141bb"), 248.83m, "Utilities", new DateTime(2023, 12, 3, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9403), "Online shopping", new Guid("479184bd-8e27-4d61-a032-e36c64ef4488"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e881d0c8-90f1-4aab-934b-69aa724687df"), 787.62m, "Shopping", new DateTime(2023, 9, 5, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9289), "Grocery shopping", new Guid("c8dcf52a-c368-46a8-87e5-43c5b6abf015"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f4a54f09-7a36-4c2c-8322-a2765424e129"), 221.18m, "Utilities", new DateTime(2023, 11, 4, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9437), "Dinner at restaurant", new Guid("479184bd-8e27-4d61-a032-e36c64ef4488"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f8502001-dd23-4a8a-ad6a-1b909cb65163"), 441.24m, "Entertainment", new DateTime(2023, 9, 2, 22, 31, 45, 814, DateTimeKind.Local).AddTicks(9324), "Gas station purchase", new Guid("479184bd-8e27-4d61-a032-e36c64ef4488"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientVAT",
                table: "Clients",
                column: "ClientVAT",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TenantId",
                table: "Clients",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ClientId",
                table: "Documents",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TenantId",
                table: "Documents",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FinancialDocumentId",
                table: "Transactions",
                column: "FinancialDocumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PropertyConfigs");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}

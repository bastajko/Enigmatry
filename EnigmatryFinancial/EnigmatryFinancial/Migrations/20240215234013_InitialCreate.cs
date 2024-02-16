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
                    EntityName = table.Column<string>(type: "TEXT", nullable: false),
                    PropertyName = table.Column<string>(type: "TEXT", nullable: false),
                    IsRetrieved = table.Column<bool>(type: "INTEGER", nullable: false),
                    WhenCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WhenUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
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
                    Currency = table.Column<string>(type: "TEXT", nullable: false),
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
                columns: new[] { "Id", "EntityName", "IsRetrieved", "Name", "ProductCode", "PropertyName", "WhenCreated", "WhenUpdated" },
                values: new object[,]
                {
                    { new Guid("04e42f3a-1a86-4b24-9333-3b78afa906a8"), "", false, "ProductA", "ProductA", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b2f5b843-fb2f-4c95-9df8-ea7ebd526942"), "", false, "ProductB", "ProductB", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "Id", "IsWhitelisted", "Name", "WhenCreated", "WhenUpdated" },
                values: new object[,]
                {
                    { new Guid("96238ea2-6462-4eee-898a-9c0f6c79270f"), false, "TenantC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("988e77da-b0a6-45c2-b085-4c0b667318c6"), true, "TenantA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c61d3258-c9d9-4521-b676-5cc244a2cd1d"), true, "TenantB", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "ClientVAT", "CompanyType", "Email", "IsWhitelisted", "Name", "Phone", "RegistrationNumber", "TenantId", "Website", "WhenCreated", "WhenUpdated" },
                values: new object[,]
                {
                    { new Guid("884bf9cc-1cb7-450f-b2be-c6cd3bdc7ebd"), "", "369258147", 2, "", true, "ClientF", "", "MNO678", new Guid("c61d3258-c9d9-4521-b676-5cc244a2cd1d"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a2b41e8c-a9cb-466b-943a-0a33166ae37f"), "", "987654321", 0, "", true, "ClientB", "", "XYZ456", new Guid("c61d3258-c9d9-4521-b676-5cc244a2cd1d"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b7a11578-2f00-4c48-84d4-20a905d15378"), "", "123456789", 0, "", true, "ClientA", "", "ABC123", new Guid("988e77da-b0a6-45c2-b085-4c0b667318c6"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ea705c01-811c-4772-a894-f5ada838ff83"), "", "135792468", 2, "", true, "ClientE", "", "JKL345", new Guid("c61d3258-c9d9-4521-b676-5cc244a2cd1d"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f2d6ddc2-aaa8-45a5-842c-0f04e929d5dc"), "", "654321987", 1, "", true, "ClientD", "", "GHI012", new Guid("988e77da-b0a6-45c2-b085-4c0b667318c6"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fc4b173b-3642-43b6-9a07-4fee284ea4f0"), "", "246813579", 1, "", true, "ClientC", "", "DEF789", new Guid("96238ea2-6462-4eee-898a-9c0f6c79270f"), "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "AccountNumber", "Balance", "ClientId", "Currency", "TenantId", "Type", "WhenCreated", "WhenUpdated" },
                values: new object[,]
                {
                    { new Guid("234514aa-cdb8-4fad-be96-7cca98fb3337"), "93577094", 2500.00m, new Guid("ea705c01-811c-4772-a894-f5ada838ff83"), "EUR", new Guid("c61d3258-c9d9-4521-b676-5cc244a2cd1d"), "Receipt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5ebe5661-1129-402d-952d-b4baccc6dddd"), "95867648", 1000.00m, new Guid("f2d6ddc2-aaa8-45a5-842c-0f04e929d5dc"), "USD", new Guid("988e77da-b0a6-45c2-b085-4c0b667318c6"), "Invoice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Category", "Date", "Description", "FinancialDocumentId", "WhenCreated", "WhenUpdated" },
                values: new object[,]
                {
                    { new Guid("1dea3d13-0968-4efe-803d-4704928494af"), 6.08m, "Food & Dining", new DateTime(2023, 6, 20, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(9224), "Gas station purchase", new Guid("234514aa-cdb8-4fad-be96-7cca98fb3337"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2ebf1c7d-c529-436a-8944-28d826ecad07"), 652.48m, "Shopping", new DateTime(2024, 2, 5, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(8831), "Grocery shopping", new Guid("5ebe5661-1129-402d-952d-b4baccc6dddd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("31c65c4c-9c64-4913-a168-af55ec9bc0f2"), 478.50m, "Food & Dining", new DateTime(2023, 11, 26, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(8977), "Dinner at restaurant", new Guid("5ebe5661-1129-402d-952d-b4baccc6dddd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3eaea83b-3258-417b-8791-068b95f63b5a"), 767.42m, "Food & Dining", new DateTime(2023, 2, 27, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(9008), "Gas station purchase", new Guid("234514aa-cdb8-4fad-be96-7cca98fb3337"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("48b16e98-e11b-44ce-b699-6bb095928cd0"), 719.74m, "Food & Dining", new DateTime(2023, 4, 1, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(9152), "Grocery shopping", new Guid("5ebe5661-1129-402d-952d-b4baccc6dddd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4a52e48d-e652-4bbc-bbf8-339e4efbb41b"), 582.48m, "Utilities", new DateTime(2023, 9, 24, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(9034), "Dinner at restaurant", new Guid("5ebe5661-1129-402d-952d-b4baccc6dddd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("72dcd04b-bffd-4757-a44d-ff26a9bdf6a0"), 237.76m, "Food & Dining", new DateTime(2024, 2, 12, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(9164), "Dinner at restaurant", new Guid("5ebe5661-1129-402d-952d-b4baccc6dddd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7363cd12-5d2c-4ecb-a419-1c11d6cfd019"), 61.61m, "Utilities", new DateTime(2023, 3, 21, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(9077), "Grocery shopping", new Guid("234514aa-cdb8-4fad-be96-7cca98fb3337"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c383895-24ff-4928-a1b5-408597d47b62"), 231.37m, "Shopping", new DateTime(2023, 4, 12, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(9197), "Online shopping", new Guid("5ebe5661-1129-402d-952d-b4baccc6dddd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c4eeddc-e877-4162-92d2-3e749a40e408"), 136.88m, "Food & Dining", new DateTime(2023, 4, 8, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(9175), "Online shopping", new Guid("5ebe5661-1129-402d-952d-b4baccc6dddd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("816c7088-3402-43c3-8ebb-32ee81ebf164"), 761.16m, "Utilities", new DateTime(2024, 2, 1, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(8989), "Grocery shopping", new Guid("234514aa-cdb8-4fad-be96-7cca98fb3337"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("83c4d003-54d3-4c06-a336-36d20d11f9a1"), 600.02m, "Utilities", new DateTime(2023, 4, 9, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(9111), "Gas station purchase", new Guid("5ebe5661-1129-402d-952d-b4baccc6dddd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9bd04776-e674-4d8f-ba55-aa31499ed8f3"), 958.69m, "Shopping", new DateTime(2023, 10, 12, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(9123), "Gas station purchase", new Guid("5ebe5661-1129-402d-952d-b4baccc6dddd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9fb77465-8f0e-4c80-8b7d-cc39cc916afc"), 160.98m, "Utilities", new DateTime(2023, 6, 15, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(9235), "Grocery shopping", new Guid("234514aa-cdb8-4fad-be96-7cca98fb3337"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b2fc4935-5f43-40a2-8d74-26bab86d14c1"), 244.20m, "Shopping", new DateTime(2023, 3, 25, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(9213), "Gas station purchase", new Guid("234514aa-cdb8-4fad-be96-7cca98fb3337"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ca1d8267-dffb-4bee-9c15-ad501524123d"), 793.12m, "Entertainment", new DateTime(2023, 7, 30, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(9134), "Dinner at restaurant", new Guid("234514aa-cdb8-4fad-be96-7cca98fb3337"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d7ce1023-2c29-45bb-a41c-e6262d085c08"), 395.76m, "Food & Dining", new DateTime(2023, 3, 28, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(9044), "Online shopping", new Guid("234514aa-cdb8-4fad-be96-7cca98fb3337"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("df71c41a-5cd4-4020-894e-5de5f3b44e35"), 964.82m, "Entertainment", new DateTime(2024, 1, 15, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(9022), "Online shopping", new Guid("234514aa-cdb8-4fad-be96-7cca98fb3337"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e2239064-df59-4bac-b61b-7ba35613c5de"), 694.34m, "Food & Dining", new DateTime(2024, 2, 4, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(8962), "Dinner at restaurant", new Guid("234514aa-cdb8-4fad-be96-7cca98fb3337"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f454e27e-12c1-4c14-a82a-facea28666e9"), 900.86m, "Entertainment", new DateTime(2023, 12, 26, 0, 40, 9, 849, DateTimeKind.Local).AddTicks(9186), "Grocery shopping", new Guid("5ebe5661-1129-402d-952d-b4baccc6dddd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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

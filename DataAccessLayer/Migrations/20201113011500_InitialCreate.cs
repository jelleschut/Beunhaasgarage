using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 40, nullable: false),
                    Street = table.Column<string>(maxLength: 40, nullable: false),
                    HouseNumber = table.Column<int>(nullable: false),
                    Zipcode = table.Column<string>(maxLength: 10, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    OwnerType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    BrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenseNumber = table.Column<string>(maxLength: 8, nullable: false),
                    Status = table.Column<string>(nullable: true),
                    ModelId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    DriverOwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_Cars_Owners_DriverOwnerId",
                        column: x => x.DriverOwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceSpecifications",
                columns: table => new
                {
                    MaintenanceSpecificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Milage = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MaintenanceType = table.Column<string>(nullable: false),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceSpecifications", x => x.MaintenanceSpecificationId);
                    table.ForeignKey(
                        name: "FK_MaintenanceSpecifications_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, "Audi" },
                    { 2, "BMW" },
                    { 3, "Fiat" },
                    { 4, "Renault" },
                    { 5, "Skoda" },
                    { 6, "Volkswagen" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerId", "City", "Email", "HouseNumber", "Name", "OwnerType", "PhoneNumber", "Street", "Zipcode" },
                values: new object[,]
                {
                    { 1, "Deventer", "jelleschut@hotmail.com", 77, "Jelle Schut", "CUSTOMER", "0657013971", "Keizer Frederikstraat", "7415KC" },
                    { 2, "Deventer", "jelleschut@hotmail.com", 77, "Fred Flintstone", "CUSTOMER", "0657013971", "Keizer Frederikstraat", "7415KC" },
                    { 3, "Deventer", "jelleschut@hotmail.com", 77, "Sjaak Swart", "CUSTOMER", "0657013971", "Keizer Frederikstraat", "7415KC" },
                    { 4, "Deventer", "jelleschut@hotmail.com", 77, "Pietje Puk", "CUSTOMER", "0657013971", "Keizer Frederikstraat", "7415KC" },
                    { 5, "Deventer", "jelleschut@hotmail.com", 77, "Michael Schumacher", "CUSTOMER", "0657013971", "Keizer Frederikstraat", "7415KC" },
                    { 6, "Deventer", "jelleschut@hotmail.com", 77, "Johan Cruijff", "CUSTOMER", "0657013971", "Keizer Frederikstraat", "7415KC" },
                    { 7, "SomeCity", null, 1, "SomeCompany", "LEASECOMPANY", null, "SomeStreet", "1234AB" },
                    { 8, "OtherCity", null, 1, "OtherCompany", "LEASECOMPANY", null, "OtherStreet", "4321XZ" },
                    { 9, "ThirdCity", null, 1, "ThirdCompany", "LEASECOMPANY", null, "ThirdStreet", "0987TX" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "ModelId", "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "A4" },
                    { 2, 2, "M6" },
                    { 3, 3, "Punto" },
                    { 4, 4, "Clio" },
                    { 5, 5, "Superb" },
                    { 6, 6, "Golf" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "DriverOwnerId", "LicenseNumber", "ModelId", "OwnerId", "Status" },
                values: new object[,]
                {
                    { 1, 1, "1-ABC-23", 1, 1, "REGISTERED" },
                    { 2, 2, "9-ZYX-87", 2, 2, "REGISTERED" },
                    { 3, 3, "6-XXX-66", 3, 3, "REGISTERED" },
                    { 4, 4, "AB-CD-12", 4, 7, "REGISTERED" },
                    { 5, 5, "98-ZY-XW", 5, 8, "REGISTERED" },
                    { 6, 6, "XD-XD-88", 6, 9, "REGISTERED" }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceSpecifications",
                columns: new[] { "MaintenanceSpecificationId", "CarId", "Date", "Description", "MaintenanceType", "Milage" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 11, 13, 2, 15, 0, 96, DateTimeKind.Local).AddTicks(1902), "Reparatie", "REPAIR", 1234567890 },
                    { 2, 2, new DateTime(2020, 11, 13, 2, 15, 0, 100, DateTimeKind.Local).AddTicks(2128), "Reparatie", "REPAIR", 1234567890 },
                    { 3, 3, new DateTime(2020, 11, 13, 2, 15, 0, 100, DateTimeKind.Local).AddTicks(2189), "Reparatie", "REPAIR", 1234567890 },
                    { 4, 4, new DateTime(2020, 11, 13, 2, 15, 0, 100, DateTimeKind.Local).AddTicks(2193), "APK", "MOT", 1234567890 },
                    { 5, 5, new DateTime(2020, 11, 13, 2, 15, 0, 100, DateTimeKind.Local).AddTicks(3593), "APK", "MOT", 1234567890 },
                    { 6, 6, new DateTime(2020, 11, 13, 2, 15, 0, 100, DateTimeKind.Local).AddTicks(3626), "APK", "MOT", 1234567890 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DriverOwnerId",
                table: "Cars",
                column: "DriverOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelId",
                table: "Cars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_OwnerId",
                table: "Cars",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceSpecifications_CarId",
                table: "MaintenanceSpecifications",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceSpecifications");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}

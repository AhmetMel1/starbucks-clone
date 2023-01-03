using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    addressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    district = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    neighbourhood = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apartmentNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    addressDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.addressId);
                });

            migrationBuilder.CreateTable(
                name: "CargoProcesses",
                columns: table => new
                {
                    cargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cargoStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cargoProcessDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoProcesses", x => x.cargoId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    categoryLogoUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    categoryDeleted = table.Column<bool>(type: "bit", nullable: false),
                    categoryParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.categoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_categoryParentId",
                        column: x => x.categoryParentId,
                        principalTable: "Categories",
                        principalColumn: "categoryId");
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    menuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menuName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    menuDeleted = table.Column<bool>(type: "bit", nullable: false),
                    menuParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.menuId);
                    table.ForeignKey(
                        name: "FK_Menus_Menus_menuParentId",
                        column: x => x.menuParentId,
                        principalTable: "Menus",
                        principalColumn: "menuId");
                });

            migrationBuilder.CreateTable(
                name: "OptionTypes",
                columns: table => new
                {
                    optionTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    optionTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    optionTypeDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionTypes", x => x.optionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PropertyMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    sizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sizeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sizeDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.sizeId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StoreLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StoreDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    userTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    userTypeDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.userTypeId);
                });

            migrationBuilder.CreateTable(
                name: "WorkTimes",
                columns: table => new
                {
                    workTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    openingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    closingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkTimeDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTimes", x => x.workTimeId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    productLogoUrl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    productDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    productDeleted = table.Column<bool>(type: "bit", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "Categories",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    optionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    optionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    optionUnitPrice = table.Column<int>(type: "int", nullable: false),
                    optionDeleted = table.Column<bool>(type: "bit", nullable: false),
                    optionTypeId = table.Column<int>(type: "int", nullable: false),
                    optionParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.optionId);
                    table.ForeignKey(
                        name: "FK_Options_OptionTypes_optionTypeId",
                        column: x => x.optionTypeId,
                        principalTable: "OptionTypes",
                        principalColumn: "optionTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Options_Options_optionParentId",
                        column: x => x.optionParentId,
                        principalTable: "Options",
                        principalColumn: "optionId");
                });

            migrationBuilder.CreateTable(
                name: "StoreFavorites",
                columns: table => new
                {
                    StoreFavoriteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreFavoriteDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreFavorites", x => x.StoreFavoriteId);
                    table.ForeignKey(
                        name: "FK_StoreFavorites_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreProducts",
                columns: table => new
                {
                    StoreProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    StoreProductDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProducts", x => x.StoreProductId);
                    table.ForeignKey(
                        name: "FK_StoreProducts_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreProducts_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreProperties",
                columns: table => new
                {
                    StorePropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorePropertyDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProperties", x => x.StorePropertyId);
                    table.ForeignKey(
                        name: "FK_StoreProperties_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreProperties_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    userDeleted = table.Column<bool>(type: "bit", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    addressId = table.Column<int>(type: "int", nullable: false),
                    userTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_addressId",
                        column: x => x.addressId,
                        principalTable: "Addresses",
                        principalColumn: "addressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_userTypeId",
                        column: x => x.userTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "userTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreOpeningHours",
                columns: table => new
                {
                    storeOpeningHourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreOpeningHourDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    workTimeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreOpeningHours", x => x.storeOpeningHourId);
                    table.ForeignKey(
                        name: "FK_StoreOpeningHours_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreOpeningHours_WorkTimes_workTimeId",
                        column: x => x.workTimeId,
                        principalTable: "WorkTimes",
                        principalColumn: "workTimeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    productSizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productSizePrice = table.Column<int>(type: "int", nullable: false),
                    productSizeCapacity = table.Column<int>(type: "int", nullable: false),
                    unitPrice = table.Column<int>(type: "int", nullable: false),
                    productSizeDeleted = table.Column<bool>(type: "bit", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    sizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => x.productSizeId);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Sizes_sizeId",
                        column: x => x.sizeId,
                        principalTable: "Sizes",
                        principalColumn: "sizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customizations",
                columns: table => new
                {
                    customizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customizationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    customizationDeleted = table.Column<bool>(type: "bit", nullable: false),
                    optionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customizations", x => x.customizationId);
                    table.ForeignKey(
                        name: "FK_Customizations_Options_optionId",
                        column: x => x.optionId,
                        principalTable: "Options",
                        principalColumn: "optionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    favoriteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uploadDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    favoriteDeleted = table.Column<bool>(type: "bit", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.favoriteId);
                    table.ForeignKey(
                        name: "FK_Favorites_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentType = table.Column<byte>(type: "tinyint", nullable: false),
                    orderDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    orderQuantity = table.Column<int>(type: "int", nullable: false),
                    orderStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    cardAddedDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    orderDeleted = table.Column<bool>(type: "bit", nullable: false),
                    productSizeId = table.Column<int>(type: "int", nullable: false),
                    cargoId = table.Column<int>(type: "int", nullable: false),
                    cargoProcesscargoId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_Orders_CargoProcesses_cargoProcesscargoId",
                        column: x => x.cargoProcesscargoId,
                        principalTable: "CargoProcesses",
                        principalColumn: "cargoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_ProductSizes_productSizeId",
                        column: x => x.productSizeId,
                        principalTable: "ProductSizes",
                        principalColumn: "productSizeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCustomizations",
                columns: table => new
                {
                    productCustomizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productCustomizationDeleted = table.Column<bool>(type: "bit", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    customizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCustomizations", x => x.productCustomizationId);
                    table.ForeignKey(
                        name: "FK_ProductCustomizations_Customizations_customizationId",
                        column: x => x.customizationId,
                        principalTable: "Customizations",
                        principalColumn: "customizationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCustomizations_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_categoryParentId",
                table: "Categories",
                column: "categoryParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_optionId",
                table: "Customizations",
                column: "optionId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_productId",
                table: "Favorites",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_userId",
                table: "Favorites",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_menuParentId",
                table: "Menus",
                column: "menuParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_optionParentId",
                table: "Options",
                column: "optionParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_optionTypeId",
                table: "Options",
                column: "optionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_cargoProcesscargoId",
                table: "Orders",
                column: "cargoProcesscargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_productSizeId",
                table: "Orders",
                column: "productSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userId",
                table: "Orders",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomizations_customizationId",
                table: "ProductCustomizations",
                column: "customizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomizations_productId",
                table: "ProductCustomizations",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryId",
                table: "Products",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_productId",
                table: "ProductSizes",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_sizeId",
                table: "ProductSizes",
                column: "sizeId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreFavorites_StoreId",
                table: "StoreFavorites",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOpeningHours_StoreId",
                table: "StoreOpeningHours",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOpeningHours_workTimeId",
                table: "StoreOpeningHours",
                column: "workTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProducts_PropertyId",
                table: "StoreProducts",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProducts_StoreId",
                table: "StoreProducts",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProperties_PropertyId",
                table: "StoreProperties",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProperties_StoreId",
                table: "StoreProperties",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_addressId",
                table: "Users",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_userTypeId",
                table: "Users",
                column: "userTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductCustomizations");

            migrationBuilder.DropTable(
                name: "StoreFavorites");

            migrationBuilder.DropTable(
                name: "StoreOpeningHours");

            migrationBuilder.DropTable(
                name: "StoreProducts");

            migrationBuilder.DropTable(
                name: "StoreProperties");

            migrationBuilder.DropTable(
                name: "CargoProcesses");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Customizations");

            migrationBuilder.DropTable(
                name: "WorkTimes");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "OptionTypes");
        }
    }
}

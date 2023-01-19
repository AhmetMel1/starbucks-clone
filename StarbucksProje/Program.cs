var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Errors","?code={0}");	

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
                name: "Address", pattern: "Address/address-list", defaults: new { controller = "Address", action = "Index" }
                );

app.MapControllerRoute(
                name: "CargoProcess", pattern: "CargoProcess/cargo-process-list", defaults: new { controller = "CargoProcess", action = "Index" }
                );

app.MapControllerRoute(
                name: "Category", pattern: "Category/category-list", defaults: new { controller = "Category", action = "Index" }
                );

app.MapControllerRoute(
                name: "Customization", pattern: "Customization/customizations-list", defaults: new { controller = "Customization", action = "Index" }
                );

app.MapControllerRoute(
                name: "Favorite", pattern: "Favorite/favorites-list", defaults: new { controller = "Favorite", action = "Index" }
                );

app.MapControllerRoute(
                name: "Menu", pattern: "Menu/menu-list", defaults: new { controller = "Menu", action = "Index" }
                );

app.MapControllerRoute(
                name: "Option", pattern: "Option/option-list", defaults: new { controller = "Option", action = "Index" }
                );

app.MapControllerRoute(
                name: "OptionType", pattern: "OptionType/option-type-list", defaults: new { controller = "OptionType", action = "Index" }
                );

app.MapControllerRoute(
                name: "Order", pattern: "Order/order-list", defaults: new { controller = "Order", action = "Index" }
                );

app.MapControllerRoute(
                name: "Product", pattern: "Product/products-list", defaults: new { controller = "Product", action = "Index" }
                );

app.MapControllerRoute(
                name: "ProductCustomization", pattern: "ProductCustomization/product-customization-list", defaults: new { controller = "ProductCustomization", action = "Index" }
                );

app.MapControllerRoute(
                name: "ProductSize", pattern: "ProductSize/product-size-list", defaults: new { controller = "ProductSize", action = "Index" }
                );
app.MapControllerRoute(
                name: "Property", pattern: "Property/propertys-list", defaults: new { controller = "Property", action = "ListProperty" }
                );

app.MapControllerRoute(
                name: "Size", pattern: "Size/sizes-list", defaults: new { controller = "Size", action = "Index" }
                );

app.MapControllerRoute(
                name: "Store", pattern: "Store/store-list", defaults: new { controller = "Store", action = "ListStore" }
                );

app.MapControllerRoute(
                name: "StoreFavorite", pattern: "StoreFavorite/store-favorite-list", defaults: new { controller = "StoreFavorite", action = "ListStoreFavorite" }
                );

app.MapControllerRoute(
                name: "StoreOpeningHour", pattern: "StoreOpeningHour/store-opening-hour-list", defaults: new { controller = "StoreOpeningHour", action = "ListStoreOpeningHour" }
                );

app.MapControllerRoute(
                name: "StoreProduct", pattern: "StoreProduct/store-product-list", defaults: new { controller = "StoreProduct", action = "ListStoreProduct" }
                );

app.MapControllerRoute(
                name: "StoreProperty", pattern: "StoreProperty/store-property-list", defaults: new { controller = "StoreProperty", action = "ListStoreProperty" }
                );

app.MapControllerRoute(
                name: "User", pattern: "User/user-list", defaults: new { controller = "User", action = "Index" }
                );

app.MapControllerRoute(
                name: "WorkTime", pattern: "WorkTime/work-time-list", defaults: new { controller = "WorkTime", action = "ListWorkTime" }
                );
app.Run();

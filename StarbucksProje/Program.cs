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
                name: "Category", pattern: "Category/category-list", defaults: new { controller = "Category", action = "Index" }
                );

app.MapControllerRoute(
                name: "Customization", pattern: "Customization/customization-list", defaults: new { controller = "Customization", action = "Index" }
                );

app.MapControllerRoute(
                name: "Option", pattern: "Option/option-list", defaults: new { controller = "Option", action = "Index" }
                );

app.MapControllerRoute(
                name: "OptionType", pattern: "OptionType/option-type-list", defaults: new { controller = "OptionType", action = "Index" }
                );

app.MapControllerRoute(
                name: "Product", pattern: "Product/product-list", defaults: new { controller = "Product", action = "Index" }
                );

app.MapControllerRoute(
                name: "ProductCustomization", pattern: "ProductCustomization/product-customization-list", defaults: new { controller = "ProductCustomization", action = "Index" }
                );

app.MapControllerRoute(
                name: "ProductSize", pattern: "ProductSize/product-size-list", defaults: new { controller = "ProductSize", action = "Index" }
                );

app.MapControllerRoute(
                name: "Size", pattern: "Size/size-list", defaults: new { controller = "Size", action = "Index" }
                );
app.Run();

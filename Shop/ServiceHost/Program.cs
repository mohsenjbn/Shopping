using DiscountManegmant.Infrastracture.Configoration;
using InventoryManagement.Infrastracture.Configuration;
using ShopManagement.Configuration;

var builder = WebApplication.CreateBuilder(args);
var ConnectionString = builder.Configuration.GetConnectionString("Shop");
// Add services to the container.
builder.Services.AddRazorPages();

ShopManagementBootstrapper.Configure(builder.Services, ConnectionString);
DiscountManagementBootStrapper.configore(builder.Services, ConnectionString);
InventoryManagementBootstrapper.Configure(builder.Services, ConnectionString);
var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

app.MapRazorPages();

app.Run();

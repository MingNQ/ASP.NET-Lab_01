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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Cau hinh Route Admin/Student/List
app.MapControllerRoute(
	name: "adminRoute",
	pattern: "Admin/Student/List",
	defaults: new { controller = "Student", action = "Index" }
);

// Cau hinh Route Admin/Student/Add
app.MapControllerRoute(
	name: "adminRoute",
	pattern: "Admin/Student/Add",
	defaults: new { controller = "Student", action = "Create" }
);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

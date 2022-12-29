using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.Concrete;
using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ITranslatorService, TranslatorManager>();
builder.Services.AddTransient<ITranslatorDal, EfTranslatorDal>();

builder.Services.AddTransient<IBookService, BookManager>();
builder.Services.AddTransient<IBookDal, EfBookDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
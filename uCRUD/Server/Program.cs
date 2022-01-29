using uCRUD.Server.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using uCRUD.Server.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UserDbContext>(opts => opts.UseNpgsql(@"Host=ec2-3-216-113-109.compute-1.amazonaws.com:5432;Username=cepjieogclvida;Password=04aab15baa6d1e4c484ca0d4fe70c43acbb7e8b4b849e655c4156014aedd2981;Database=d2etnor3841onj"));
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

string? port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrWhiteSpace(port)) 
{ 
    app.Urls.Add("http://*:" + port); 
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

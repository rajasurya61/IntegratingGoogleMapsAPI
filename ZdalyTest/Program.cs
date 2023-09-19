using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ZdalyTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Add this line to support API controllers

// Register CsvService as a scoped service
builder.Services.AddScoped<CsvService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Configure CORS policy
app.UseCors(builder =>
{
    builder.AllowAnyOrigin(); // You can also specify specific origins here
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
});

// Map API controllers
app.MapControllers(); // Add this line to map your API controllers

app.Run();

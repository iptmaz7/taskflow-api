var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts(); 
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.MapControllers(); 

app.Run();
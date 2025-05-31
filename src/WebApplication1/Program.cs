using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApplication1;
using WebApplication1.Profiles;

var builder = WebApplication.CreateBuilder(args);

// In-memory repository'i ekleyin
builder.Services.AddSingleton<InMemoryRepository>();

// Swagger'ı projeye dahil edin
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Swagger'ı projeye dahil et

// AutoMapper'ı DI konteynerine ekleyin
builder.Services.AddAutoMapper(typeof(MappingProfile)); // Profil sınıfınızı burada belirtiyoruz

// PostgreSQL veritabanı bağlantısı ekleyin
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection"))
);
// Swagger'ı DI konteynerine ekleyin
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "A simple example ASP.NET Core Web API"
    });
});

builder.Services.AddControllers();
var app = builder.Build();


// Swagger UI'ı geliştirme ortamında kullanmak için aşağıdaki satırları ekleyin
//if (app.Environment.IsDevelopment()
{
    
}
app.UseDeveloperExceptionPage();
app.UseSwagger();  // Swagger'ı etkinleştir
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");  // Swagger UI endpoint'ini belirtin
    });
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate(); // migration'ı otomatik çalıştırır
}

app.Run();
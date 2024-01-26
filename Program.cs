using gerenciamento_estoque.Data;
using Microsoft.EntityFrameworkCore;
using gerenciamento_estoque.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProdutoContext>(options => {
    options.UseMySql(builder.Configuration.GetConnectionString("Default"),
    new MySqlServerVersion(new Version(8, 0, 35)));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHsts();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProdutoContext>();

    // Verificar se já existem dados no MapaEstoque
    if (!dbContext.MapaEstoque.Any())
    {
        // Adicionar dados padrões ao MapaEstoque
        for (int linha = 1; linha <= 5; linha++)
        {
            for (int coluna = 1; coluna <= 5; coluna++)
            {
                dbContext.MapaEstoque.Add(new MapaEstoque
                {
                    Linha = linha,
                    Coluna = coluna,
                    CapacidadeMaxima = 1000
                });
            }
        }

        dbContext.SaveChanges();
    }
}

app.Run();

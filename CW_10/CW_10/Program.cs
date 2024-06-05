using CW_10.Contexts;
using CW_10.Exceptions;
using CW_10.ResponseModel;
using CW_10.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<DatabaseContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/accounts/{id:int}", async (int id, IAccountService service, CancellationToken cancellationToken) =>
{
    try
    {
        return Results.Ok(await service.GetAccountByIdAsync(id, cancellationToken));
    }
    catch (NotFoundException exc)
    {
        return Results.NotFound(exc.Message);
    }
});

app.MapPost("api/products", async (PostProductResponseModel model, IProductService productService, CancellationToken cancellationToken) =>
{
    try
    {
        var product = await productService.PostProductAsync(model, cancellationToken);
        return Results.Created($"/api/products", product);
    }
    catch (Exception exc)
    {
        return Results.Problem(exc.Message);
    }
});

app.Run();

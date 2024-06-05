using CW_10.Contexts;
using CW_10.Exceptions;
using CW_10.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAccountService, AccountService>();
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

app.MapGet("api/accounts/{accountId:int}", async (int id, IAccountService service, CancellationToken cancellationToken) =>
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

app.Run();

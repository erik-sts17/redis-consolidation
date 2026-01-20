using Back.Redis.Api.Configurations;
using Back.Redis.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddRedis(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddClients(builder.Configuration);
builder.Services.AddMappings();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<RefitExceptionMiddleware>();

app.MapControllers();

app.Run();
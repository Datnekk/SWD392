
using be.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllersServices();
builder.Services.AddDatabaseServices(builder.Configuration);
builder.Services.AddIdentityServices();
builder.Services.AddAuthenticationServices(builder.Configuration);
builder.Services.AddDependencyInjectionServices();
builder.Services.AddAutoMapperServices();
builder.Services.AddCorsServices(builder.Configuration, builder.Environment);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.MapOpenApi();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.AddScalarServices(app.Environment);
app.UseCorsPolicy(builder.Environment);
app.Run();



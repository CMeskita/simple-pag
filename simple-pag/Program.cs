using simple_pag.Middleware;
using simple_pag.Shared.Util;



var builder = WebApplication.CreateBuilder(args);
//ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");
DotEnv.Load(dotenv);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerMiddleware();
builder.Services.AddJwtMiddleware();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);



var app = builder.Build();

//CORS
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("Open", policy => policy.WithOrigins().AllowAnyHeader().AllowAnyMethod());
//});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API-Pagamentos v1"));
}
app.UseCors("Open");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

using Sol.PuntoVenta.Data.Connections;
using Sol.PuntoVenta.Data.Datos;
using Sol.PuntoVenta.Negocio.Negocios;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddSingleton<PuntoVentaData>();
builder.Services.AddSingleton<PuntoVentaN>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{

    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://netcoretecweb.somee.com",
                                              "https://netcoretecweb.somee.com",
                                              "http://localhost:3000/")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                          policy.SetIsOriginAllowed(origen => new Uri(origen).Host == "https://netcoretecweb.somee.com").AllowAnyHeader().AllowAnyMethod();
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(x => x
       .AllowAnyMethod()
       .AllowAnyHeader()
       .SetIsOriginAllowed(origin => true) // allow any origin 
       .AllowCredentials());
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();

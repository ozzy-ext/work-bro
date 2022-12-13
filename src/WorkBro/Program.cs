using WorkBro;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var srv = builder.Services;
    
srv.AddControllers();

srv.Configure<BroOptions>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

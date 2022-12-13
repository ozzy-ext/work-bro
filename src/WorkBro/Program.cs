using MyLab.ApiClient;
using WorkBro;
using WorkBro.Services;
using WorkBro.Telegram;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var srv = builder.Services;
    
srv.AddControllers();

srv.Configure<BroOptions>(builder.Configuration)
    .AddHostedService<UpdatesPollHostService>()
    .AddSingleton<IBroLogic, BroLogic>()
    .AddApiClients(r => r.RegisterContract<ITelegramBotApi>())
    .ConfigureApiClients(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.Extensions.Options;
using MyLab.Log.Dsl;
using WorkBro.Telegramm;

namespace WorkBro.Services
{
    class UpdatesPollHostService : BackgroundService
    {
        private readonly ITelegramBotApi _api;
        private readonly IBroLogic _broLogic;
        private readonly BroOptions _options;
        private readonly IDslLogger? _log;

        public UpdatesPollHostService(
            ITelegramBotApi api, 
            IBroLogic broLogic, 
            IOptions<BroOptions> options,
            ILogger<UpdatesPollHostService>? logger = null)
        {
            _api = api;
            _broLogic = broLogic;
            _options = options.Value;
            _log = logger?.Dsl();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                TelegramUpdate[]? updates;

                try
                {
                    updates = await _api.GetUpdatesAsync("bot" + _options.Token, -1, 10, 25);
                }
                catch (Exception e)
                {
                    _log?.Error("Get Updates error", e)
                        .Write();

                    await Task.Delay(1000, stoppingToken);

                    continue;
                }

                if (updates != null && updates.Length != 0)
                {
                    try
                    {
                        await _broLogic.ProcessUpdatesAsync(updates);
                    }
                    catch (Exception e)
                    {
                        _log?.Error("Processing Updates error", e)
                            .Write();

                        await Task.Delay(1000, stoppingToken);

                        continue; 
                    }
                }

            } while (!stoppingToken.IsCancellationRequested);
        }
    }
}

using WorkBro.Telegram;
namespace WorkBro.Services
{
    interface IBroLogic
    {
        Task ProcessUpdatesAsync(TelegramUpdate[] updates);
    }

    class BroLogic : IBroLogic
    {
        public Task ProcessUpdatesAsync(TelegramUpdate[] updates)
        {
            return Task.CompletedTask;
        }
    }
}

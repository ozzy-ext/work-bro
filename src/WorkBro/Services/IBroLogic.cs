using WorkBro.Telegramm;

namespace WorkBro.Services
{
    interface IBroLogic
    {
        Task ProcessUpdatesAsync(TelegramUpdate[] updates);
    }
}

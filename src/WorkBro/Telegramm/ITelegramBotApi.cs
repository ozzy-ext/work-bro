using MyLab.ApiClient;
using Newtonsoft.Json;

namespace WorkBro.Telegramm
{
    [Api("https://api.telegram.org/bot{token}")]
    public interface ITelegramBotApi
    {
        Task<TelegramUpdate[]?> GetUpdatesAsync([Path("token")] string token, [Query("offset")] int offset, [Query("limit")] int limit, [Query("timeout")] int timeoutSec);
    }

    public class TelegramUpdate
    {
        [JsonProperty("update_id")]
        public int UpdateId { get; set; }
    }
}

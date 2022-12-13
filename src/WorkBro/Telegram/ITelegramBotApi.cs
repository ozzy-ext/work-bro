using MyLab.ApiClient;
using Newtonsoft.Json;

namespace WorkBro.Telegram
{
    [Api(Key = "telegram")]
    public interface ITelegramBotApi
    {
        [Get("getUpdates")]
        Task<TelegramResult<TelegramUpdate[]>?> GetUpdatesAsync([Query("offset")] int offset, [Query("limit")] int limit, [Query("timeout")] int timeoutSec);
    }

    public class TelegramResult<TResult>
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("result")]
        public TResult? Result { get; set; }
    }

    public class TelegramUpdate
    {
        [JsonProperty("update_id")]
        public int UpdateId { get; set; }
    }
}

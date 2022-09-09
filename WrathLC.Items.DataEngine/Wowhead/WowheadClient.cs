using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WrathLC.Items.DataEngine.Wowhead
{
    public interface IWowheadClient
    {
        Task<WowheadDataObject> Get(string item);
    }

    public class WowheadClient : IWowheadClient
    {
        private readonly HttpClient _client;

        public WowheadClient()
        {
            _client = new HttpClient {BaseAddress = new Uri(@"https://www.wowhead.com/wotlk/")};
        }

        public async Task<WowheadDataObject> Get(string item)
        {
            var httpResult = await _client.GetAsync($"{_client.BaseAddress}item={item.ToLowerInvariant()}&xml");
            if (!httpResult.IsSuccessStatusCode)
            {
                return null;
            }
            var xmlStream = await httpResult.Content.ReadAsStreamAsync();
            var serializer = new XmlSerializer(typeof(WowheadDataObject));
            var obj = serializer.Deserialize(xmlStream);
            var itemResult = obj as WowheadDataObject;
            if (!string.IsNullOrEmpty(itemResult?.Item?.JsonEquipRaw))
            {
                itemResult.Item.JsonEquip = JsonSerializer.Deserialize<JsonEquip>('{' + itemResult.Item.JsonEquipRaw + '}');
            }

            return itemResult;
        }
    }
}
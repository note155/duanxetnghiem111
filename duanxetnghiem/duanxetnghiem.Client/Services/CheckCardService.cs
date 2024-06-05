using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using duanxetnghiem.Data.Model;
using Shared.form;
using Shared.ketnoi;

public class CheckCardService
{
    private readonly HttpClient _httpClient;

    public CheckCardService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CheckCardResponse> CheckCardAsync(string datauser)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "http://apilichkham.aulacsoft.com/Webmain.asmx/CheckInsCardFastMachine");
        var collection = new List<KeyValuePair<string, string>>();
        collection.Add(new("data", datauser));
        var content = new FormUrlEncodedContent(collection);
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var ketqua = await response.Content.ReadFromJsonAsync<CheckCardResponse>();
        Console.WriteLine(await response.Content.ReadAsStringAsync());
        return ketqua;

    }

}
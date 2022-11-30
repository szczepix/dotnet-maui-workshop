using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public class MonkeyService
{
    // Get data from https://raw.githubusercontent.com/szczepix/dotnet-maui-workshop/main/Finish/MonkeyFinder/Resources/Raw/monkeydata.json
    // and deserialize it to a list of Monkey objects
    private List<Monkey> _monkeyList = new();
    HttpClient _httpClient;

    public MonkeyService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<Monkey>> GetMonkeys()
    {
        if (_monkeyList?.Count > 0)
            return _monkeyList;

        var url = "https://raw.githubusercontent.com/szczepix/dotnet-maui-workshop/main/Finish/MonkeyFinder/Resources/Raw/monkeydata.json";
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
            _monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();

        /*
        // Wersja do odczytania z pliku json
        using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        _monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);
        */

        return _monkeyList;
    }
}

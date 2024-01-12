using System.Text.Json;

namespace RaptureAPI_lightweight;

public class RaptureData
{
    public List<Rapture> Raptures { get; init; }

    public RaptureData()
    {
        var raptureJson = File.ReadAllText("raptureData/rapture-data.json");

        Raptures = JsonSerializer.Deserialize<List<Rapture>>(raptureJson) ?? [];
    }
}

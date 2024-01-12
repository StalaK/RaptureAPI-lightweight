namespace RaptureAPI_lightweight;

internal static class Endpoints
{
    internal static void RegisterEndpoints(this WebApplication app)
    {
        app.MapGet("/GetAllRaptures", (RaptureData data) => data.Raptures);

        app.MapGet("/GetSurvivedRaptures", (RaptureData data, DateTime dateOfBirth) => data.Raptures.Where(r => r.RaptureEndDate >= dateOfBirth && r.RaptureEndDate < DateTime.Now));

        app.MapGet("/GetNextRapture", (RaptureData data) => data.Raptures.Find(r => r.RaptureStartDate >= DateTime.Now));

        app.MapGet("/GetCurrentRapture", (RaptureData data) => data.Raptures.Find(r => r.RaptureStartDate <= DateTime.Now && r.RaptureEndDate >= DateTime.Now));

        app.MapGet("/GetAllFutureRaptures", (RaptureData data) => data.Raptures.Where(r => r.RaptureEndDate >= DateTime.Now));
    }
}

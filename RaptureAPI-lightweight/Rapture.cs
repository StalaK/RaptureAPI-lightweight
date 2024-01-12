namespace RaptureAPI_lightweight;

public class Rapture
{
    public int Id { get; set; }

    public DateTime RaptureStartDate { get; set; }

    public DateTime RaptureEndDate { get; set; }

    public string Predictor { get; set; } = string.Empty;

    public string Details { get; set; } = string.Empty;

    public string WhoGotRaptured { get; set; } = string.Empty;

    public bool MonthOnly { get; set; }

    public bool YearOnly { get; set; }
}

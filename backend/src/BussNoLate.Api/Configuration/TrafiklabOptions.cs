namespace BussNoLate.Api.Configuration;

public sealed class TrafiklabOptions
{
    public const string SectionName = "Trafiklab";

    public string? ApiKey { get; set; }
}

namespace PM.Infrastrcture.Persistence;


public class DbSettings
{
    public const string SectionName = "ConnectionStrings";
    public string PMDb { get; init; } = null!;

}
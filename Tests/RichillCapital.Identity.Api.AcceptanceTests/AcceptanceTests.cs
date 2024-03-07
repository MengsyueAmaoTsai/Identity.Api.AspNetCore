namespace RichillCapital.Identity.Api.AcceptanceTests;

public abstract class AcceptanceTests :
    IClassFixture<AcceptanceTestsWebApplicationFactory>
{
    public AcceptanceTests(AcceptanceTestsWebApplicationFactory factory) =>
        Client = factory.CreateClient();

    protected HttpClient Client { get; init; }
}
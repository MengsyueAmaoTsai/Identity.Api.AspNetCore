
using RichillCapital.Identity.Api.AcceptanceTests;

public abstract class BotsAcceptanceTests(AcceptanceTestsWebApplicationFactory factory) :
    AcceptanceTests(factory)
{
    protected static readonly string ValidId = "TV-BINANCE:ETHUSDT.P-M15-PL-0001";
    protected static readonly string InvalidId = "TVBINANCE:ETHUSDT.PM15PL0001";
    protected static readonly string NotFoundId = "TV-BINANCE:ETHUSDT.P-M15-PL-0000";
}
namespace RichillCapital.Identity.Api.AcceptanceTests.Bots;

public abstract class BotsAcceptanceTests(AcceptanceTestsWebApplicationFactory factory) :
    AcceptanceTests(factory)
{
    protected static readonly string ValidId = "TV-BINANCE:ETHUSDT.P-M15-PL-0001";
    protected static readonly string InvalidId = "TVBINANCE:ETHUSDT.PM15PL0001";
    protected static readonly string NewId1 = "TV-BINANCE:ETHUSDT.P-M15-PL-9999";
    protected static readonly string NewId2 = "TV-BINANCE:ETHUSDT.P-M15-PL-9998";
    protected static readonly string NewId3 = "TV-BINANCE:ETHUSDT.P-M15-PL-9997";
    protected static readonly string NewId4 = "TV-BINANCE:ETHUSDT.P-M15-PL-9996";
    protected static readonly string NewId5 = "TV-BINANCE:ETHUSDT.P-M15-PL-9995";
    protected static readonly string NewId6 = "TV-BINANCE:ETHUSDT.P-M15-PL-9994";
    protected static readonly string NewId7 = "TV-BINANCE:ETHUSDT.P-M15-PL-9993";

    protected static readonly string NewName1 = "bot1";
    protected static readonly string NewName2 = "bot2";
    protected static readonly string NewName3 = "bot3";
    protected static readonly string NewName4 = "bot4";
    protected static readonly string NewName5 = "bot5";
    protected static readonly string NewName6 = "bot6";
    protected static readonly string NewName7 = "bot7";

}
using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using RichillCapital.Contracts;

namespace RichillCapital.Identity.Api.AcceptanceTests.Bots;

public sealed class CreateBotTests(AcceptanceTestsWebApplicationFactory factory) :
    BotsAcceptanceTests(factory)
{
    private static readonly CreateBotRequest Request = new()
    {
        Id = "TV-BINANCE:ETHUSDT.P-M15-PL-0002",
        Name = "Double CCI Trend following2",
        Description = "",
        Symbols = ["BINANCE:ETHUSDT.P"],
        Side = "Short",
        Platform = "TradingView",
    };

    [Fact]
    public async Task When_GivenInvalidId_Should_ReturnBadRequest()
    {
        // Arrange
        var request = Request with { Id = string.Empty };

        // Act
        var createResponse = await Client.PostAsJsonAsync(ApiRoutes.V1.Bots.Create, request);

        // Assert
        createResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task When_GivenIdIsDuplicated_Should_ReturnConflict()
    {
        // Arrange
        var request = Request with { Id = ValidId };

        // Act
        var createResponse = await Client.PostAsJsonAsync(ApiRoutes.V1.Bots.Create, request);

        // Assert
        createResponse.StatusCode.Should().Be(HttpStatusCode.Conflict);
    }

    [Fact]
    public async Task When_GivenInvalidName_Should_ReturnBadRequest()
    {
        // Arrange
        var request = Request with
        {
            Id = NewId2,
            Name = string.Empty
        };

        // Act
        var createResponse = await Client.PostAsJsonAsync(ApiRoutes.V1.Bots.Create, request);

        // Assert
        createResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task When_GivenNameIsDuplicated_Should_ReturnConflict()
    {
        // Arrange
        var request = Request with
        {
            Id = NewId3,
            Name = "Double CCI Trend following"
        };

        // Act
        var createResponse = await Client.PostAsJsonAsync(ApiRoutes.V1.Bots.Create, request);

        // Assert
        createResponse.StatusCode.Should().Be(HttpStatusCode.Conflict);
    }

    [Fact]
    public async Task When_GivenSymbolsAnyIsInvalid_Should_ReturnBadRequest()
    {
        // Arrange
        var request = Request with
        {
            Id = NewId4,
            Name = NewName4,
            Symbols = [string.Empty, "BINANCE:ETHUSDT.P"],
        };

        // Act
        var createResponse = await Client.PostAsJsonAsync(ApiRoutes.V1.Bots.Create, request);

        // Assert
        createResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task When_GivenInvalidSide_Should_ReturnBadRequest()
    {
        // Arrange
        var request = Request with
        {
            Id = NewId5,
            Name = NewName5,
            Side = "Invalid",
        };

        // Act
        var createResponse = await Client.PostAsJsonAsync(ApiRoutes.V1.Bots.Create, request);

        // Assert
        createResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task When_GivenInvalidPlatform_Should_ReturnBadRequest()
    {
        // Arrange
        var request = Request with
        {
            Id = NewId6,
            Name = NewName6,
            Platform = "Invalid",
        };

        // Act
        var createResponse = await Client.PostAsJsonAsync(ApiRoutes.V1.Bots.Create, request);

        // Assert
        createResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task When_GivenValidRequest_Should_CreateNewBot()
    {
        // Act
        var createResponse = await Client.PostAsJsonAsync(
            ApiRoutes.V1.Bots.Create,
            Request with
            {
                Id = NewId7,
                Name = NewName7,
            });

        var (response, result) = await Client.GetAndDeserializeAsync<BotResponse>(createResponse.Headers.Location!.ToString());

        // Assert
        createResponse.StatusCode.Should().Be(HttpStatusCode.Created);

        response.EnsureSuccessStatusCode();

        result!.Id.Should().Be(NewId7);
        result.Name.Should().Be(NewName7);
        result.Description.Should().Be(Request.Description);
        result.Symbols.Should().BeEquivalentTo(Request.Symbols);
        result.Side.Should().Be(Request.Side);
        result.Platform.Should().Be(Request.Platform);
    }
}
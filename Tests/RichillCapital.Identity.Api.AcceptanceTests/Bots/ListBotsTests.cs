using FluentAssertions;
using RichillCapital.Contracts;
using RichillCapital.Persistence;
using System.Net;

namespace RichillCapital.Identity.Api.AcceptanceTests.Bots;

public sealed class ListBotsTests(AcceptanceTestsWebApplicationFactory factory) :
    AcceptanceTests(factory)
{
    [Fact]
    public async Task When_GivenValidRequest_Should_ReturnListOfBot()
    {
        // Arrange
        var expectedBots = Seed.Bots
            .Select(bot => new BotResponse(
                bot.Id.Value,
                bot.Name.Value,
                bot.Description.Value,
                bot.Symbols.Select(symbol => symbol.Value).ToArray(),
                bot.Side.Name,
                bot.Platform.Name));

        // Act
        var (response, result) = await Client
            .GetAndDeserializeAsync<ListBotsResponse>(ApiRoutes.V1.Bots.List);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        result!.Items.Should().BeEquivalentTo(expectedBots);
    }
}

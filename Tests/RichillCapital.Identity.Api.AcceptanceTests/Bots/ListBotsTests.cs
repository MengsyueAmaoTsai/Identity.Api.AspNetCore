using FluentAssertions;
using RichillCapital.Contracts;
using RichillCapital.Persistence;
using System.Net;
using System.Net.Http.Json;

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
        var response = await Client.GetAsync(ApiRoutes.V1.Bots.List);
        
        var result = await response.Content.ReadFromJsonAsync<ListBotsResponse>();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        result!.Items.Should().BeEquivalentTo(expectedBots);
    }
}

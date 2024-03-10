using System.Net;
using FluentAssertions;
using RichillCapital.Contracts;

namespace RichillCapital.Identity.Api.AcceptanceTests.Bots;

public sealed class DeleteBotTests(AcceptanceTestsWebApplicationFactory factory) :
    BotsAcceptanceTests(factory)
{
    [Fact]
    public async Task When_GivenInvalidId_Should_ReturnBadRequest()
    {
        // Arrange & Act
        var (response, result) = await Client
            .GetAndDeserializeAsync<BotResponse>(ApiRoutes.V1.Bots.Delete.Replace("{botId}", InvalidId));

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        result.Should().BeNull();
    }

    [Fact]
    public async Task When_GivenIdWasNotFound_Should_ReturnNotFound()
    {
        // Arrange & Act
        var (response, result) = await Client
            .GetAndDeserializeAsync<BotResponse>(ApiRoutes.V1.Bots.Get.Replace("{botId}", NotFoundId));

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        result.Should().BeNull();
    }


    [Fact]
    public async Task When_GivenValidRequest_Should_ReturnDeleteSpecifiedBot()
    {
        var response = await Client.DeleteAsync(ApiRoutes.V1.Bots.Delete.Replace("{botId}", ValidId));

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}
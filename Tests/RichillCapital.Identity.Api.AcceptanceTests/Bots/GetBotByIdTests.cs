
using System.Net;
using FluentAssertions;
using RichillCapital.Contracts;
using RichillCapital.Identity.Api.AcceptanceTests;

public sealed class GetBotByIdTests(AcceptanceTestsWebApplicationFactory factory) :
    BotsAcceptanceTests(factory)
{
    [Fact]
    public async Task When_GivenInvalidId_Should_ReturnBadRequest()
    {
        // Arrange & Act
        var (response, result) = await Client
            .GetAndDeserializeAsync<BotResponse>(ApiRoutes.V1.Bots.Get.Replace("{botId}", InvalidId));

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
    public async Task When_GivenValidRequest_Should_ReturnSpecifiedBot()
    {
        // Arrange & Act
        var (response, result) = await Client
            .GetAndDeserializeAsync<BotResponse>(ApiRoutes.V1.Bots.Get.Replace("{botId}", ValidId));

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        result.Should().NotBeNull();
        result!.Id.Should().Be(ValidId);
    }
}
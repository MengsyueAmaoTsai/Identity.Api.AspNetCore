using System.Net;
using System.Net.Http.Json;

using FluentAssertions;

using RichillCapital.Identity.Api.Endpoints.Users;
using RichillCapital.Persistence;

namespace RichillCapital.Identity.Api.AcceptanceTests.Users;

public sealed class ListUsersTests(AcceptanceTestsWebApplicationFactory factory) :
    AcceptanceTests(factory)
{
    [Fact]
    public async Task Should_ReturnOk_And_ReturnListOfUsers()
    {
        // Arrange
        var expectedUsers = SeedProvider.Users.AsResponse();

        // Act
        var response = await Client.GetAsync("/api/users");
        var listUsersResponse = await response.Content.ReadFromJsonAsync<ListUsersResponse>();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        listUsersResponse.Should().NotBeNull();
        listUsersResponse!.Users.Should().NotBeEmpty();
        listUsersResponse.Users.Should().HaveCount(expectedUsers.Count());
        listUsersResponse.Users.Should().BeEquivalentTo(expectedUsers);
    }

    // Test pagination
    [Fact]
    public async Task When_PaginationParametersAreProvided_Should_ReturnOk_And_ReturnListOfUsers()
    {
        // Arrange
        var page = 1;
        var pageSize = 1;
        var expectedUsers = SeedProvider.Users
            .AsResponse()
            .Take(pageSize);

        // Act
        var response = await Client.GetAsync($"/api/users?page={page}&pageSize={pageSize}");
        var listUsersResponse = await response.Content.ReadFromJsonAsync<ListUsersResponse>();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        listUsersResponse.Should().NotBeNull();
        listUsersResponse!.Users.Should().NotBeEmpty();
        listUsersResponse.Users.Should().BeEquivalentTo(expectedUsers);
    }

    // Should support sorting
    [Fact]
    public async Task When_SortingParametersAreProvided_Should_ReturnOk_And_ReturnListOfUsers()
    {
        // Arrange
        var expectedUsers = SeedProvider.Users
            .AsResponse();

        // Act
        var response = await Client.GetAsync($"/api/users?sortBy=email");
        var listUsersResponse = await response.Content.ReadFromJsonAsync<ListUsersResponse>();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        listUsersResponse.Should().NotBeNull();
        listUsersResponse!.Users.Should().NotBeEmpty();
        listUsersResponse.Users.Should().BeEquivalentTo(expectedUsers);
    }
}
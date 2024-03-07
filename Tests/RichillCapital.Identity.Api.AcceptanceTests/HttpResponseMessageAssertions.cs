using System.Net;

using FluentAssertions;

namespace RichillCapital.Identity.Api.AcceptanceTests;

public static class HttpResponseMessageAssertions
{
    public static void ShouldBeSuccess(this HttpResponseMessage response) =>
        response.ShouldWithStatusCode(HttpStatusCode.OK);

    public static void ShouldBeBadRequest(this HttpResponseMessage response) =>
        response.ShouldWithStatusCode(HttpStatusCode.BadRequest);

    public static void ShouldBeUnauthorized(this HttpResponseMessage response) =>
        response.ShouldWithStatusCode(HttpStatusCode.Unauthorized);

    public static void ShouldBeNotFound(this HttpResponseMessage response) =>
        response.ShouldWithStatusCode(HttpStatusCode.NotFound);

    public static void ShouldBeConflict(this HttpResponseMessage response) =>
        response.ShouldWithStatusCode(HttpStatusCode.Conflict);

    private static void ShouldWithStatusCode(
        this HttpResponseMessage response,
        HttpStatusCode statusCode) =>
        response.StatusCode.Should().Be(statusCode);
}
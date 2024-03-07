using System.Collections.ObjectModel;

using RichillCapital.Domain;
using RichillCapital.Identity.Api.Endpoints.Users;

namespace RichillCapital.Identity.Api.AcceptanceTests;

internal static class SeedExtensions
{
    internal static IEnumerable<UserResponse> AsResponse(this Collection<User> users) =>
        users.Select(user => new UserResponse(
            user.Id.Value,
            user.Email.Value,
            user.Name.Value));
}
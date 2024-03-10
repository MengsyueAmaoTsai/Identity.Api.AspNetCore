using Microsoft.AspNetCore.Mvc;
using RichillCapital.Contracts;
using RichillCapital.Persistence;

namespace RichillCapital.Identity.Api;

[ApiController]
public sealed class BotsController : ControllerBase
{
    [HttpGet(ApiRoutes.V1.Bots.List)]
    public async Task<IActionResult> List()
    {
        var bots = Seed.Bots
            .Select(bot => new BotResponse(
                bot.Id.Value,
                bot.Name.Value,
                bot.Description.Value,
                bot.Symbols.Select(symbol => symbol.Value).ToArray(),
                bot.Side.Name,
                bot.Platform.Name));

        var listBotsResponse = new ListBotsResponse(bots);
        
        return Ok(listBotsResponse);
    }
}

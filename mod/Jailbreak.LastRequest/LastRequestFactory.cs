using CounterStrikeSharp.API.Core;
using Jailbreak.Formatting.Views;
using Jailbreak.LastRequest.LastRequests;
using Jailbreak.Public.Mod.LastRequest;
using Jailbreak.Public.Mod.LastRequest.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace Jailbreak.LastRequest;

public class LastRequestFactory(ILastRequestManager manager,
  IServiceProvider services) : ILastRequestFactory {
  private BasePlugin? plugin;

  public void Start(BasePlugin basePlugin) { plugin = basePlugin; }

  public AbstractLastRequest CreateLastRequest(CCSPlayerController prisoner,
    CCSPlayerController guard, LRType type) {
    return type switch {
      LRType.KNIFE_FIGHT => new KnifeFight(plugin!, manager, prisoner, guard),
      LRType.GUN_TOSS    => new GunToss(plugin!, manager, prisoner, guard),
      LRType.NO_SCOPE    => new NoScope(plugin!, manager, prisoner, guard),
      LRType.ROCK_PAPER_SCISSORS => new RockPaperScissors(plugin!, manager,
        prisoner, guard),
      LRType.COINFLIP => new Coinflip(plugin!, manager, prisoner, guard),
      LRType.RACE => new Race(plugin!, manager, prisoner, guard,
        services.GetRequiredService<IRaceLRMessages>()),
      _ => throw new ArgumentException("Invalid last request type: " + type,
        nameof(type))
    };
  }

  public bool IsValidType(LRType type) {
    return type switch {
      LRType.KNIFE_FIGHT         => true,
      LRType.GUN_TOSS            => true,
      LRType.NO_SCOPE            => true,
      LRType.ROCK_PAPER_SCISSORS => true,
      LRType.COINFLIP            => true,
      LRType.RACE                => true,
      _                          => false
    };
  }
}
using CounterStrikeSharp.API.Core;
using Jailbreak.Public.Mod.Rebel;
using Microsoft.Extensions.DependencyInjection;

namespace Jailbreak.Debug.Subcommands;

// css_pardon [player]
public class Pardon(IServiceProvider services) : AbstractCommand(services)
{
    public override void OnCommand(CCSPlayerController? executor, WrappedInfo info)
    {
        if (info.ArgCount == 1)
        {
            info.ReplyToCommand("Specify target?");
            return;
        }

        var target = GetVulnerableTarget(info);
        if (target == null)
            return;

        foreach (var player in target.Players) Services.GetRequiredService<IRebelService>().UnmarkRebel(player);

        info.ReplyToCommand($"Pardoned {GetTargetLabel(info)}");
    }
}
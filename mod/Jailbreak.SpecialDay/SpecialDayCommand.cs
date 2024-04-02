using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Commands.Targeting;
using CounterStrikeSharp.API.Modules.Menu;
using CounterStrikeSharp.API.Modules.Utils;
using Jailbreak.Formatting.Extensions;
using Jailbreak.Formatting.Views;
using Jailbreak.Public.Behaviors;
using Jailbreak.Public.Extensions;
using Jailbreak.Public.Mod.SpecialDay;
using Jailbreak.Public.Mod.SpecialDay.Enums;
using Microsoft.Extensions.DependencyModel;

namespace Jailbreak.SpecialDay;

public class SpecialDayCommand(
    ISpecialDayManager manager,
    ISpecialDayMessages messages,
    IGenericCommandNotifications generic,
    ISpecialDayFactory factory)
    : IPluginBehavior
{
    private SpecialDayMenuSelector _menuSelector;
    private SpecialDayPlayerSelector _playerSelector;
    private BasePlugin _plugin;

    // css_lr <player> <LRType>
    public void Start(BasePlugin plugin)
    {
        _plugin = plugin;
        _playerSelector = new SpecialDayPlayerSelector(manager);
        _menuSelector = new SpecialDayMenuSelector(factory);
    }

    [ConsoleCommand("css_sd", "Start a special day as warden")]
    [CommandHelper(whoCanExecute: CommandUsage.CLIENT_ONLY)]
    public void Command_SpecialDay(CCSPlayerController? executor, CommandInfo info)
    {
        if (executor == null || !executor.IsReal())
            return;
        if (executor.Team != CsTeam.Terrorist)
        {
            info.ReplyToCommand("You must be a terrorist to LR.");
            return;
        }

        if (!executor.PawnIsAlive)
        {
            info.ReplyToCommand("You must be alive to LR.");
            return;
        }

        if (!manager.IsSDEnabled)
        {
            messages.SpecialDayNotEnabled().ToPlayerChat(executor);
            return;
        }

        if (!_playerSelector.WouldHavePlayers())
        {
            info.ReplyToCommand("There are no players available to LR.");
            return;
        }

        if (manager.IsInSD(executor))
        {
            info.ReplyToCommand("You are already in an LR!");
            return;
        }

        if (info.ArgCount == 1)
        {
            MenuManager.OpenCenterHtmlMenu(_plugin, executor, _menuSelector.GetMenu());
            return;
        }

        // Validate LR
        var type = SDTypeExtensions.FromString(info.GetArg(1));
        if (type is null)
        {
            messages.InvalidSpecialDay(info.GetArg(1)).ToPlayerChat(executor);
            return;
        }

        if (info.ArgCount == 2)
        {
            MenuManager.OpenCenterHtmlMenu(_plugin, executor,
                _playerSelector.CreateMenu(executor, (str) => "css_sd " + type + " #" + str));
            return;
        }

        var target = info.GetArgTargetResult(2);
        if (target.Players.Count == 0)
        {
            generic.PlayerNotFound(info.GetArg(2));
            return;
        }

        if (target.Players.Count > 1)
        {
            generic.PlayerFoundMultiple(info.GetArg(2));
            return;
        }

        var player = target.Players.First();
        if (player.Team != CsTeam.CounterTerrorist)
        {
            messages.InvalidPlayerChoice(player, "They're not on CT!");
            return;
        }

        if (!player.PawnIsAlive)
        {
            messages.InvalidPlayerChoice(player, "They're not alive!");
            return;
        }

        if (manager.IsInSD(player))
        {
            messages.InvalidPlayerChoice(player, "They're already in an LR!");
            return;
        }

        if (!manager.InitiateSpecialDay(executor, player, (SDType)type))
        {
            info.ReplyToCommand("An error occurred while initiating the last request. Please try again later.");
        }
    }
}